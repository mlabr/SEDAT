using DataLayer.Entities.CodeList;
using DataLayer.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Business.Handlers
{
	public class DbHandler
	{
        string connectionString = "";
        public DbHandler(string dbFile)
        {
            connectionString = dbFile;
        }

        public void CreateSqliteDatabase()
        {
            var helper = new DbHelper();
            helper.CreateDatabase(connectionString);
		}
    }
}
