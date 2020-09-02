using BusinessEntities;
using SqlSugar;
using System.Linq;

namespace DataAccessLayer
{
    public class DbContext
    {       
        /// <summary>
        /// 修改后的代码
        /// </summary>
        /// <returns></returns>
        public static DbContext OpDB()
        {
            DbContext dbcontext_t = new DbContext
            {
                Db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "Data Source=10.32.129.9;database=AS400;User=sa;Password=user123;pooling=true",
                    DbType = SqlSugar.DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                })
            };
            return dbcontext_t;
        }

        protected DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Data Source=10.32.129.9;database=AS400;User=sa;Password=user123;",
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });
            Db.Aop.OnLogExecuting = (sql, pars) =>
              {
                  System.Console.WriteLine(sql + "\r\n" + Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
              };
        }
        public SqlSugarClient Db { get; private set; }
        public SimpleClient<inv_inventory_collect> CurrentDb { get { return new SimpleClient<inv_inventory_collect>(Db); } }
    }
}
