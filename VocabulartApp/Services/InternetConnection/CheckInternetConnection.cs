using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SmartBSU.Services.InternetConnection
{
    class CheckInternetConnection : IInternetConnection
    {
        private const string URL = "http://www.google.com";
        public  bool IsConnected()
        {
            try
            {
                HttpWebRequest httpReq = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse httpWeb = (HttpWebResponse)httpReq.GetResponse();

                if (HttpStatusCode.OK == httpWeb.StatusCode)
                {
                    httpWeb.Close();
                    return true;
                }
                else
                {
                    httpWeb.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
