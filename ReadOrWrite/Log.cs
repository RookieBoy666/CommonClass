using System;
using System.IO;

namespace ReadOrWrite
{
    public  class Log
    {
        private string Event { get; set; }
        private DateTime Time { get; set; }


        /// <summary>
        /// 日志记录，写入文件
        /// </summary>
        /// <param name="Eventname">事件名</param>
        /// <param name="Time">时间</param>
        public void RegisterLog(string Eventname, string Time)
        {            //判断是否已经有了这个文件
            if (!System.IO.File.Exists("log.txt"))
            {
                //没有则创建这个文件
                FileStream fs1 = new FileStream("log.txt", FileMode.Create, FileAccess.Write);//创建写入文件               
                System.IO.File.SetAttributes(@"log.txt", FileAttributes.Hidden); //设置文件属性为隐藏
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(Eventname.Trim() + " " + Time.Trim());//开始写入值
                sw.Close();
                fs1.Close();
                //return "注册成功";
            }
            else
            {   //有则追加字符串
                FileStream fs = new FileStream("log.txt", FileMode.Append, FileAccess.Write);
                System.IO.File.SetAttributes(@"log.txt", FileAttributes.Hidden);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(Eventname.Trim() + " " + Time.Trim());//开始写入值
                sr.Close();
                fs.Close();
                //  return "注册成功";
            }

        }

    }
}