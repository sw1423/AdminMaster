using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CreateClass
    {
        public CreateClass()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Data Source=10.32.129.9;database=AS400;User=sa;Password=user123;",
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });
        }
        public SqlSugarClient Db { get; }
        public void CreateEntityClass()
        {
            Db.DbFirst.IsCreateDefaultValue(true).IsCreateAttribute(true).CreateClassFile("E:\\Demo\\1", "BusinessEntities");
        }
    }
}
