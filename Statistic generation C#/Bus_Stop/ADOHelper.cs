using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Bus_Stop
{
    /// <summary>
    /// Summary description for ADOHelper.
    /// </summary>
    public class ADOHelper
    {
        OleDbConnection conn;
        static String m_ConnectionString;
        //构造函数创建OleDbConnection对象
        public ADOHelper()
        {
            conn = new OleDbConnection(ADOHelper.ConnectionString());
        }
        //重载函数创建OleDbConnection对象
        public ADOHelper(string connectionStr)
        {
            m_ConnectionString = connectionStr;
            conn = new OleDbConnection(m_ConnectionString);
        }
        //DataSet获取数据库数据
        public DataSet ExecuteGet(string cmd, string tbname)
        {
            this.CheckConnection();   //检查与数据源的连接状态,开启连接
            DataSet dataSet = new DataSet();
            try
            {
                OleDbCommand dataCommand = new OleDbCommand(cmd, conn);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = dataCommand;
                dataAdapter.Fill(dataSet, tbname);
            }
            catch (SqlException se)
            {
                throw new Exception("Error in SQL", se);
            }
            this.Dispose();
            return dataSet;
        }
        //快速读取数据
        public OleDbDataReader ExecuteRead(String cmd)
        {
            this.CheckConnection(); //检查与数据源的连接状态,开启连接
            OleDbDataReader dr = null;
            try
            {
                OleDbCommand dc = new OleDbCommand(cmd, conn);
                dr = dc.ExecuteReader();
                //return dr;
            }
            catch(SqlException se)
            {
                //	ErrorLog el = new ErrorLog(se);
            }
            this.Dispose();
            return dr;
        }
        //更新数据，插入数据
        public void ExecuteUpdate(string cmd)
        {
            this.CheckConnection(); //检查与数据源的连接状态,开启连接
            try
            {
                OleDbCommand dc = new OleDbCommand(cmd, conn);
                dc.ExecuteNonQuery();  
            }
            catch (SqlException se)
            {
                //ErrorLog el = new ErrorLog(se);
            }
            this.Dispose();
            return;
        }

        //检查与数据源的连接状态
        public void CheckConnection()    
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

            }
            catch (SqlException se)
            {
                throw new Exception("Failed to Open connection.", se);
            }
        }

        public static String ConnectionString()
        {
            if (m_ConnectionString == null)
            {
                string connectionString = "Provider=MSDAORA;data source=bus;user id=manage_bus;password=its312";
                m_ConnectionString = connectionString;
                if (m_ConnectionString == null)
                {
                    throw new Exception("Connect string value not set in Web.config");
                }
            }
            return m_ConnectionString;
        }
        //关闭连接
        public void Dispose()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                //con = null;
            }
            catch (Exception e)
            {
                //ErrorLog el = new ErrorLog(e);

            }
        }
    }
}
