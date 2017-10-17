using DataAccess;
using System.Data;

namespace BusinessAccess
{
    public class Common
    {
        DbHandler objDb = new DbHandler();
        private const string Alpha = "ABCDEFGHIJKLMNOPQRSTUVXZWYabcdefghijklmnopqrstuvxzwy0123456789:";


        public static string Encrypt(string plainText, string passKey)
        {
            int Counter = 0;
            int plainTextLength = plainText.Length;
            int WhereM = 0;
            int WhereP = 0;
            string CountM = "";
            string CountP = "";

            int CounterP = 0;
            int WhereE = 0;
            int MAX = Alpha.Length;
            string RString = "";
            // loops over message
            for (Counter = 1; Counter <= plainTextLength; Counter++)
            {
                CountM = plainText.Substring(0, 1);
                plainText = plainText.Substring(1);
                CountP = passKey.Substring(CounterP, 1);
                CounterP += 1;
                // resets passwd count
                if (CounterP >= passKey.Length)
                {
                    CounterP = 0;
                }
                WhereM = Alpha.IndexOf(CountM) + 1;
                WhereP = Alpha.IndexOf(CountP) + 1;
                // strange? just copy it!
                if (WhereM == 0 | WhereP == 0)
                {
                    RString = RString + CountM;
                }
                else
                {
                    WhereE = WhereM + WhereP;
                    // get encoded char
                    if (WhereE > MAX)
                    {
                        WhereE = WhereE - MAX;
                    }
                    WhereE -= 1;
                    RString = RString + Alpha.Substring(WhereE, 1);
                    // stack to return it
                }
            }
            return RString;
        }

        public static string Decrypt(string encryptText, string passKey)
        {
            int Counter = 0;
            int encryptTextLength = encryptText.Length;
            int WhereM = 0;
            int WhereP = 0;
            string CountM = "";
            string CountP = "";
            int CounterP = 0;
            int WhereE = 0;
            int MAX = Alpha.Length;
            string RString = "";
            for (Counter = 1; Counter <= encryptTextLength; Counter++)
            {
                CountM = encryptText.Substring(0, 1);
                encryptText = encryptText.Substring(1);
                CountP = passKey.Substring(CounterP, 1);
                CounterP += 1;
                if (CounterP >= passKey.Length)
                {
                    CounterP = 0;
                }
                WhereM = Alpha.IndexOf(CountM) + 1;
                WhereP = Alpha.IndexOf(CountP) + 1;
                if (WhereM == 0 | WhereP == 0)
                {
                    RString = RString + CountM;
                }
                else
                {
                    WhereE = WhereM - WhereP;
                    if (WhereE <= 0)
                    {
                        WhereE = MAX - (WhereE * (-1));
                    }
                    WhereE -= 1;
                    RString = RString + Alpha.Substring(WhereE, 1);
                }
            }
            return RString;
        }

        public DataSet FetchDetails(string columns, string tblName, string condition)
        {
            DataSet objDs = objDb.SelectDataWithCondition(columns, tblName, condition);
            return objDs;
        }
    } 
}

