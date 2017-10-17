using System;
using System.Linq;
using System.Data;
using BusinessAccess;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        Authenticate objAuthBL = new Authenticate();
        Common objComBL = new Common();
        string strUserName = string.Empty;
         
        string strAuthorize = objAuthBL.Authorize(tx_user.Text.Trim(), tx_password.Text.Trim());
        if(strAuthorize !="A")
        {
            DataSet dsUserDet = objComBL.FetchDetails("FirstName", "tbl_userdetails", "Email='" + tx_user.Text.Trim() +"'");
            if (dsUserDet.Tables[0].Rows.Count > 0)
                strUserName = dsUserDet.Tables[0].Rows[0]["FirstName"].ToString();
        }

        switch (strAuthorize)
        {
            case "A":
                Session["username"] = "Admin";
                Response.Redirect("Admin.aspx?Name=Admin");
                break;
            case "B":
                Session["username"] = strUserName;
                Response.Redirect("Business.aspx?Name=" + strUserName);
                break;
            case "D":
                Session["username"] = strUserName;
                Response.Redirect("Driver.aspx?Name="+ strUserName);
                break;
            case "P":
                Session["username"] = strUserName;
                Response.Redirect("Personal.aspx?Name=" + strUserName);
                break;
            case "PF": 
                lb_reg_result.Text = "User Name and Password mismatch";
                System.Diagnostics.Debug.WriteLine("User Name and Password mismatch");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                break;
            case "UF":
                lb_reg_result.Text = "You dont have an valid account";
                System.Diagnostics.Debug.WriteLine("You dont have an valid account");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                break;
        } 
    }

    protected void btn_PasswordRecovery_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPassword();", true);
    }
}