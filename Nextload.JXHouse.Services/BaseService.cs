﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Nextload.JXHouse.IServices;
using Nextload.JXHouse.Models;

namespace Nextload.JXHouse.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseModel
    {
        /// <summary>
        /// 这是BLL基类，就是为了泛型重用
        /// </summary>
        #region Identity
        protected DbContext Context { get; private set; }
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="context"></param>
        public BaseService(DbContext context)
        {
            this.Context = context;
        }
        #endregion Identity

        #region Query
        public T Find(long id)
        {
            return this.Context.Set<T>().FirstOrDefault(t => t.IsDelete == false && t.Id == id);
        }

        /// <summary>
        /// 不应该暴露给上端使用者，尽量少用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Set()
        {
            return this.Context.Set<T>();
        }
        /// <summary>
        /// 这才是合理的做法，上端给条件，这里查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> funcWhere)
        {
            return this.Context.Set<T>().Where<T>(funcWhere);
        }

        //public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        //{
        //    var list = this.Set<T>();
        //    int totalCount = 0;
        //    if (funcWhere != null)
        //    {
        //        list = list.Where<T>(funcWhere);
        //        totalCount = list.Count(funcWhere);
        //    }
        //    else
        //    {
        //        totalCount = list.Count();
        //    }
        //    if (isAsc)
        //    {
        //        list = list.OrderBy(funcOrderby);
        //    }
        //    else
        //    {
        //        list = list.OrderByDescending(funcOrderby);
        //    }
        //    PageResult<T> result = new PageResult<T>()
        //    {
        //        DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
        //        PageIndex = pageIndex,
        //        PageSize = pageSize,
        //        TotalCount = totalCount
        //    };
        //    return result;
        //}
        #endregion

        #region Insert
        /// <summary>
        /// 即使保存  不需要再Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Insert(T t)
        {
            this.Context.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert(IEnumerable<T> tList)
        {
            this.Context.Set<T>().AddRange(tList);
            this.Commit();//一个链接  多个sql
            return tList;
        }
        #endregion


        #region Update
        /// <summary>
        /// 是没有实现查询，直接更新的,需要Attach和State
        /// 
        /// 如果是已经在context，只能再封装一个(在具体的service)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update(T t)
        {
            if (t == null) throw new Exception("t is null");

            this.Context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为UnChanged
            this.Context.Entry<T>(t).State = EntityState.Modified;
            this.Commit();//保存 然后重置为UnChanged
        }
        /*
         public enum EntityState
    {
        // 摘要:
        //     对象存在，但未由对象服务跟踪。在创建实体之后、但将其添加到对象上下文之前，该实体处于此状态。通过调用 System.Data.Objects.ObjectContext.Detach(System.Object)
        //     方法从上下文中移除实体后，或者使用 System.Data.Objects.MergeOption.NoTrackingSystem.Data.Objects.MergeOption
        //     加载实体后，该实体也会处于此状态。
        Detached = 1,
        //
        // 摘要:
        //     自对象加载到上下文中后，或自上次调用 System.Data.Objects.ObjectContext.SaveChanges() 方法后，此对象尚未经过修改。
        Unchanged = 2,
        //
        // 摘要:
        //     对象已添加到对象上下文，但尚未调用 System.Data.Objects.ObjectContext.SaveChanges() 方法。对象是通过调用
        //     System.Data.Objects.ObjectContext.AddObject(System.String,System.Object)
        //     方法添加到对象上下文中的。
        Added = 4,
        //
        // 摘要:
        //     使用 System.Data.Objects.ObjectContext.DeleteObject(System.Object) 方法从对象上下文中删除了对象。
        Deleted = 8,
        //
        // 摘要:
        //     对象已更改，但尚未调用 System.Data.Objects.ObjectContext.SaveChanges() 方法。
        Modified = 16,
    }
         */

        public void Update(IEnumerable<T> tList)
        {
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }

        #endregion

        #region Delete
        /// <summary>
        /// 先附加 再删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Delete(T t)
        {
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        /// <summary>
        /// 还可以增加非即时commit版本的，
        /// 做成protected
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        public void Delete(long Id)
        {
            T t = this.Find(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete(IEnumerable<T> tList)
        {
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
            }
            this.Context.Set<T>().RemoveRange(tList);
            this.Commit();
        }
        #endregion

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public IQueryable<T> ExcuteQuery(string sql, SqlParameter[] parameters)
        {
            return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
        }

        public void Excute(string sql, SqlParameter[] parameters)
        {
            DbContextTransaction trans = null;
            try
            {
                trans = this.Context.Database.BeginTransaction();
                this.Context.Database.ExecuteSqlCommand(sql, parameters);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}

