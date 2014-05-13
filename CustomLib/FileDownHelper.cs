using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CustomLib
{
    /// <summary>
    /// 文件下载帮助类
    /// </summary>
   public class FileDownHelper
    {
       public FileDownHelper()
       {
            
       }
        public static void DownloadOneFileByURL(string fileName, string url, string localPath, int timeout)
         {
             System.Net.HttpWebRequest request = null;
             System.Net.HttpWebResponse response = null;
             request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url + fileName);
             request.Timeout = timeout;//8000 Not work ?
             response = (System.Net.HttpWebResponse)request.GetResponse();
             Stream s = response.GetResponseStream();
             BinaryReader br = new BinaryReader(s);
             //int length2 = Int32.TryParse(response.ContentLength.ToString(), out 0);
             int length2 = Int32.Parse(response.ContentLength.ToString());
             byte[] byteArr = new byte[length2];
             s.Read(byteArr, 0, length2);
             if (File.Exists(localPath + fileName)) { File.Delete(localPath + fileName); }
             if (Directory.Exists(localPath) == false) { Directory.CreateDirectory(localPath); }
             FileStream fs = File.Create(localPath + fileName);
             fs.Write(byteArr, 0, length2);
             fs.Close();
             br.Close();
         }
         /// <summary>
         ///Web Client Method ,only For Small picture,else large please use FTP
         /// </summary>
         /// <param name="fileName"></param>
         /// <param name="url"></param>
         /// <param name="localPath"></param>
         public static bool DownloadOneFileByURLWithWebClient(string fileName, string url, string localPath)
         {
             try
             {
                 System.Net.WebClient wc = new System.Net.WebClient();
                 if (File.Exists(localPath + fileName)) { File.Delete(localPath + fileName); }
                 if (Directory.Exists(localPath) == false) { Directory.CreateDirectory(localPath); }
                 wc.DownloadFile(url, localPath + fileName);
                 return true;
             }
             catch (Exception ex)
             {
                 return false;

             }
         }
    }
}
