
using System.Net;

namespace Helpers
{
    public class UrlShortner
    {
        public static string ShortenUrl(string strURL)
        {

            string URL = "http://tinyurl.com/api-create.php?url=" +
            strURL.ToLower();

            HttpWebRequest objWebRequest;
            HttpWebResponse objWebResponse;

            System.IO.StreamReader srReader;

            string strHTML;

            objWebRequest = (HttpWebRequest)System.Net
            .WebRequest.Create(URL);
            objWebRequest.Method = "GET";

            objWebResponse = (HttpWebResponse)objWebRequest
            .GetResponse();
            srReader = new System.IO.StreamReader(objWebResponse
            .GetResponseStream());

            strHTML = srReader.ReadToEnd();

            srReader.Close();
            objWebResponse.Close();
            objWebRequest.Abort();

            return strHTML;

        }
    }
}
