using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Launcher.package;

namespace Launcher
{
    class HttpTool
    {
        public static Action<string> Forbidden;

        public static T Send<T>(string url, string json, ref CookieContainer cookie, string method = "POST", Action<string, string, string> TimeOutAction = null) where T :new()
        { 
            string message = Send(url, json, ref cookie, method, TimeOutAction);
            if (IsValidJson<T>(message))
            {
                T _obj = JsonConvert.DeserializeObject<T>(message);
                return _obj;
            } 
            return new T();
        }
        public static T Send<T>(string url, object obj, string method = "POST", Action<string, string, string> TimeOutAction = null) where T : new()
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string message = Send(url, json, method, TimeOutAction);
            if (IsValidJson<T>(message))
            {
                T _obj = JsonConvert.DeserializeObject<T>(message);
                return _obj;
            }
            return new T();
        }

        public static T Send<T>(string url, object obj, ref CookieContainer cookie, out string saveJson, string method = "POST", Action<string, string, string> TimeOutAction = null) where T : new()
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string message = Send(url, json, ref cookie, method, TimeOutAction);
            saveJson = message;
            if (IsValidJson<T>(message))
            {
                T _obj = JsonConvert.DeserializeObject<T>(message);
                return _obj;
            }
                return new T();
        }
        public static T Send<T>(string url, object obj, ref CookieContainer cookie, string method = "POST", Action<string, string, string> TimeOutAction = null) where T : new()
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string message = Send(url, json, ref cookie, method,TimeOutAction);
            if (IsValidJson<T>(message))
            {
                T _obj = JsonConvert.DeserializeObject<T>(message);
                return _obj;
            } 
            return new T();
		}
		public static T[] SendArray<T>( string url, string json, ref CookieContainer cookie, string method = "POST", Action<string, string, string> TimeOutAction = null ) {
			string message = Send( url, json, ref cookie, method, TimeOutAction );
			if( IsValidJson<T[]>( message ) ) {
				T[] array = JsonConvert.DeserializeObject<T[]>( message );
				return array;
			}
			else if( IsValidJson<T>( message ) ) {
				T _obj = JsonConvert.DeserializeObject<T>( message );
				return new T[] { _obj, };
			}
			return new T[0];
		}
		public static T[] SendArray<T>( string url, object obj, ref CookieContainer cookie, string method = "POST", Action<string, string, string> TimeOutAction = null ) {
			string json = JsonConvert.SerializeObject( obj, Formatting.Indented);
			string message = Send( url, json, ref cookie, method, TimeOutAction );
			if( IsValidJson<T[]>( message ) ) {
				T[] array = JsonConvert.DeserializeObject<T[]>( message );
				return array;
			}
			else if( IsValidJson<T>( message ) ) {
				T _obj = JsonConvert.DeserializeObject<T>( message );
				return new T[] { _obj, };
			}
			return new T[0];
		}
		public static bool IsValidJson<T>(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
                return false;
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(strInput);
                return true;
            }
            catch(Exception e) // not valid
            {
                if(Program.server == Program.Server.dev)
                    Logger.Error(e.ToString());
                return false;
            }
        }
        public static string Send(string url, object obj, ref CookieContainer cookie, string method = "POST", Action<string, string, string> TimeOutAction = null) {
           string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
           return Send(url, json, ref cookie, method,TimeOutAction);
        }

		protected static object CookieLocker = new object();

        public static string Send(string url, string jsonstring, ref CookieContainer cookie, string method = "POST",Action<string,string,string>TimeOutAction = null)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; //創建請求 
                //Logger.Info("Http Send : " + url);
                //Logger.Info("Http Send jsonstring : " + jsonstring);
                lock ( CookieLocker ) {
					request.CookieContainer = cookie;
				}
                request.AllowAutoRedirect = true;
                //request.AllowReadStreamBuffering = true;
                request.Method = method;
                request.AllowAutoRedirect = true;
                request.MaximumResponseHeadersLength = 1024;
                request.ContentType = "application/json";
                if (method.ToUpper() == "GET" || method.ToUpper() == "DELETE")
                {

                }
                else
                {
                    Stream postStream = request.GetRequestStream();
                    byte[] jsonbyte = Encoding.UTF8.GetBytes(jsonstring);
                    postStream.Write(jsonbyte, 0, jsonbyte.Length);
                    postStream.Close();
                }
                //發送請求並獲取相應迴應數據
                HttpWebResponse res;
                try
                {
                    res = (HttpWebResponse)request.GetResponse();
					lock( CookieLocker ) {
						cookie = new CookieContainer();
						cookie.Add(res.Cookies);
					}
                }
                catch (WebException ex)
                {
                    res = (HttpWebResponse)ex.Response;
					if( string.IsNullOrEmpty( jsonstring ) ) {
						Logger.Error( "http error :" + url + "\r\n" + ex.Message );
					}
					else {
						Logger.Error( "http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message );
					}
                    if (TimeOutAction != null) TimeOutAction.Invoke(url, jsonstring, method);
                    return null;
                }
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd(); //獲得響應字符串  
                if (res.StatusCode == HttpStatusCode.Forbidden)
                {
                    try
                    {
                        if (Forbidden != null) Forbidden.Invoke(content);
                    }
                    catch
                    {

                    }
                }
                /*
                if(res.StatusCode == HttpStatusCode.OK)
                    Logger.Info("Http Status : " + res.StatusCode.ToString() + " / URL : " + url);
                else
                    Logger.Warning("Http Status : " + res.StatusCode.ToString() + " / URL : " + url);
                    */
                res.Close();
                return content;
            }
            catch( Exception ex )
            {
				if( string.IsNullOrEmpty( jsonstring ) ) {
					Logger.Error( "http error :" + url + "\r\n" + ex.Message );
				}
				else {
					Logger.Error( "http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message );
				}

				if ( ex is WebException && TimeOutAction != null ) {
					TimeOutAction.Invoke( url, jsonstring, method );
				}
                return "";
            }
        }

        public static string Send(string url, string jsonstring, string method = "POST", Action<string, string, string> TimeOutAction = null)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; //創建請求 
                //Logger.Info("Http Send : " + url);
                //Logger.Info("Http Send jsonstring : " + jsonstring);

                request.AllowAutoRedirect = true;
                //request.AllowReadStreamBuffering = true;
                request.Method = method;
                request.AllowAutoRedirect = true;
                request.MaximumResponseHeadersLength = 1024;
                request.ContentType = "application/json";
                if (method.ToUpper() == "GET" || method.ToUpper() == "DELETE")
                {

                }
                else
                {
                    Stream postStream = request.GetRequestStream();
                    byte[] jsonbyte = Encoding.UTF8.GetBytes(jsonstring);
                    postStream.Write(jsonbyte, 0, jsonbyte.Length);
                    postStream.Close();
                }
                //發送請求並獲取相應迴應數據
                HttpWebResponse res;
                try
                {
                    res = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    res = (HttpWebResponse)ex.Response;
                    if (string.IsNullOrEmpty(jsonstring))
                    {
                        Logger.Error("http error :" + url + "\r\n" + ex.Message);
                    }
                    else
                    {
                        Logger.Error("http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message);
                    }
                    if (TimeOutAction != null) TimeOutAction.Invoke(url, jsonstring, method);
                    return null;
                }
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd(); //獲得響應字符串  
                if (res.StatusCode == HttpStatusCode.Forbidden)
                {
                    try
                    {
                        if (Forbidden != null) Forbidden.Invoke(content);
                    }
                    catch
                    {

                    }
                }
                /*
                if(res.StatusCode == HttpStatusCode.OK)
                    Logger.Info("Http Status : " + res.StatusCode.ToString() + " / URL : " + url);
                else
                    Logger.Warning("Http Status : " + res.StatusCode.ToString() + " / URL : " + url);
                    */
                res.Close();
                return content;
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(jsonstring))
                {
                    Logger.Error("http error :" + url + "\r\n" + ex.Message);
                }
                else
                {
                    Logger.Error("http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message);
                }

                if (ex is WebException && TimeOutAction != null)
                {
                    TimeOutAction.Invoke(url, jsonstring, method);
                }
                return "";
            }
        }


        public static bool Ping(string target) {
            bool pingable = false;
            Ping pinger = null;
            IPAddress ip;
            Uri url = new Uri(target);
            string link;
            if (IPAddress.TryParse(url.Host, out ip))
            {
                IPEndPoint endPoint = new IPEndPoint(ip, url.Port);
                link = ip.ToString();
            }
            else
            { 
                link = url.Host;
            } 
            try
            {
                pinger = new Ping(); 
                PingReply reply = pinger.Send(link);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
            return pingable;
        }

		public static bool TelnetPing()
		{
            string host = Program.launcherGetDomain.api_domain.ToString();
            if (host.Contains("varlivebox") == true)
            {
                API.pingHost = API.international;
            }
            else if (host.Contains("varchina") == true)
            {
                API.pingHost = API.internationalCN;
            }
            if (string.IsNullOrEmpty(API.pingHost))
                return false;
            using (Ping pinger = new Ping())
			{
				try
				{
					PingReply reply = pinger.Send(API.pingHost, 5000);
					return reply.Status == IPStatus.Success;
				}
				catch (Exception e)
				{
					return false;
				}
			}
		}

        public static bool TelnetPing(string target) {
            TcpClient tc = null;
            IPAddress ip;
            Uri url = new Uri(target);
            string link;
            int port = 80;
            if (IPAddress.TryParse(url.Host, out ip))
            {
                IPEndPoint endPoint = new IPEndPoint(ip, url.Port);
                link = ip.ToString();
                port = url.Port;
            }
            else
            {
                link = url.Host;
            }
            using (tc = new TcpClient()) {
                try
                {
                    tc.Connect(link, port);
                    bool connect = tc.Connected;
                    tc.Close();
                    return connect;
                }
                catch {
                    return false;
                }
            } 
        }
    }
}
