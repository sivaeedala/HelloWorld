using System.Data;
using DataAccess;

namespace BusinessAccess
{
    public class Authenticate
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool AuthenticateStatus { get; set; }
        public string AccessLevel { get; set; }

        DbHandler objDb = new DbHandler();

        public bool Login(ref Authenticate objAuth)
        {
            string encPwd = "", decPwd = "", accessLvl = "";
            DataSet objDs = objDb.SelectDataWithCondition("Password,AccessLevel,CustomerType",
                                                          "tbl_usermaster",
                                                          "UserName='" + objAuth.UserName + "' and Auth_Status = 'Y'");

            if (objDs.Tables[0].Rows.Count > 0)
            {
                encPwd = objDs.Tables[0].Rows[0]["Password"].ToString();
                decPwd = Common.Decrypt(encPwd, Constants.encryptKey);
                if (objAuth.Password == decPwd)
                {
                    accessLvl = objDs.Tables[0].Rows[0]["accessLevel"].ToString();
                    switch (accessLvl)
                    {
                        case "A":
                            objAuth.AccessLevel = "ADMIN";
                            break;
                        case "B":
                            objAuth.AccessLevel = "BUSSINESS";
                            break;
                        case "D":
                            objAuth.AccessLevel = "DRIVER";
                            break;
                        case "P":
                            objAuth.AccessLevel = "PERSONAL";
                            break;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string Authorize(string UserName, string Pwd)
        {
            string AccessLevel = "F";
            DataSet objDs = objDb.SelectDataWithCondition("Password,AccessLevel,CustomerType",
                                                          "tbl_usermaster",
                                                          "UserName='" + UserName + "' and Auth_Status = 'Y'");
            if (objDs.Tables[0].Rows.Count > 0)
            {
                string encPwd = objDs.Tables[0].Rows[0]["Password"].ToString();  
                if (Pwd == Common.Decrypt(encPwd, Constants.encryptKey))
                {
                    return AccessLevel = objDs.Tables[0].Rows[0]["accessLevel"].ToString();
                }
                else
                {
                    return AccessLevel = "PF";
                } 
            }
            else
                return AccessLevel = "UF";
        }

    }
}
