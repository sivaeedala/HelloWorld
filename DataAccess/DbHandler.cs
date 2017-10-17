using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class DbHandler
    {
        private string conStr = ConfigurationManager.ConnectionStrings["RadicalConStr"].ConnectionString;

        public static bool Value = true;

        public string selectQry = "", ins = "", upd = "", delQry = "", del = "";
 

        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        public int GetCount(string Tabname, string Condition)
        {
            int count = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    selectQry = "select count(*) from " + Tabname + " where " + Condition;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = selectQry;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        count = Convert.ToInt32(dr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }

        #region selRec With Condition

        public DataSet SelectDataWithCondition(string param, string tabName, string condition)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    selectQry = "select " + param + " from " + tabName + " where " + condition;
                    da = new SqlDataAdapter(selectQry, con);
                    ds = new DataSet();
                    da.Fill(ds, "Table");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        #endregion

        #region SelRec WithOut Condition

        public DataSet SelectDataWithOutCondition(string param, string tabName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    selectQry = "select " + param + " from " + tabName;
                    da = new SqlDataAdapter(selectQry, con);
                    ds = new DataSet();
                    da.Fill(ds, "Table");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        #endregion

        #region Update

        public string Update(string param, string tabName, string condition)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update " + tabName + " set " + param + " where " + condition;
                    cmd.ExecuteNonQuery();
                    upd = "SUC";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return upd;
        }

        #endregion

        #region Delete

        public string Delete(string tabName, string condition)
        {
            string del = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete " + tabName + " where " + condition;
                    cmd.ExecuteNonQuery();
                    del = "SUC";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return del;
        }
        #endregion

        /// <summary>
        /// 
        /// Generic method that executes storedprocedure with parameters
        /// </summary>
        /// <param name="pSpname">StoredProcedure</param>
        /// <param name="objDbParams">List of StoreProcParameters object</param>

        public int InsertUsingStoreProc(string pSpname, List<DBParameters> objDbParams)
        {
            int cnt = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = pSpname;
                        foreach (DBParameters dbParm in objDbParams)
                        {
                            cmd.Parameters.AddWithValue(dbParm.ParameterName, dbParm.Paramvalue);
                        }
                        cnt = cmd.ExecuteNonQuery();
                    }
                }
                return cnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
