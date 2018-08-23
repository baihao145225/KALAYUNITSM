using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using SqlSugar;

namespace KALAYUNITSM.DATA
{
    public class SqlSugarDBConfig
    {
        public static string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IBase db { get; set; }
        public SqlSugarDBConfig()
        {
            db = new SugarBase(_connectionString);
        }
    }
}