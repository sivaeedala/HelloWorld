using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Newtonsoft.Json;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://radical.ponnuswamy.co.uk/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
    DBFunctions db = new DBFunctions();
    public string domainName = "http://radical.ponnuswamy.co.uk";
    public string shopName = "Radical Courier Services";
    public WebService () {
        
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //For VB.NET and WebSite -- menu, submenu
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetMenuOnly() {
        DataSet ds = new DataSet();
        ds = db.GetData("SELECT * from login;");
        string json = JsonConvert.SerializeObject(ds);

        //JsonObjectAttribute js = new JsonObjectAttribute();
        //js.isValidLogin = true;
        //return json;
        HttpContext.Current.Response.Write(json);
    }

    //For VB.NET and WebSite -- menu, submenu
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void GetLoginuser()
    {
        DataSet ds = new DataSet();
        ds = db.GetData("SELECT username from login;");
        string json = JsonConvert.SerializeObject(ds);

        //JsonObjectAttribute js = new JsonObjectAttribute();
        //js.isValidLogin = true;
        //return json;
        HttpContext.Current.Response.Write(json);
    }


    //For VB.NET and WebSite -- submenu
    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public void GetLogin(string username, string password)
    {
        bool isValidLogin = false;
        DataSet ds = new DataSet();
        //ds = db.GetData("SELECT menu.*, level.MenuId, level.Name, level.Cost from menu join level on menu.id=level.MenuId;");
        ds = db.GetData("Select * From radicaldb.login where username='" + username + "' and password='" + password + "';");
        if (ds.Tables[0].Rows.Count > 0)
        {
            isValidLogin =  true;
        }
        else
        {
            isValidLogin = false;
        }
        //   ds.AcceptChanges();
        //return ds;//
        string json = JsonConvert.SerializeObject(ds);

        //JsonObjectAttribute js = new JsonObjectAttribute();
        //js.isValidLogin = true;
        //return json;
        HttpContext.Current.Response.Write(json);
    }


   


    //Get all data for Website
    //Not for VB.NET
    //[WebMethod]
    //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    //public string GetData_Web(){
    //    DataSet ds = new DataSet();
    //    ds = db.GetData("select * from Persons;");
    //    string json = JsonConvert.SerializeObject(ds);
    //    return json;
    //}



}
