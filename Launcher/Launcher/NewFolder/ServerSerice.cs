using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Launcher.NewFolder
{
    public class ServerSerice : IServerSerice
    {
        #region MyRegion

        public void LuncherVersion()
        {
            throw new NotImplementedException();
        }

        //public static T Send<T>(string url, object obj, ref CookieContainer cookie, string method = "POST", Action<string, string, string> TimeOutAction = null) where T : new()
        //{
        //    string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        //    string message = Send(url, json, ref cookie, method, TimeOutAction);
        //    if (IsValidJson<T>(message))
        //    {
        //        T _obj = JsonConvert.DeserializeObject<T>(message);
        //        return _obj;
        //    }
        //    return new T();

        //}
        //public static bool IsValidJson<T>(string strInput)
        //{
        //    if (string.IsNullOrEmpty(strInput))
        //        return false;
        //    try
        //    {
        //        var obj = JsonConvert.DeserializeObject<T>(strInput);
        //        return true;
        //    }
        //    catch (Exception e) // not valid
        //    {
        //        if (Program.server == Program.Server.dev)
        //            //Logger.Error(e.ToString());
        //        return false;
        //    }
        //}
        //protected static object CookieLocker = new object();

        //public static Action<string> Forbidden;
        //public static string Send(string url, string jsonstring, ref CookieContainer cookie, string method = "POST", Action<string, string, string> TimeOutAction = null)
        //{
        //    try
        //    {
        //        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; //創建請求 
        //        //Logger.Info("Http Send : " + url);
        //        //Logger.Info("Http Send jsonstring : " + jsonstring);
        //        lock (CookieLocker)
        //        {
        //            request.CookieContainer = cookie;
        //        }
        //        request.AllowAutoRedirect = true;
        //        //request.AllowReadStreamBuffering = true;
        //        request.Method = method;
        //        request.AllowAutoRedirect = true;
        //        request.MaximumResponseHeadersLength = 1024;
        //        request.ContentType = "application/json";
        //        if (method.ToUpper() == "GET" || method.ToUpper() == "DELETE")
        //        {

        //        }
        //        else
        //        {
        //            Stream postStream = request.GetRequestStream();
        //            byte[] jsonbyte = Encoding.UTF8.GetBytes(jsonstring);
        //            postStream.Write(jsonbyte, 0, jsonbyte.Length);
        //            postStream.Close();
        //        }
        //        //發送請求並獲取相應迴應數據
        //        HttpWebResponse res;
        //        try
        //        {
        //            res = (HttpWebResponse)request.GetResponse();
        //            lock (CookieLocker)
        //            {
        //                cookie = new CookieContainer();
        //                cookie.Add(res.Cookies);
        //            }
        //        }
        //        catch (WebException ex)
        //        {
        //            res = (HttpWebResponse)ex.Response;
        //            if (string.IsNullOrEmpty(jsonstring))
        //            {
        //                //Logger.Error("http error :" + url + "\r\n" + ex.Message);
        //            }
        //            else
        //            {
        //                //Logger.Error("http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message);
        //            }
        //            if (TimeOutAction != null) TimeOutAction.Invoke(url, jsonstring, method);
        //            return null;
        //        }
        //        StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
        //        string content = sr.ReadToEnd(); //獲得響應字符串  
        //        if (res.StatusCode == HttpStatusCode.Forbidden)
        //        {
        //            try
        //            {
        //                if (Forbidden != null) Forbidden.Invoke(content);
        //            }
        //            catch
        //            {

        //            }
        //        }
        //        /*
        //        if(res.StatusCode == HttpStatusCode.OK)
        //            Logger.Info("Http Status : " + res.StatusCode.ToString() + " / URL : " + url);
        //        else
        //            Logger.Warning("Http Status : " + res.StatusCode.ToString() + " / URL : " + url);
        //            */
        //        res.Close();
        //        return content;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (string.IsNullOrEmpty(jsonstring))
        //        {
        //            //Logger.Error("http error :" + url + "\r\n" + ex.Message);
        //        }
        //        else
        //        {
        //            //Logger.Error("http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message);
        //        }

        //        if (ex is WebException && TimeOutAction != null)
        //        {
        //            TimeOutAction.Invoke(url, jsonstring, method);
        //        }
        //        return "";
        //    }
        //}

        #endregion

        public List<string> test1()
        {
            throw new NotImplementedException();
        }

        public void test2()
        {
            throw new NotImplementedException();
        }
    }
}
