using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccess;
using System.Data;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((LandingPage)Page.Master).lbName = Request.QueryString["Name"];
        if (!IsPostBack)
        {
            GetApprovalData();
            pnlBussinessGrid.Visible = false;
            pnlDriverGrid.Visible = false;
        }

    }

    BusinessAccess.Admin objAdminBal = new BusinessAccess.Admin();

    public void GetApprovalData()
    {
        BindBussinessData();
        BindDriverData();
    }

    public void BindBussinessData()
    {
        DataSet dsBussiness = objAdminBal.GetApprovalData("BUSSINESS");

        if (dsBussiness.Tables[0].Rows.Count > 0)
        {
            lblBussinessAppr.Text = dsBussiness.Tables[0].Rows.Count.ToString();
            grdvwBussiness.DataSource = dsBussiness.Tables[0];
            grdvwBussiness.DataBind();
        }
        else
        {
            lblBussinessAppr.Text = "NA";
            grdvwBussiness.DataSource = null;
            grdvwBussiness.DataBind();

        }
    }

    public void BindDriverData()
    {
        DataSet dsDriver = objAdminBal.GetApprovalData("DRIVER");

        if (dsDriver.Tables[0].Rows.Count > 0)
        {
            lblDriverAppr.Text = dsDriver.Tables[0].Rows.Count.ToString();
            grdvwDriver.DataSource = dsDriver.Tables[0];
            grdvwDriver.DataBind();
        }
        else
        {
            lblDriverAppr.Text = "NA";
            grdvwDriver.DataSource = null;
            grdvwDriver.DataBind();

        }
    }

    public void Clear()
    {
        txtpnlshwId.Text = "";
        txtpnlshwName.Text = "";
        txtReason.Text = "";
        txtStatus.Text = "";
        lblValidMsg.Text = "";

    }

    public void ShowImage(int pId, string imageType)
    {
        string imageDtls = "";
        imageDtls = objAdminBal.GetDriverImage(pId, imageType);

        if (imageDtls != "")
        {
            imgTest.ImageUrl = "~/upload/" + imageDtls;
        }

        popupImage.Show();

    }

    protected void grdvwBussiness_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());
        int id = Convert.ToInt32(grdvwBussiness.DataKeys[index].Values[0]);
        string name = grdvwBussiness.Rows[index].Cells[1].Text.ToString();

        Clear();

        if (e.CommandName == "Approve")
        {
            objAdminBal.Approve(id, name);
            BindBussinessData();
        }
        else if (e.CommandName == "Reject")
        {
            txtpnlshwId.Text = id.ToString();
            txtpnlshwName.Text = name;
            txtStatus.Text = "Reject";
            popup.Show();

            //objAdminBal.Reject(id, "xxxx");
        }
        else if (e.CommandName == "AdditionalInfo")
        {
            txtpnlshwId.Text = id.ToString();
            txtpnlshwName.Text = name;
            txtStatus.Text = "AdditionalInfo";
            popup.Show();
            //objAdminBal.RequiredMoreInfo(id, "xxxx");
        }
    }

    protected void grdvwDriver_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = 0;
        string name = "";

        if (e.CommandName == "DriverLicense")
        {

            GridViewRow gvrow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int rowIndex = gvrow.RowIndex;
            id = Convert.ToInt32(grdvwDriver.DataKeys[rowIndex].Values[0]);
            name = grdvwDriver.Rows[rowIndex].Cells[0].Text.ToString();
            ShowImage(id, "DL");
        }
        else if (e.CommandName == "TransitInsurance")
        {
            GridViewRow gvrow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int rowIndex = gvrow.RowIndex;
            id = Convert.ToInt32(grdvwDriver.DataKeys[rowIndex].Values[0]);
            name = grdvwDriver.Rows[rowIndex].Cells[0].Text.ToString();
            ShowImage(id, "TI");
        }
        else if (e.CommandName == "CourierInsurance")
        {
            GridViewRow gvrow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int rowIndex = gvrow.RowIndex;
            id = Convert.ToInt32(grdvwDriver.DataKeys[rowIndex].Values[0]);
            name = grdvwDriver.Rows[rowIndex].Cells[0].Text.ToString();
            ShowImage(id, "CI");
        }
        else
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            id = Convert.ToInt32(grdvwDriver.DataKeys[rowIndex].Values[0]);
            name = grdvwDriver.Rows[rowIndex].Cells[0].Text.ToString();
            Clear();

            if (e.CommandName == "Approve")
            {
                objAdminBal.Approve(id, name);
                BindDriverData();

            }
            else if (e.CommandName == "Reject")
            {
                txtpnlshwId.Text = id.ToString();
                txtpnlshwName.Text = name;
                txtStatus.Text = "Reject";
                popup.Show();
                //objAdminBal.Reject(id, "xxxx");
            }
            else if (e.CommandName == "AdditionalInfo")
            {
                txtpnlshwId.Text = id.ToString();
                txtpnlshwName.Text = name;
                txtStatus.Text = "AdditionalInfo";
                popup.Show();
                //objAdminBal.RequiredMoreInfo(id, "xxxx");
            }

        }


    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(txtpnlshwId.Text);

        if (txtReason.Text != "")
        {
            if (txtStatus.Text == "Reject")
            {
                objAdminBal.Reject(id, txtpnlshwName.Text, txtReason.Text);
            }
            else if (txtStatus.Text == "AdditionalInfo")
            {
                objAdminBal.RequiredMoreInfo(id, txtpnlshwName.Text, txtReason.Text);
            }
            GetApprovalData();
        }
        else
        {
            lblValidMsg.Text = "Please enter the Reason";
            txtReason.Focus();
            popup.Show();
        }
    }

    protected void lnkbtnBussiness_Click(object sender, EventArgs e)
    {
        pnlBussinessGrid.Visible = true;
        pnlDriverGrid.Visible = false;

    }
    protected void lnkbtnDriver_Click(object sender, EventArgs e)
    {
        pnlDriverGrid.Visible = true;
        pnlBussinessGrid.Visible = false;
    }
}