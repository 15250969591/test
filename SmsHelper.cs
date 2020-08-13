using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Forms.Common.SmsHelper
{
    public class SmsHelper
    {
        /// <summary>
        /// POST短信发送
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string HttpPostMsg(string param, string postUrl)
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] bs = Encoding.UTF8.GetBytes(param);
            var request = (HttpWebRequest)HttpWebRequest.Create(postUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.ContentLength = bs.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bs, 0, bs.Length);
                stream.Close();
            }

            WebResponse webRequest = request.GetResponse();
            StreamReader streamReader = new StreamReader(webRequest.GetResponseStream(), encoding);
            string strResult = streamReader.ReadToEnd().Trim();
            webRequest.Close();
            streamReader.Close();

            return strResult;
        }
        /// <summary>
        /// POST短信发送
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string HttpPostCivilMeter(string param, string postUrl)
        {
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] bs = Encoding.UTF8.GetBytes(param);
            var request = (HttpWebRequest)HttpWebRequest.Create(postUrl);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = bs.Length;
            
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bs, 0, bs.Length);
                stream.Close();
            }

            WebResponse webRequest = request.GetResponse();
            StreamReader streamReader = new StreamReader(webRequest.GetResponseStream(), encoding);
            string strResult = streamReader.ReadToEnd();
            webRequest.Close();
            streamReader.Close();

            return strResult;
        }

    }
}
