using System.Collections.Generic;
using System.IO;

namespace ReadOrWrite
{
    public class ReadOrWriteHelper
    {
        //服务器
        public static string DataSource;
        //数据库
        public static string InitialCatalog;
        //用户Id
        public static string UserID;
        //密码
        public static string Password;
        //1、定义数组,来用接收txt里的内容
        public static Dictionary<string, string> dic = new Dictionary<string, string>();

        /// <summary>
        /// 例如:   ReadOrWriteHelper.getConfig("Config.txt");
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string getConfig(string filename)
        {
            //读取网络上的txt文件
            //WebClient client = new WebClient();
            //byte[] buffer = client.DownloadData("http://域名/myset.txt");
            // FileStream file = new FileStream("\\config.txt", FileMode.Open);
            //byte[] buffer =
            byte[] buffer = ReadFile(filename);
            string res = System.Text.ASCIIEncoding.ASCII.GetString(buffer);
            string str = res.Replace("\r\n", ";");//读取的字符串(去掉换行符)
            //string[] items = str.Split(';');//放进数组里
            //for(int i=0;i<items.Length;i++)
            //{
            //}
            return str;
        }
        //读filename到byte[]
        public static byte[] ReadFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            byte[] buffer = new byte[fs.Length];
            try
            {
                fs.Read(buffer, 0, buffer.Length);
                fs.Seek(0, SeekOrigin.Begin);
                return buffer;
            }
            catch
            {
                return buffer;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

    }
}
