using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Nextload.JXHouse.Framework
{
    public class HttpHelper
    {
        private Logger _logger = Logger.CreateLogger(typeof(HttpHelper));
        public static async Task<HttpResponseMessage> HttpPost(string url,string data)
        {
            using (HttpClient httpClient = new HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                }))
            {
                httpClient.DefaultRequestHeaders.Add(@"Accept", @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                httpClient.DefaultRequestHeaders.Add(@"Accept-Encoding", @"gzip, deflate, br");
                httpClient.DefaultRequestHeaders.Add(@"Accept-Language", @"zh-CN,zh;q=0.9");
                httpClient.DefaultRequestHeaders.Add(@"User-Agent", @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.142 Safari/537.36");
                //httpClient.DefaultRequestHeaders.Add(@"Cookie", @"Hm_lvt_f040723b21992f74b48618af56517fbb=1568269633; Hm_lpvt_f040723b21992f74b48618af56517fbb=1568269694");
                //httpClient.DefaultRequestHeaders.Add(@"Host", @"www.23us.so");
                //httpClient.DefaultRequestHeaders.Add(@"Referer", @"https://www.23us.so/full.html");
                httpClient.DefaultRequestHeaders.Add(@"Upgrade-Insecure-Requests", @"1");
                httpClient.DefaultRequestHeaders.Add(@"Cache-Control", @"max-age=0");
                httpClient.DefaultRequestHeaders.Add(@"Connection", @"keep-alive");
                httpClient.BaseAddress = new Uri(url);
                HttpContent httpContent = new StringContent(data);
                return await httpClient.PostAsync(url, httpContent);
            }


        }
    }
}
