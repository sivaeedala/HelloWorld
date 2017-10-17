using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace BusinessAccess
{
    public class RegistrationBL
    {
        public string ID { get; set; }
       // public string UserName { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }
        public string CustomerType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string MobileNo { get; set; }
        public string TelephoneNo { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public string CompanyName { get; set; }
        public string WebSite { get; set; }
        public string BussinessType { get; set; }

        public string DriverLicense { get; set; }
        public string CourierInsurance { get; set; }
        public string TransitInsurance { get; set; }

        public string siteUrl { get; set; }

        DataAccess.DbHandler objDb = null;
        Common objEncDec = new Common();

        //public void InsRegistration(Registration objRegistration)
        //{
        //    objDb = new DataAccess.DbHandler();


        //    string encPwd = Common.Encrypt(objRegistration.Password, Constants.encryptKey);

        //    if (objRegistration.CustomerType == "Bussiness")
        //    {
        //        objRegistration.AccessLevel = "B";
        //    }
        //    else if (objRegistration.CustomerType == "Driver")
        //    {
        //        objRegistration.AccessLevel = "D";
        //    }
        //    else
        //    {
        //        objRegistration.AccessLevel = "P";
        //    }

        //    List<DBParameters> objDbParam = new List<DBParameters>()
        //   {
        //       new DBParameters(){ParameterName="FirstName",parameterType=DbType.String,Paramvalue=objRegistration.FirstName},
        //       new DBParameters(){ParameterName="LastName",parameterType=DbType.String,Paramvalue=objRegistration.LastName},
        //       new DBParameters(){ParameterName="Email",parameterType=DbType.String,Paramvalue=objRegistration.Email},
        //       new DBParameters(){ParameterName="Pwd",parameterType=DbType.String,Paramvalue=encPwd},
        //       new DBParameters(){ParameterName="CustomerType",parameterType=DbType.String,Paramvalue=objRegistration.CustomerType},
        //       new DBParameters(){ParameterName="AccessLevel",parameterType=DbType.String,Paramvalue=objRegistration.AccessLevel},
        //       new DBParameters(){ParameterName="DOB",parameterType=DbType.Date,Paramvalue=objRegistration.DOB},
        //       new DBParameters(){ParameterName="Addr1",parameterType=DbType.String,Paramvalue=objRegistration.Addr1},
        //       new DBParameters(){ParameterName="Addr2",parameterType=DbType.String,Paramvalue=objRegistration.Addr2},
        //       new DBParameters(){ParameterName="MobileNo",parameterType=DbType.Int32,Paramvalue=objRegistration.MobileNo},
        //       new DBParameters(){ParameterName="TelephoneNo",parameterType=DbType.Int32,Paramvalue=objRegistration.TelephoneNo},
        //       new DBParameters(){ParameterName="Town",parameterType=DbType.String,Paramvalue=objRegistration.Town},
        //       new DBParameters(){ParameterName="County",parameterType=DbType.String,Paramvalue=objRegistration.County},
        //       new DBParameters(){ParameterName="Country",parameterType=DbType.String,Paramvalue=objRegistration.Country},
        //       new DBParameters(){ParameterName="PostCode",parameterType=DbType.Int32,Paramvalue=objRegistration.PostCode},
        //       new DBParameters(){ParameterName="CompanyName",parameterType=DbType.String,Paramvalue=objRegistration.CompanyName},
        //       new DBParameters(){ParameterName="WebSite",parameterType=DbType.String,Paramvalue=objRegistration.WebSite},
        //       new DBParameters(){ParameterName="BussinessType",parameterType=DbType.String,Paramvalue=objRegistration.BussinessType},
        //       new DBParameters(){ParameterName="DriverLicense",parameterType=DbType.String,Paramvalue=objRegistration.DriverLicense},
        //       new DBParameters(){ParameterName="CourierInsurance",parameterType=DbType.String,Paramvalue=objRegistration.CourierInsurance},
        //       new DBParameters(){ParameterName="TransitInsurance",parameterType=DbType.String,Paramvalue=objRegistration.TransitInsurance}
        //   };

        //    objDb.InsertUsingStoreProc("sp_InsertRegistration", objDbParam);
        //}

        public void RegistrationConfirmation(string url, string userName)
        {
            string encUserName = "";
            string newUrl = "";
            encUserName = Common.Encrypt(userName, Constants.encryptKey);
            newUrl = url + "/Default.aspx?id=" + encUserName;
        }

        public int InsRegistration()
        {
            objDb = new DataAccess.DbHandler();


            string encPwd = Common.Encrypt(Password, Constants.encryptKey);

            if (CustomerType == "Bussiness")
            {
                AccessLevel = "B";
            }
            else if (CustomerType == "Driver")
            {
                AccessLevel = "D";
            }
            else
            {
                AccessLevel = "P";
            }

            List<DBParameters> objDbParam = new List<DBParameters>()
           {
               new DBParameters(){ParameterName="FirstName",parameterType=DbType.String,Paramvalue=FirstName},
               new DBParameters(){ParameterName="LastName",parameterType=DbType.String,Paramvalue=LastName},
               new DBParameters(){ParameterName="Email",parameterType=DbType.String,Paramvalue=Email},
               new DBParameters(){ParameterName="Pwd",parameterType=DbType.String,Paramvalue=encPwd},
               new DBParameters(){ParameterName="CustomerType",parameterType=DbType.String,Paramvalue=CustomerType},
               new DBParameters(){ParameterName="AccessLevel",parameterType=DbType.String,Paramvalue=AccessLevel},
               new DBParameters(){ParameterName="DOB",parameterType=DbType.Date,Paramvalue=DOB},
               new DBParameters(){ParameterName="Addr1",parameterType=DbType.String,Paramvalue=Addr1},
               new DBParameters(){ParameterName="Addr2",parameterType=DbType.String,Paramvalue=Addr2},
               new DBParameters(){ParameterName="MobileNo",parameterType=DbType.String,Paramvalue=MobileNo},
               new DBParameters(){ParameterName="TelephoneNo",parameterType=DbType.String,Paramvalue=TelephoneNo},
               new DBParameters(){ParameterName="Town",parameterType=DbType.String,Paramvalue=Town},
               new DBParameters(){ParameterName="County",parameterType=DbType.String,Paramvalue=County},
               new DBParameters(){ParameterName="Country",parameterType=DbType.String,Paramvalue=Country},
               new DBParameters(){ParameterName="PostCode",parameterType=DbType.String,Paramvalue=PostCode},
               new DBParameters(){ParameterName="CompanyName",parameterType=DbType.String,Paramvalue=CompanyName},
               new DBParameters(){ParameterName="WebSite",parameterType=DbType.String,Paramvalue=WebSite},
               new DBParameters(){ParameterName="BussinessType",parameterType=DbType.String,Paramvalue=BussinessType},
               new DBParameters(){ParameterName="DriverLicense",parameterType=DbType.String,Paramvalue=DriverLicense},
               new DBParameters(){ParameterName="CourierInsurance",parameterType=DbType.String,Paramvalue=CourierInsurance},
               new DBParameters(){ParameterName="TransitInsurance",parameterType=DbType.String,Paramvalue=TransitInsurance}
           };

            try
            {
                return objDb.InsertUsingStoreProc("sp_InsertRegistration", objDbParam);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}
