using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bus_Stop
{
    public partial class Form1 : Form
    {

/*****************************************************************
        *数据库连接
        *调用ADOHelper
        *
        *变量解释：
        *connectStr163 数据库连接凭证
******************************************************************/

        static public string connectStr163 = "Provider=MSDAORA;host=172.18.190.163;data source=stbus;user id=sa;password=Its312";
        public ADOHelper ado163 = new ADOHelper(connectStr163);

        public Form1()
        {
            InitializeComponent();
        }

/*****************************************************************
        *从数据库读取车辆报站数据
        *以一辆车的buscode为一次读取索引
        *
        *变量解释：
        *filepath           buscode存储文件对应路径
        *Buscode            存储buscode
        *filenamebusadtime  每个buscode所对应的报站数据的存储文件名
        *adflagA            A站的出入站布尔值，0代表进站，1代表出站
        *adflagB            B站的出入站布尔值，0代表进站，1代表出站
        *busstopnumA        A站的站台对应序号（在Bus_Stop.txt）
        *busstopnumB        B站的站台对应序号（在Bus_Stop.txt）
        *begin              BusAD_i.txt的首行预留
        *                   预防首条报站数据出错的情况
        *routecode          存储线路编码
        *busstopnum         存储站台编码
        *adflag             存储出入站的布尔值
        *service            存储车辆运行方向
        *adtime             存储报站时间数据
        *str                报站数据记录格式
******************************************************************/

        private void ADTime_Click(object sender, EventArgs e)
        {
            string filepath = "Buscode_0507.txt";
            List<string> Buscode = IOTool.ReadText(filepath);
            for (int i = 0; i < Buscode.Count; i++)
            {
                int j = i;//第几个buscode，从0开始
                string filenamebusadtime = "BusAD_" + j + "_"+ Buscode[i] + ".txt";
                string getSQL = string.Empty;
                getSQL += "select * from BUSADINFO2013100822 t where LENGTH(BUSSTOPNUM) <> 0 and BUSCODE ='";
                getSQL += Buscode[i] + "'order by adtime";

                DataSet ds = ado163.ExecuteGet(getSQL, "BUSADINFO2013101622_COPY");//读入数据库内容存入缓存
                if (ds != null)
                {
                    int m = 0;//BusAD的第几条记录,从1开始
                    int adflagA = 0, adflagB;
                    int busstopnumA = 1, busstopnumB;
                    string begin = "00000" + " " + "0" + " " + "0" + " " + "0000/00/00 00:00:00";
                    IOTool.WriteFile(filenamebusadtime, begin);//保留首行，预防首条报站数据出错的情况

                    foreach (DataRow dr in ds.Tables[0].Rows)//遍历该表中的每一行
                    {
                        string routecode = Convert.ToString(dr["ROUTECODE"]);//内容对应转换
                        int busstopnum = Convert.ToInt32(dr["BUSSTOPNUM"]);
                        int adflag = Convert.ToInt32(dr["ADFLAGNUM"]);
                        string service = Convert.ToString(dr["SERVICE"]);
                        DateTime adtime = Convert.ToDateTime(dr["ADTIME"]);
                        string str = routecode + " " + busstopnum + " " + adflag + " " + adtime + " " + service;

/********************************************************************************************************
                        *报站数据的筛选和整理
                        *
                        *选择有出入站匹配的数据记录
                        *即某站必须有进站和出站数据才记录，缺一不可
                        *
                        *对同一时间段重复出入站数据筛选
                        *多条进站取第一条进站数据
                        *多条出站取最后一条出站数据
                        *
                        *分为十种情况，逐条筛选
                        *
                        *1、确保数据的第一条是正确且有效数据
                        *逐条读取，直到读取到第一个进站数据
                        *
                        *2、进出站连续（adflagB != adflagA）
                        *A进A出   A站停靠时间
                        *B进B出   B站停靠时间
                        *A出B进   AB站间运行时间
                        *A进B出   无效数据，需排除
                        *
                        * 
                        *变量解释：
                        *busadm          重新读取报站文件，取得m值   
                        *busadterror     当上一条数据出错需要删除的时候
                        *                重新读取报站数据并存入
                        *errorline       需删除数据的行数值
                        *busadreread     重置adflagA、busstopnumA的时候
                        *                重新读取删除后的报站数据
                        *rereadlastline  重新读取删除后的报站数据的最后一行内容
                        *busadtime       在写入前读取报站数据
                        *                重新读取报站数据并存入
                        *adcheck         需要对比的报站数据（判断记录是否重复）
                        *wstr            需要写入的报站数据记录
                        *lastline        计算时读取的上一条报站数据
                        *lastad          上一条报站数据时间（字符串格式）
                        *ladtime         上一条报站数据时间（DateTime格式）
                        *lservice        上一条报站数据方向
********************************************************************************************************/

                        if (m == 0)//确保数据的第一条是正确且有效数据，逐条读取，直到读取到第一个进站数据
                        {
                            if (adflag == 0)//第一条记录是进站记录
                            {
                                IOTool.WriteFile(filenamebusadtime, str);
                                List<string> busadm = IOTool.ReadText(filenamebusadtime);
                                m = busadm.Count - 1;
                                adflagA = adflag;
                                busstopnumA = busstopnum;
                            }
                            else//如果是出站，则忽略读取下一条，
                            {
                                m = 0;
                                continue;//回到Line72
                            }
                        }
                        else//不是第一条记录的情况下
                        {
                            adflagB = adflag;
                            busstopnumB = busstopnum;
                            
                            if (adflagB != adflagA)//进出站连续的情况
                            {
                                if (adflagB == 1 && busstopnumB != busstopnumA )//排除A进B出的情况，处理是删掉A，不记录B
                                {
                                    List<string> busadterror = IOTool.ReadText(filenamebusadtime);
                                    string errorline = Convert.ToString(busadterror.Count-1);
                                    IOTool.DeleteLine(filenamebusadtime, errorline);
                                    List<string> busadm = IOTool.ReadText(filenamebusadtime);
                                    m = busadm.Count - 1;

                                    if(m == 0)//如果是只有一条记录，删除了回到m=0
                                    {
                                        m = 0;
                                        continue;//回到Line72
                                    }

                                    List<string> busadreread = IOTool.ReadText(filenamebusadtime);//重新读取adflagA和busstopnumA
                                    string[] rereadlastline = busadreread[busadreread.Count-1].Split(' ');
                                    busstopnumA=Convert.ToInt32(rereadlastline[1]);
                                    adflagA=Convert.ToInt32(rereadlastline[2]);
                                    continue;//回到Line72
                                }
                                else//剩余3种情况，A进A出，B进B出，A出B进，非错误记录，判断是否重复，记录
                                {

                                    /*************写入数据段******************/
                                    List<string> busadtime = IOTool.ReadText(filenamebusadtime);
                                    bool bp = true;
                                    for (int k = 0; k < busadtime.Count; k++)
                                    {
                                        string[] adcheck = busadtime[k].Split(' ');
                                        string[] wstr = str.Split(' ');
                                        if (adcheck[4].Equals(wstr[4]) && adcheck[3].Equals(wstr[3]))//时间判断是否重复
                                        {
                                            bp = false;
                                            break;
                                        }
                                    }

                                    if (bp == true)//不重复记录
                                    {
                                        adflagA=adflagB;//更新判断标志
                                        busstopnumA=busstopnumB;
                                        IOTool.WriteFile(filenamebusadtime, str);
                                        List<string> busadm = IOTool.ReadText(filenamebusadtime);
                                        m = busadm.Count - 1;
                                        string buscode = Buscode[i];

                                        Calculation.Calculate(filenamebusadtime, m, str, buscode);
                                        continue;

                                    }
                                    /******************************************************************/
                                }
                            }
                            else//连续进站或者连续出站
                            {
                                if(busstopnumB==busstopnumA)//A进A进、A出A出、B进B进、B出B出
                                {
                                    if(adflagB==1)//情况A出A出，B出B出，取后者，删前一记录，记录后一数据
                                    {
                                        List<string> busadterror = IOTool.ReadText(filenamebusadtime);
                                        string errorline = Convert.ToString(busadterror.Count-1);
                                        IOTool.DeleteLine(filenamebusadtime, errorline);

                                        List<string> busadtime = IOTool.ReadText(filenamebusadtime);
                                        bool bp = true;
                                        for (int k = 0; k < busadtime.Count; k++)
                                        {
                                            string[] adcheck = busadtime[k].Split(' ');
                                            string[] wstr = str.Split(' ');
                                            if (adcheck[4].Equals(wstr[4]) && adcheck[3].Equals(wstr[3]))//如果已记录，则不再记录，若无，则记录
                                            {
                                                bp = false;
                                                break;
                                            }
                                        }
                                        if (bp == true)
                                        {
                                            adflagA=adflagB;
                                            busstopnumA=busstopnumB;
                                            IOTool.WriteFile(filenamebusadtime, str);
                                            List<string> busadm = IOTool.ReadText(filenamebusadtime);
                                            m = busadm.Count - 1;
                                            string buscode = Buscode[i];

                                            Calculation.Calculate(filenamebusadtime, m, str, buscode);
                                            continue;
                                        }
                                    }
                                    else //A进A进、B进B进,不记录
                                    {
                                        continue;
                                    }

                                }
                                else //A进B进、A出B出
                                {
                                    if (adflagB == 0 && busstopnumB != busstopnumA)//排除A进B进，删A进，留B进
                                    {
                                        List<string> busadterror = IOTool.ReadText(filenamebusadtime);
                                        string errorline = Convert.ToString(busadterror.Count - 1);
                                        IOTool.DeleteLine(filenamebusadtime, errorline);

                                        adflagA = adflagB;
                                        busstopnumA = busstopnumB;
                                        List<string> busadtime = IOTool.ReadText(filenamebusadtime);
                                        bool bp = true;
                                        for (int k = 0; k < busadtime.Count; k++)
                                        {
                                            string[] adcheck = busadtime[k].Split(' ');
                                            string[] wstr = str.Split(' ');
                                            if (adcheck[4].Equals(wstr[4]) && adcheck[3].Equals(wstr[3]))//如果已记录，则不再记录，若无，则记录
                                            {
                                                bp = false;
                                                break;
                                            }
                                        }
                                        if (bp == true)
                                        {
                                            IOTool.WriteFile(filenamebusadtime, str);
                                            List<string> busadm = IOTool.ReadText(filenamebusadtime);
                                            m = busadm.Count - 1;
                                            string buscode = Buscode[i];

                                            Calculation.Calculate(filenamebusadtime, m, str, buscode);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        continue;//A出B出，不记录B出
                                    }
                                }
                            }
                        }
                    }
                }
           }
           MessageBox.Show("OK!");
        }
    }
}
