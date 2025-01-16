using DataLayer.DataResources;
using DataLayer.Entities;
using DataLayer.Entities.CodeList;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using DataLayer.Repositories.CodeListRepository;
using SQLite;
using SQLitePCL;
using System.Diagnostics;
using System.Globalization;

namespace DataLayer
{
    internal class Program
	{

		

		

		static void Main(string[] args)
		{
			var helper = new DbHelper();
			//var wr = new WeaponRepository("testDb.db");
			//var rr = new MunitionRepository();


			//rr.Get(1);
			//var isfdhsh = rr.Get(1);


			//wr.Get();
			//var tttt = wr.Get(1);


			//db creation
			string DbPath = helper.ConnectionString;

			





			//var timer = new Stopwatch();
			//ICodeRepository<CCaliber> repo = new CCaliberRepository();
			//timer.Start();

			//var item = repo.Get(3);

			//var ls = repo.GetAllList();

			//var ls2 = repo.GetUsedOnlyList();

			//var t1 = timer.Elapsed;

			//ICodeRepository<CDiscipline> rep2 = new CDisciplineRepository();
			//var ls3 = rep2.GetAllList();

			//var t2 = timer.Elapsed;

			//var rr = new MunitionRepository();


			////rr.Get(1);
			//var isfdhsh = rr.Get(1);

			//var t3 = timer.Elapsed;

		}


	}
}
