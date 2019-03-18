using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.esriSystem;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;
using System.Collections;
using ESRI.ArcGIS.Carto;
using System.IO;
namespace CelixLib.EntObject
{
    public class PersonalGeodataBase
    {

        public DataTable ExecuteQuery(string selectSql)
        {
            try
            {
                if (string.IsNullOrEmpty(selectSql))
                {
                    return null;
                }

                OleDbDataAdapter oleDataAdapter = new OleDbDataAdapter(selectSql, Connection.DataSource.ConnectionString);

                DataTable dtQuery = new DataTable();
                oleDataAdapter.Fill(dtQuery);

                return dtQuery;
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行数据库查询时出现错误: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable ExecuteNonSpatialQuery(string strQuerySQL)
        {
            try
            {
                if (string.IsNullOrEmpty(Connection.DataSource.ConnectionString) || string.IsNullOrEmpty(strQuerySQL))
                {
                    return null;
                }

                OleDbDataAdapter oleDataAdapter = new OleDbDataAdapter(strQuerySQL, Connection.DataSource.ConnectionString);

                DataTable dtQuery = new DataTable();
                oleDataAdapter.Fill(dtQuery);

                return dtQuery;
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行数据库查询时出现错误: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ExecuteNonQuery(string commandSql)
        {
            try
            {
                OleDbConnection oleDbConnection = new OleDbConnection(Connection.DataSource.ConnectionString);
                OleDbCommand oleDbCommand = new OleDbCommand(commandSql, oleDbConnection);
                oleDbConnection.Open();
                oleDbCommand.ExecuteNonQuery();
                oleDbConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行数据库操作时出现错误: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }



        public void ExecuteSpatialInsert(IFeatureClass pFeatureClass, IGeometry geometry, string[] columnNames, object[] insertValues)
        {
            try
            {
                //创建一个插入的游标
                IFeatureCursor featureCursorInsert = pFeatureClass.Insert(true);

                //创建要插入的缓冲对象
                IFeatureBuffer featureBufferInsert = pFeatureClass.CreateFeatureBuffer();

                // 给Shape字段赋值
                featureBufferInsert.Shape = geometry;

                // 根据字段名称和值，给属性表赋值
                for (int columnCounter = 0; columnCounter < columnNames.Length; columnCounter++)
                {
                    string columnName = columnNames.GetValue(columnCounter).ToString();
                    int fieldPosition = featureBufferInsert.Fields.FindField(columnName);
                    object insertValue = insertValues.GetValue(columnCounter);
                    featureBufferInsert.set_Value(fieldPosition, insertValue);
                }

                //保存到数据库中，看是否要扩到try-catch中
                featureCursorInsert.InsertFeature(featureBufferInsert);
                featureCursorInsert.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存图形数据时出错: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public IWorkspace OpenWorkspace()
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
                IWorkspace pWorkspace = workspaceFactory.Open(Connection.DataSource.PropertySet, 0);//用的是从注册表里面读出的默认数据，在构造connection类的时候自动生成。

                return pWorkspace;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开数据库时出错: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        public ITable OpenTable(string tableName)
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
                IWorkspace pWorkspace = workspaceFactory.Open(Connection.DataSource.PropertySet, 0);
                IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;//注意openTable这个方法是在IFeatureWorkspace中的。
                ITable pTable = pFeatureWorkspace.OpenTable(tableName);

                return pTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开表格数据时出错: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        public IFeatureDataset OpenFeatureDataset(string featureDatasetName)
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
                IWorkspace pWorkspace = workspaceFactory.Open(Connection.DataSource.PropertySet, 0);
                IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(featureDatasetName);

                return pFeatureDataset;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开图形数据时出错: " + ex.Message, "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

    }
}
