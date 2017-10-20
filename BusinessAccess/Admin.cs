using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace BusinessAccess
{
    public class Admin
    {
        DbHandler objDbh = new DbHandler();

        public DataSet GetApproval()
        {
            return objDbh.SelectDataWithCondition("count(UserName) ApprovalCount,CustomerType",
                                                           "tbl_UserMaster", "Auth_Status='N' group by CustomerType");
        }

        public DataSet GetApprovalData(string pCustType)
        {
            if (pCustType.ToUpper() == "BUSSINESS")
            {
                return objDbh.SelectDataWithCondition("u.id Id,u.UserName Name, b.CompanyName CompanyName,b.BussinessType BussinessType,b.WebSite website",
                                                       "tbl_UserMaster u,tbl_Bussiness_User b,tbl_UserDetails ud",
                                                       "u.ID=b.ID and u.ID=ud.ID and ud.Approve_Status='N'");
            }
            else
            {
                return objDbh.SelectDataWithCondition("u.id Id,u.UserName Name,'DriverLicense' DriverLicense,'TransitInsurance' TransitInsurance,'CourierInsurance' CourierInsurance",
                                                      "tbl_UserMaster u,tbl_Driver_User d,tbl_UserDetails ud",
                                                      "u.ID=d.ID and u.ID=ud.ID and ud.Approve_Status='N'");
            }
        }

        public string Approve(int id, string userName)
        {
            List<DBParameters> objDbParam = new List<DBParameters>(){             
                    new DBParameters(){ParameterName="p_id",parameterType=DbType.Int32,Paramvalue=id}};
            return objDbh.InsertUsingStoreProc("sp_updateApproval", objDbParam);
            Sendnotification("Approvae", userName, "", id);
        }

        public string Reject(int pId, string userName, string pReason)
        {
            string rejectStatus = "";

            rejectStatus = objDbh.Update("Approve_Status='R',Date_Of_Approve='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "',Additional_Info='" + pReason + "'",
                                        "tbl_userDetails",
                                        "ID=" + pId);
            Sendnotification("Reject", userName, pReason, pId);
            return rejectStatus;
        }

        public string RequiredMoreInfo(int pId, string userName, string pAdditionalInfo)
        {
            string updStatus = "";
            updStatus = objDbh.Update("Approve_Status='M',Date_Of_Approve='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "',Additional_Info='" + pAdditionalInfo + "'",
                                        "tbl_userDetails",
                                        "ID=" + pId);
            Sendnotification("Additional Info", userName, pAdditionalInfo, pId);
            return updStatus;
        }

        public void RollBackStatus(int pId)
        {
            objDbh.Update("Approve_Status='N',Date_Of_Approve='',Additional_Info=''",
                                       "tbl_userDetails",
                                       "ID=" + pId);
        }

        public void Sendnotification(string pStatus, string userName, string pReason, int pId)
        {
            string messageBody = "";
            string subject = "";
            string redirectionUrl = "";
            SendMail objmail = new SendMail();
            try
            {

                DataSet ds = objDbh.SelectDataWithCondition("MsgBody,MsgSubject,redirectionUrl", "tbl_MailMessage", "status='" + pStatus.ToUpper() + "'");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    messageBody = ds.Tables[0].Rows[0]["MsgBody"].ToString();
                    subject = ds.Tables[0].Rows[0]["MsgSubject"].ToString();
                    redirectionUrl = ds.Tables[0].Rows[0]["redirectionUrl"].ToString();

                    if (pReason != "")
                    {
                        messageBody = messageBody + "<br/>" + pReason;
                    }

                    messageBody = messageBody + "Url:" + redirectionUrl;

                    objmail.SendEmail(userName, subject, messageBody);
                }
            }
            catch (Exception ex)
            {
                RollBackStatus(pId);
                throw ex;

            }
        }

        public string GetDriverImage(int id, string imageType)
        {
            string imageDtls = "";
            DataSet ds = null;

            if (imageType == "DL")
            {
                ds = objDbh.SelectDataWithCondition("Driver_License", "tbl_Driver_User", "ID=" + id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    imageDtls = ds.Tables[0].Rows[0]["Driver_License"].ToString();
                }

            }
            else if (imageType == "CI")
            {
                ds = objDbh.SelectDataWithCondition("Courier_Insurance", "tbl_Driver_User", "ID=" + id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    imageDtls = ds.Tables[0].Rows[0]["Courier_Insurance"].ToString();
                }
            }
            else
            {
                ds = objDbh.SelectDataWithCondition("Transit_Insurance", "tbl_Driver_User", "ID=" + id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    imageDtls = ds.Tables[0].Rows[0]["Transit_Insurance"].ToString();
                }
            }
            return imageDtls;
        }


    }
}
