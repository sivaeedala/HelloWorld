using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;
using BusinessAccess;
using System.IO;

public partial class Registration : System.Web.UI.Page
{
    private bool invalid;

    RegistrationBL objRegBL = new RegistrationBL();

    public bool IsValidEmail(string strIn)
    {
        invalid = false;
        if (String.IsNullOrEmpty(strIn))
            return false;

        // Use IdnMapping class to convert Unicode domain names.
        try
        {
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }

        if (invalid)
            return false;

        // Return true if strIn is in valid e-mail format.
        try
        {
            return Regex.IsMatch(strIn,
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                  RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private string DomainMapper(Match match)
    {
        // IdnMapping class with default property values.
        IdnMapping idn = new IdnMapping();
        string domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            invalid = true;
        }
        return match.Groups[1].Value + domainName;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        id_company.Visible = false;
        id_driver.Visible = false;
        id_status.Visible = false;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Form["account"] != null)
        {
            string selectedGender = Request.Form["account"].ToString();
            Response.Write(selectedGender);
        }
    }

    public bool ValidateAllInput()
    {
        //return true if all success
        int ret = 0;
        bool retValue = false;
        if (!IsValidEmail(tx_email.Text))
        {
            tx_email.BorderColor = System.Drawing.Color.Red;//"#FF3300";
            tx_email.Focus();
            ret++;
        }
        else
        {
            tx_email.BorderColor = System.Drawing.Color.Green;
        }
        //First Name
        if (tx_fname.Text.Trim().ToString().Length <= 0)
        {
            tx_fname.BorderColor = System.Drawing.Color.Red;
            tx_fname.Focus();
            ret++;
        }
        else
        {
            tx_fname.BorderColor = System.Drawing.Color.Green;
        }

        //Last name
        if (tx_lname.Text.Trim().ToString().Length <= 0)
        {
            tx_lname.BorderColor = System.Drawing.Color.Red;
            tx_lname.Focus();
            ret++;
        }
        else
        {
            tx_lname.BorderColor = System.Drawing.Color.Green;
        }
        //Password
        if (tx_password.Text.Trim().ToString().Length <= 0)
        {
            tx_password.BorderColor = System.Drawing.Color.Red;
            tx_confirmpassword.BorderColor = System.Drawing.Color.Red;
            tx_password.Focus();
            ret++;
        }
        else
        {

            //if password is validated
            string pwd = tx_password.Text.Trim().ToString();
            string confpwd = tx_confirmpassword.Text.Trim().ToString();
            if (pwd.Equals(confpwd))
            {
                tx_password.BorderColor = System.Drawing.Color.Green;
                tx_confirmpassword.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                tx_password.BorderColor = System.Drawing.Color.Red;
                tx_confirmpassword.BorderColor = System.Drawing.Color.Red;
                ret++;
            }
        }

        //mobile
        if (tx_mobile.Text.Trim().ToString().Length <= 0)
        {
            tx_mobile.BorderColor = System.Drawing.Color.Red;
            tx_mobile.Focus();
            ret++;
        }
        else
        {
            tx_mobile.BorderColor = System.Drawing.Color.Green;
        }

        //add1
        if (tx_addr1.Text.Trim().ToString().Length <= 0)
        {
            tx_addr1.BorderColor = System.Drawing.Color.Red;
            tx_addr1.Focus();
            ret++;
        }
        else
        {
            tx_addr1.BorderColor = System.Drawing.Color.Green;
        }
        //add2
        if (tx_addr2.Text.Trim().ToString().Length <= 0)
        {
            tx_addr2.BorderColor = System.Drawing.Color.Red;
            tx_addr2.Focus();
            ret++;
        }
        else
        {
            tx_addr2.BorderColor = System.Drawing.Color.Green;
        }
        //town
        if (tx_town.Text.Trim().ToString().Length <= 0)
        {
            tx_town.BorderColor = System.Drawing.Color.Red;
            tx_town.Focus();
            ret++;
        }
        else
        {
            tx_town.BorderColor = System.Drawing.Color.Green;
        }
        //county
        if (tx_county.Text.Trim().ToString().Length <= 0)
        {
            tx_county.BorderColor = System.Drawing.Color.Red;
            tx_county.Focus();
            ret++;
        }
        else
        {
            tx_county.BorderColor = System.Drawing.Color.Green;
        }
        //country
        if (tx_country.Text.Trim().ToString().Length <= 0)
        {
            tx_country.BorderColor = System.Drawing.Color.Red;
            tx_country.Focus();
            ret++;
        }
        else
        {
            tx_country.BorderColor = System.Drawing.Color.Green;
        }
        //postcode
        if (tx_postcode.Text.Trim().ToString().Length <= 0)
        {
            tx_postcode.BorderColor = System.Drawing.Color.Red;
            tx_postcode.Focus();
            ret++;
        }
        else
        {
            tx_postcode.BorderColor = System.Drawing.Color.Green;
        }
        //------------ Courier Company Details.
        if (rb_company.Checked)
        {
            //company name
            if (tx_companyname.Text.Trim().ToString().Length <= 0)
            {
                tx_companyname.BorderColor = System.Drawing.Color.Red;
                tx_companyname.Focus();
                ret++;
            }
            else
            {
                tx_companyname.BorderColor = System.Drawing.Color.Green;
            }
            //Website
            if (tx_website.Text.Trim().ToString().Length <= 0)
            {
                tx_website.BorderColor = System.Drawing.Color.Red;
                tx_website.Focus();
                ret++;
            }
            else
            {
                tx_website.BorderColor = System.Drawing.Color.Green;
            }
            //Business Type
            if (tx_businesstype.Text.Trim().ToString().Length <= 0)
            {
                tx_businesstype.BorderColor = System.Drawing.Color.Red;
                tx_businesstype.Focus();
                ret++;
            }
            else
            {
                tx_businesstype.BorderColor = System.Drawing.Color.Green;
            }
        }

        if (rb_driver.Checked)
        {
            //Driving Lic Photocopy			
            if (fu_driverlicence.HasFile)
            {
                fu_driverlicence.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                fu_driverlicence.BorderColor = System.Drawing.Color.Red;
                ret++;
                fu_driverlicence.Focus();
            }
            //Courier Insurance Photocopy			
            if (fu_courierinsurance.HasFile)
            {
                fu_courierinsurance.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                fu_courierinsurance.BorderColor = System.Drawing.Color.Red;
                ret++;
                fu_courierinsurance.Focus();
            }
            if(fu_driverlicence.PostedFile.ContentLength> 2100000)
            {
                lb_reg_result.Text = "Size of File uploaded must be 2MB or less";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                System.Diagnostics.Debug.WriteLine("");
                ret++;
                fu_driverlicence.BorderColor = System.Drawing.Color.Red;
                fu_driverlicence.Focus();
            }
            if (fu_courierinsurance.PostedFile.ContentLength > 2100000)
            {
                lb_reg_result.Text = "Size of File uploaded must be 2MB or less";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                System.Diagnostics.Debug.WriteLine("");
                ret++;
                fu_courierinsurance.BorderColor = System.Drawing.Color.Red;
                fu_courierinsurance.Focus();
            }

        }
        if (ret > 0)
        {
            retValue = false;
            ret = 0;
        }
        else
        {
            retValue = true;
            ret = 0;
        }

        return retValue;
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        int result = 0;
        string AccessLev = string.Empty;
        Common objComBL = new Common();
        
        DataSet ds = new DataSet();
        string emailstr = tx_email.Text.Trim();
        string strDLDet = string.Empty;
        string strTIDet = string.Empty;
        string strCIDet = string.Empty;

        /*Validate all the input*/
        if (ValidateAllInput())
        {
            ds = objComBL.FetchDetails("username", "tbl_usermaster", "UserName ='" + emailstr + "'");
            if (ds.Tables[0].Rows.Count >= 1)
            {
                lb_reg_result.Text = "User already exist";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                System.Diagnostics.Debug.WriteLine("User Already Exist");
            }
            else
            { 
                try
                {
                    bool isComp = rb_company.Checked;
                    bool isPer = rb_personal.Checked;
                    bool isDriv = rb_driver.Checked;
                    string CustType = string.Empty;
                    DateTime dtDOB = DateTime.Parse(tx_dob.Text.Trim());
                    if (isComp)
                    {
                        CustType = "Bussiness";
                        AccessLev = "B";
                    }
                    else if (isPer)
                    {
                        CustType = "Personal";
                        AccessLev = "P";
                    }
                    else
                    {
                        CustType = "Driver";
                        AccessLev = "D";  
                        strDLDet = emailstr + "_DL_" + Path.GetFileName(fu_driverlicence.FileName);
                        strCIDet = emailstr + "_CI_" + Path.GetFileName(fu_courierinsurance.FileName);
                        if (fu_goodsintransit.HasFile)
                            strTIDet = emailstr + "_TI_" + Path.GetFileName(fu_goodsintransit.FileName);
                    }

                    objRegBL.FirstName = tx_fname.Text.Trim();
                    objRegBL.LastName = tx_lname.Text.Trim();
                    objRegBL.Email = tx_email.Text.Trim();
                    objRegBL.Password = tx_password.Text.Trim();
                    objRegBL.CustomerType = CustType;
                    objRegBL.AccessLevel = AccessLev;
                    objRegBL.DOB = dtDOB;
                    objRegBL.Addr1 = tx_addr1.Text.Trim();
                    objRegBL.Addr2 = tx_addr2.Text.Trim();
                    objRegBL.MobileNo = tx_mobile.Text.Trim();
                    objRegBL.TelephoneNo = tx_telephone.Text.Trim();
                    objRegBL.Town = tx_town.Text.Trim();
                    objRegBL.County = tx_county.Text.Trim();
                    objRegBL.Country = tx_country.Text.Trim();
                    objRegBL.PostCode = tx_postcode.Text.Trim();
                    objRegBL.CompanyName = tx_companyname.Text.Trim();
                    objRegBL.WebSite = tx_website.Text.Trim();
                    objRegBL.BussinessType = tx_businesstype.Text.Trim();
                    objRegBL.DriverLicense = strDLDet;
                    objRegBL.CourierInsurance = strCIDet;
                    objRegBL.TransitInsurance = strTIDet;

                    result = objRegBL.InsRegistration();
                }
                catch (Exception ex)
                {
                    lb_reg_result.Text = "Profile status: Your profile wasn't created. The following error occured: " + ex.Message;
                }

                if (result > 0)
                {
                    if(AccessLev =="D")
                    {
                        try
                        {
                            fu_driverlicence.PostedFile.SaveAs(Server.MapPath("~/upload/") + strDLDet);
                            fu_courierinsurance.PostedFile.SaveAs(Server.MapPath("~/upload/") + strCIDet);
                            if (fu_goodsintransit.HasFile)
                                fu_goodsintransit.PostedFile.SaveAs(Server.MapPath("~/upload/") + strTIDet);
                        }
                        catch (Exception ex)
                        {
                            lb_reg_result.Text = "Document Upload: We were not able to upload your document. The following error occured:" + ex.Message;
                        }
                    }
                    if (AccessLev == "P")
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        lb_reg_result.Text = "Your account been created and an activation link has been sent to the Mail ID you'd entered. You must activate the account by selecting the activation link in the mail you received before you can login!";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        System.Diagnostics.Debug.WriteLine("Your account been created and an activation link has been sent to the Mail ID you'd entered. You must activate the account by selecting the activation link in the mail you received before you can login");
                    }
                }
            }
        }
    } 

    protected void rb_personal_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_personal.Checked)
        {
            id_company.Visible = false;
            id_driver.Visible = false;
        }
    }

    protected void rb_company_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_company.Checked)
        {
            id_driver.Visible = false;
            id_company.Visible = true;
        }
    }

    protected void rb_driver_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_driver.Checked)
        {
            id_company.Visible = false;
            id_driver.Visible = true;
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
    }
}