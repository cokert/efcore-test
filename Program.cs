using System;
using System.Linq;

namespace efcore_test
{
    class Program
    {
        static Guid guid1 = new Guid("e9c95ae5-9516-45ad-aa48-fcd32db65ed4");
        static void Main(string[] args)
        {
            TestContext context = new TestContext();
            
            var contents = context.TestTables.ToList();
            if (contents.Count() == 0) {
                for (int i = 0; i < 5; i++)
                {
                    TestTable tbl = new TestTable();
                    tbl.KeyColumn1 = Guid.NewGuid();   
                    tbl.OtherColumn2 = guid1;
                    context.Add(tbl);
                }
                context.SaveChanges();
            }

            PrintSqlAndRun(context.TestTables.Where(x => guid1.CompareTo(x.OtherColumn2) == 0));
            PrintSqlAndRun(context.TestTables.Where(x => guid1 == x.OtherColumn2));            
        }

        static void PrintSqlAndRun<T>(IQueryable<T> query) where T : class {
            //Console.WriteLine(query.ToSql().sql);
            query.ToList();
        }
    }
}
