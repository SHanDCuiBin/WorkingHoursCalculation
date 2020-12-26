using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkingHoursCalculation.Helpers
{
    /// <summary>    
    /// 数据访问抽象基础类(ACCESS)    
    /// Copyright (C) 2006-2007 hovertree.net 
    /// All rights reserved    
    /// </summary>    
    public abstract class DbHelperOleDb
    {
        //数据库连接字符串(App.config来配置)    
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Application.StartupPath + "\\Data\\Data.accdb" + "';Jet OLEDB:Database Password=123456;";
        public DbHelperOleDb()
        {
        }

        /// <summary>
        /// 判断链接是否成功
        /// </summary>
        /// <returns></returns>
        public static bool IsSeccess()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, Dictionary<string, object> dic)
        {

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        List<OleDbParameter> cmdParms = new List<OleDbParameter>();
                        foreach (string item in dic.Keys)
                        {
                            cmdParms.Add(new OleDbParameter(item, dic[item]));
                        }
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms.ToArray());
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public static bool ExecuteSqlTran(Dictionary<string, Dictionary<string, object>> SqlList)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    try
                    {
                        //循环
                        foreach (string myDE in SqlList.Keys)
                        {
                            string cmdText = myDE.ToString();
                            OleDbParameter[] cmdParms = DictionaryToFbParameter(SqlList[myDE]);
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 将  字典类型  转换为   FbParameter[]类型数据
        /// </summary>
        /// <param name="dic">字典类型数组</param>
        /// <returns></returns>
        private static OleDbParameter[] DictionaryToFbParameter(Dictionary<string, object> dic)
        {
            List<OleDbParameter> cmdParmsList = new List<OleDbParameter>();
            foreach (string item in dic.Keys)
            {
                cmdParmsList.Add(new OleDbParameter(item, dic[item]));
            }
            return cmdParmsList.ToArray();
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回OleDbDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OleDbDataReader</returns>
        public OleDbDataReader ExecuteReader(string SQLString, params OleDbParameter[] cmdParms)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OleDbDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, Dictionary<string, object> dic)
        {
            List<OleDbParameter> cmdParms = new List<OleDbParameter>();
            foreach (string item in dic.Keys)
            {
                cmdParms.Add(new OleDbParameter(item, dic[item]));
            }
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms.ToArray());
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        public static bool Exists(string strSql, Dictionary<string, object> dic)
        {
            List<OleDbParameter> cmdParms = new List<OleDbParameter>();
            foreach (string item in dic.Keys)
            {
                cmdParms.Add(new OleDbParameter(item, dic[item]));
            }
            object obj = GetSingle(strSql, cmdParms.ToArray());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion
        /// <summary>
        /// 获取相应的SQL 字符串
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <param name="tableName">表格</param>
        /// <param name="flag">标记0 修改语句   1添加语句</param>
        /// <param name="where">条件</param>
        /// <returns>生成的SQL语句</returns>
        public static String sqlString(DataRow dr, String tableName, int flag, String where)
        {

            string updstr = "";
            //update
            if (flag == 0)
            {
                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    //if (!dr.Table.Columns[j].ColumnName.Contains("zl_"))
                    //{

                    if (dr.Table.Columns[j].ColumnName != "id" && dr.Table.Columns[j].ColumnName != "user_id" && dr.Table.Columns[j].ColumnName != "dah")
                    {

                        if (dr[j].ToString().Trim() != "" && dr[j].ToString().Trim() != "0001-00-00 00:00:00:000")
                        {
                            if (dr.Table.Columns[j].DataType.ToString() == "System.String" || dr.Table.Columns[j].DataType.ToString() == "System.DateTime")
                            {
                                updstr += "[" + dr.Table.Columns[j].ColumnName + "]='" + dr[j].ToString().Trim() + "',";

                            }
                            if (dr.Table.Columns[j].DataType.ToString() == "System.Single" || dr.Table.Columns[j].DataType.ToString() == "System.Int32" || dr.Table.Columns[j].DataType.ToString() == "System.Int16" || dr.Table.Columns[j].DataType.ToString() == "System.Double")
                            {
                                updstr += "[" + dr.Table.Columns[j].ColumnName + "]=" + dr[j].ToString().Trim() + ",";
                            }

                        }
                    }

                    //}
                }

                if (updstr != "" && where != null && where != "")
                {
                    updstr = "update " + tableName + " set " + updstr.Remove(updstr.Length - 1) + " where  1=1 " + where;
                }

            }

            //Insert            
            if (flag == 1)
            {
                String columnName = "";
                String result = "";

                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    if (dr[j].ToString().Trim() != "")
                    {


                        if (dr.Table.Columns[j].DataType.ToString() == "System.String" || dr.Table.Columns[j].DataType.ToString() == "System.DateTime")
                        {
                            columnName += "[" + dr.Table.Columns[j].ColumnName + "],";
                            result += "'" + dr[j].ToString().Trim() + "',";
                        }
                        if (dr.Table.Columns[j].DataType.ToString() == "System.Single" || dr.Table.Columns[j].DataType.ToString() == "System.Int32" || dr.Table.Columns[j].DataType.ToString() == "System.Int16" || dr.Table.Columns[j].DataType.ToString() == "System.Double")
                        {
                            columnName += "[" + dr.Table.Columns[j].ColumnName + "],";
                            result += dr[j].ToString().Trim() + ",";
                        }

                    }
                }

                if (columnName != "")
                {
                    updstr = "insert into " + tableName + "( " + columnName.Substring(0, columnName.Length - 1) + ") values( " + result.Substring(0, result.Length - 1) + ")";
                }
            }

            return updstr;
        }


    }
}
