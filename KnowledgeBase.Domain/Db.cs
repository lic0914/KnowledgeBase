using Kb.Web;
using Microsoft.Extensions.Configuration;
using SqlSugar;

namespace KnowledgeBase.Domain
{
    public class Db
    {
        public static SqlSugarClient Context
        {
            get
            {
                return new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = GlobalConfiguration.Configuration.GetConnectionString("connStr"),
                    DbType = DbType.MySql,
                    InitKeyType = InitKeyType.SystemTable,//从特性读取主键和自增列信息
                    IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了
                   
                });
            }
        }
    }
}