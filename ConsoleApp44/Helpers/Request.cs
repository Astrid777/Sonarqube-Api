using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44.Helpers
{
    internal class Request
    {
        //класс для выполнения запроса
        public static string Server = "адрес";
        public static string Login = "логин";
        public static string Password = "пароль";

        internal static string ExecuteRequestGet(string url)
        {
            string result = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Server + url);

            //httpWebRequest.Headers.Add("Authorization", token);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";


            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Login + ":" + Password));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);


            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamreader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamreader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ошибка:" + e.Message + "  " + e.StackTrace);
                throw;
            }

            return result;
        }


        internal static string ExecuteRequestPost(string url, string parameter)
        {

            string result = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);


            httpWebRequest.ContentType = "application/x-www-form-urlencoded";


            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(parameter);
            httpWebRequest.ContentLength = byteArray.Length;
            httpWebRequest.Method = "POST";

            string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Login + ":" + Password));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

            try
            {
                using (Stream dataStream = httpWebRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }


                Console.WriteLine("POST запрос выполнен...");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamreader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamreader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return result;
        }
    }
}
