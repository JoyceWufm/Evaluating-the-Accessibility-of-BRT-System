using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Bus_Stop
{
    class Calculation
    {
        public static void Calculate(string filenamebusadtime, int m, string str, string buscode)
        {
            /****************计算数据段**************************/
            if (m > 1)
            {
                List<string> busadreread = IOTool.ReadText(filenamebusadtime);

                string lstline = busadreread[busadreread.Count - 2];
                string[] lastline = busadreread[busadreread.Count - 2].Split(' ');
                string lastad = lastline[3] + " " + lastline[4];
                DateTime ladtime = Convert.ToDateTime(lastad);
                string lservice = Convert.ToString(lastline[5]);
                int lstopnum = Convert.ToInt32(lastline[1]);
                int ladflag = Convert.ToInt32(lastline[2]);

                string[] adcontent = busadreread[busadreread.Count - 1].Split(' ');
                string contentad = adcontent[3] + " " + adcontent[4];
                DateTime cadtime = Convert.ToDateTime(contentad);
                string cservice = Convert.ToString(adcontent[5]);
                int cstopnum = Convert.ToInt32(adcontent[1]);
                int cadflag = Convert.ToInt32(adcontent[2]);

                TimeSpan DeltaT = cadtime - ladtime;
                int DeltaStop = Math.Abs(lstopnum - cstopnum);

                if (lservice.Equals(cservice) && adcontent[0].Equals(lastline[0]))//判断是否同向且是否同线路，如果不同向，则两个数据无法计算
                {
                    /*****************全数据分析*************************************/
                    if (DeltaStop == 0 && ladflag < cadflag && DeltaT.TotalSeconds < 700)//A进A出、B进B出的情况
                    {
                        string filenamewt = "Stopwaittime_" + lastline[1] + "_" + cservice + ".txt";
                        string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                        IOTool.WriteFile(filenamewt, strd);
                    }
                    else if (DeltaStop == 1 && DeltaT.TotalSeconds < 1000)
                    {
                        string filename3 = "Stopruntime_" + lastline[1] + "_" + cstopnum + ".txt";
                        string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                        IOTool.WriteFile(filename3, strd);
                    }
                    /****************************************************************/

                    /*****************时间段分析*************************************/
                    if (DeltaStop == 0 && ladflag < cadflag && DeltaT.TotalSeconds < 700)//A进A出、B进B出的情况
                    {
                        if (cadtime.Hour > 6 && cadtime.Hour < 9)
                        {
                            string filenamewt = "Stopwaittime_" + "time_" + "7-9am_" + lastline[1] + "_" + cservice + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else if (cadtime.Hour > 16 && cadtime.Hour < 19)
                        {
                            string filenamewt = "Stopwaittime_" + "time_" + "5-7pm_" + lastline[1] + "_" + cservice + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else
                        {
                            string filenamewt = "Stopwaittime_" + "time_" + "other_" + lastline[1] + "_" + cservice + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                    }
                    else if (DeltaStop == 1 && ladflag > cadflag && DeltaT.TotalSeconds < 1000)
                    {
                        if (cadtime.Hour > 6 && cadtime.Hour < 9)
                        {
                            string filenamewt = "Stopruntime_" + "time_" + "7-9am_" + lastline[1] + "_" + cstopnum + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else if (cadtime.Hour > 16 && cadtime.Hour < 19)
                        {
                            string filenamewt = "Stopruntime_" + "time_" + "5-7pm_" + lastline[1] + "_" + cstopnum + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else
                        {
                            string filenamewt = "Stopruntime_" + "time_" + "other_" + lastline[1] + "_" + cstopnum + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                    }
                    /****************************************************************/

                    /*****************线路分析***************************************/

                    if (DeltaStop == 0 && ladflag < cadflag && DeltaT.TotalSeconds < 700)//A进A出、B进B出的情况
                    {
                        string filenamewt = "Stopwaittime_" + "route_" + adcontent[0] + "_" + lastline[1] + "_" + cservice + ".txt";
                        string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                        IOTool.WriteFile(filenamewt, strd);
                    }
                    else if (DeltaStop == 1 && DeltaT.TotalSeconds < 1000)
                    {
                        string filename3 = "Stopruntime_" + "route_" + adcontent[0] + "_" + lastline[1] + "_" + cstopnum + ".txt";
                        string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                        IOTool.WriteFile(filename3, strd);
                    }

                    /****************************************************************/

                    /*****************线路时间分析***************************************/

                    if (DeltaStop == 0 && ladflag < cadflag && DeltaT.TotalSeconds < 700)//A进A出、B进B出的情况
                    {
                        if (cadtime.Hour > 6 && cadtime.Hour < 9)
                        {
                            string filenamewt = "Stopwaittime_" + "route_" + adcontent[0] + "_time_" + "7-9am_" + lastline[1] + "_" + cservice + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else if (cadtime.Hour > 16 && cadtime.Hour < 19)
                        {
                            string filenamewt = "Stopwaittime_" + "route_" + adcontent[0] + "_time_" + "5-7pm_" + lastline[1] + "_" + cservice + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else
                        {
                            string filenamewt = "Stopwaittime_" + "route_" + adcontent[0] + "_time_" + "other_" + lastline[1] + "_" + cservice + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                    }
                    else if (DeltaStop == 1 && DeltaT.TotalSeconds < 1000)
                    {
                        if (cadtime.Hour > 6 && cadtime.Hour < 9)
                        {
                            string filenamewt = "Stopruntime_" + "route_" + adcontent[0] + "_time_" + "7-9am_" + lastline[1] + "_" + cstopnum + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else if (cadtime.Hour > 16 && cadtime.Hour < 19)
                        {
                            string filenamewt = "Stopruntime_" + "route_" + adcontent[0] + "_time_" + "5-7pm_" + lastline[1] + "_" + cstopnum + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                        else
                        {
                            string filenamewt = "Stopruntime_" + "route_" + adcontent[0] + "_time_" + "other_" + lastline[1] + "_" + cstopnum + ".txt";
                            string strd = adcontent[0] + " " + lastline[1] + "," + cstopnum + " " + lastline[2] + cadflag + " " + DeltaT.TotalSeconds + "    " + lstline + "    " + str + "    " + buscode;//记录的格式，转换为字符串，可以再加个cservice
                            IOTool.WriteFile(filenamewt, strd);
                        }
                    }

                    /****************************************************************/

                }
            }
            /******************************************************************/
        }

    }
}
