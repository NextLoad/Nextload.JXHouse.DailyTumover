using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.JXHouse.JsonModel
{
    public class Spfcjbylx
    {
        /// <summary>
        /// 
        /// </summary>
        public string zzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sycjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sycjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bgcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bgcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string qtcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string qtcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hjcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hjcjts { get; set; }
    }

    public class SpfcjbyqyItem
    {
        /// <summary>
        /// 经开区
        /// </summary>
        public string qymc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjts { get; set; }
    }

    public class Nh
    {
        /// <summary>
        /// 南湖区
        /// </summary>
        public string qymc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjts { get; set; }
    }

    public class Xz
    {
        /// <summary>
        /// 秀洲区
        /// </summary>
        public string qymc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjts { get; set; }
    }

    public class Jk
    {
        /// <summary>
        /// 经开区
        /// </summary>
        public string qymc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjts { get; set; }
    }

    public class Hj
    {
        /// <summary>
        /// 合计
        /// </summary>
        public string qymc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzcjts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjmj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fzzcjts { get; set; }
    }

    public class JXSpf
    {
        /// <summary>
        /// 
        /// </summary>
        public Spfcjbylx spfcjbylx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SpfcjbyqyItem> spfcjbyqy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nh nh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Xz xz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Jk jk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Hj hj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string scdatetime { get; set; }
    }
}
