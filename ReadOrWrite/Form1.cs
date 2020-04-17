using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadOrWrite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string str=ReadOrWriteHelper.getConfig("Config.txt");
            //if (!File.Exists(@"D:\MyFile.txt"))
            //{
            //    FileStream fs = new FileStream(@"D:\MyFile.txt", FileMode.Create, FileAccess.Write);
            //}

            //else
            //{
            //    using (FileStream fs = new FileStream(@"D:\MyFile.txt", FileMode.Append, FileAccess.Write))
            //    {
            //        fs.Lock(0, fs.Length);
            //        StreamWriter sw = new StreamWriter(fs);
            //        sw.WriteLine("我是最好的，虽然现在不是");
            //        sw.WriteLine("有信息，不一定会赢，但没有信心，肯定会输");
            //        sw.WriteLine("我的期待月薪为{0,9:C4},实现年龄为{1,9},成功率{2,9:P2}", new Object[] { 20000, 30, 1 });
            //        fs.Unlock(0, fs.Length);//一定要用在Flush()方法以前，否则抛出异常。
            //        sw.Flush();
            //    }
            //}
          
        }
    }
}
