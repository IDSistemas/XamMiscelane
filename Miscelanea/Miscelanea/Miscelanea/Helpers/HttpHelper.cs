using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Miscelanea.Helpers
{
    public class HttpHelper
    {
        public static Boolean GenericHttpRequest(string smethod, string surl, string sdata, ref string sresponse, ref string serror)
        {
            //string serror = "";
            Boolean breturn = true;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(surl);
            request.Method = smethod;
            request.ContentType = "application/json";

            if (smethod == "POST")
            {
                //POST
                request.ContentLength = sdata.Length;

                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(sdata);
                }
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            sresponse = responseReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException eresp)
            {
                serror = eresp.Message.ToString();
                breturn = false;
            }
            return breturn;

        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
