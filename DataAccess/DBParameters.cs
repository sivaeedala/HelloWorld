using System.Data;
using MySql.Data;
using MySql.Data.Common;

namespace DataAccess
{
    public class DBParameters
    {
        public string ParameterName { get; set; }
        public DbType parameterType { get; set; }
        public int ParameterSize { get; set; }
        public object Paramvalue { get; set; }
    }
}
