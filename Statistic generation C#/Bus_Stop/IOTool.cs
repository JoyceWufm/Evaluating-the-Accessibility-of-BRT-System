using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Bus_Stop
{
    class IOTool
    {     
        //写文件函数
        public static void WriteFile(string txtpath, string content)  
        {
            if (File.Exists(txtpath))  //文件路径是否已存在
            {
                using (StreamWriter sw = new StreamWriter(txtpath, true))
                {
                    sw.WriteLine(content);
                }
            }
            else  //文件路径不存在创建新文件
            {
                FileStream fs1 = new FileStream(txtpath, FileMode.Create, FileAccess.Write); //创建写入文件
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(content);  //开始写入值
                sw.Close();
                fs1.Close();
            }
        }

        //读文件函数
        public static List<string> ReadText(string filepath)
        {
            if (File.Exists(filepath)) //需读取的文件路径存在
            {
                List<string> contents = new List<string>();
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);   //文本编码方式UTF8

                string strLine = sr.ReadLine();  //按行读取
                //循环读出数据，数据存在data里面
                while (strLine != null)
                {
                    contents.Add(strLine);
                    strLine = sr.ReadLine();
                }
                //关闭文件流
                sr.Close();
                fs.Close();

                return contents;
            }
            else   //需读取的文件路径不存在
            {
                return null;
            }
        }

        //重载读文件函数(编码方式)
        public static List<string> ReadText(string filepath, Encoding encode)
        {
            if (File.Exists(filepath)) //需读取的文件路径存在
            {
                List<string> contents = new List<string>();
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None);
                StreamReader sr = new StreamReader(fs, encode);   //文本编码方式UTF8

                string strLine = sr.ReadLine();  //按行读取
                //循环读出数据，数据存在data里面
                while (strLine != null)
                {
                    contents.Add(strLine);
                    strLine = sr.ReadLine();
                }
                //关闭文件流
                sr.Close();
                fs.Close();

                return contents;
            }
            else   //需读取的文件路径不存在
            {
                return null;
            }
        }

        //根据行内容删除该行
        public static bool DeleteLine(string path, string line)
        {
            try
            {
                List<string> list = new List<string>();
                list = ReadText(path, Encoding.UTF8);

                //int index = ReturnIndex(list, line);
                int index = Convert.ToInt32(line);
                list.RemoveAt(index);
                string[] lines = list.ToArray();   //需将list<string>转化为string[]数组
                //保存
                File.WriteAllLines(path, lines);   //WriteAllLines(String, String[])
                return true;   //删除成功
            }
            catch
            {
                return false;  //删除失败
            }
        }

        //返回行内容的索引号
        //private static int ReturnIndex(List<string> list, string line)
        //{
        //    try
        //    {
        //        int i = 0;
        //        for (; i < list.Count; i++)
        //        {
        //            if (list[i] == line)
        //            {
        //                break;
        //            }
        //        }
        //        return i;
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}

    }
}
