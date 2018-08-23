using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using SqlSugar;

namespace KALAYUNITSM.DATA
{
    public class SugarBase : IBase
    {

        private readonly SqlSugar.DbType _dbType;
        private readonly string _connectionString;
        private SqlSugarClient _sqlSugarClient;
        public SqlSugar.DbType dbType
        {
            get { return _dbType; }
        }
        public string ConnectionString
        {
            get { return _connectionString; }
        }
        public SqlSugarClient SqlSugarClient
        {
            get { return _sqlSugarClient; }
        }
        public SugarBase(string connectionString, SqlSugar.DbType dbType = SqlSugar.DbType.SqlServer)
        {
            _dbType = dbType;
            _connectionString = connectionString;
            _sqlSugarClient = GetIntance(dbType);
        }
        public SqlSugarClient GetIntance(SqlSugar.DbType dbType, int commandTimeOut = 30, bool isAutoCloseConnection = false)
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = _connectionString,
                DbType = dbType,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = isAutoCloseConnection
            });
            db.Ado.CommandTimeOut = commandTimeOut;
            return db;
        }

        /// <summary>
        /// 资源释放
        /// </summary>

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
