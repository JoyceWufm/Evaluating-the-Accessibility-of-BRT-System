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
                MessageBox.Show("ִ�����ݿ��ѯʱ���ִ���: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("ִ�����ݿ��ѯʱ���ִ���: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("ִ�����ݿ����ʱ���ִ���: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }



        public void ExecuteSpatialInsert(IFeatureClass pFeatureClass, IGeometry geometry, string[] columnNames, object[] insertValues)
        {
            try
            {
                //����һ��������α�
                IFeatureCursor featureCursorInsert = pFeatureClass.Insert(true);

                //����Ҫ����Ļ������
                IFeatureBuffer featureBufferInsert = pFeatureClass.CreateFeatureBuffer();

                // ��Shape�ֶθ�ֵ
                featureBufferInsert.Shape = geometry;

                // �����ֶ����ƺ�ֵ�������Ա�ֵ
                for (int columnCounter = 0; columnCounter < columnNames.Length; columnCounter++)
                {
                    string columnName = columnNames.GetValue(columnCounter).ToString();
                    int fieldPosition = featureBufferInsert.Fields.FindField(columnName);
                    object insertValue = insertValues.GetValue(columnCounter);
                    featureBufferInsert.set_Value(fieldPosition, insertValue);
                }

                //���浽���ݿ��У����Ƿ�Ҫ����try-catch��
                featureCursorInsert.InsertFeature(featureBufferInsert);
                featureCursorInsert.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ͼ������ʱ����: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public IWorkspace OpenWorkspace()
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
                IWorkspace pWorkspace = workspaceFactory.Open(Connection.DataSource.PropertySet, 0);//�õ��Ǵ�ע������������Ĭ�����ݣ��ڹ���connection���ʱ���Զ����ɡ�

                return pWorkspace;
            }
            catch (Exception ex)
            {
                MessageBox.Show("�����ݿ�ʱ����: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        public ITable OpenTable(string tableName)
        {
            try
            {
                IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
                IWorkspace pWorkspace = workspaceFactory.Open(Connection.DataSource.PropertySet, 0);
                IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;//ע��openTable�����������IFeatureWorkspace�еġ�
                ITable pTable = pFeatureWorkspace.OpenTable(tableName);

                return pTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("�򿪱������ʱ����: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("��ͼ������ʱ����: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

    }
}
