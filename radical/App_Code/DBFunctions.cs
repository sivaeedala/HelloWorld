using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;
/// <summary>
/// Database connection
/// </summary>
public class DBFunctions 
{
    public DBFunctions()
    {
    }

    public string ConnectionString(string Server)
    {
        return ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;       
    }


    public int ExecuteSQL(string sql, string Server)
    {
        MySqlConnection sqlCN = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        try
        {
            //open connection
            sqlCN.Open();
            //execute query
            MySqlCommand sc = new MySqlCommand(sql, sqlCN);
            int counter = sc.ExecuteNonQuery();
            //close connection
            sqlCN.Close();
            return counter;
        }
        catch (MySqlException sqlExcp)
        {
            return 0;
        }
        finally
        {
            sqlCN.Dispose();
        }
    }

    public int PutData(string sql)
    {
        return ExecuteSQL(sql, "radicaldb");
    }

    public DataSet GetData(string sql, string Server)
    {
        DataSet DS = new DataSet();
        //connection settings
        MySqlConnection sqlCN = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        try
        {
            //open connection
            sqlCN.Open();
            //execute query
            MySqlCommand sc = new MySqlCommand(sql, sqlCN);
            sc.CommandTimeout = 60;
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(sc);
            sc.ExecuteNonQuery();
            sqlDA.Fill(DS);
            //close connection
            sqlCN.Close();
            return DS;
        }
        catch (MySqlException sqlExcp)
        {
            return DS;
        }
        finally
        {
            sqlCN.Dispose();
        }
    }


    public DataSet GetData_Try(string sql, DataSet  DS_Local)
    {
        DataSet DS = new DataSet();

        //connection settings
        MySqlConnection sqlCN = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        try
        {
            //open connection
            sqlCN.Open();

            //execute query
           // SqlCommand sc = new SqlCommand(sql, sqlCN);
            //sc.CommandTimeout = 60;

            MySqlDataAdapter sqlDA = new MySqlDataAdapter(sql, sqlCN);

            //sc.ExecuteNonQuery();

            sqlDA.Fill(DS);

            DS.Merge(DS_Local);
            DS.AcceptChanges();
           
            
            //close connection
            sqlCN.Close();

            return DS;
        }
        catch (MySqlException sqlExcp)
        {
            return DS;
        }
        finally
        {
            sqlCN.Dispose();
        }
    }

    public DataSet GetData(string sql)
    {
        return GetData(sql, "radicaldb");
    }

  

}
