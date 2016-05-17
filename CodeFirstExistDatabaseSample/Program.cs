using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExistDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.Write("Enter a name for a new Blog:");
                var name = Console.ReadLine();

                var blog = new Blogs { Name = name };
                db.Blogs.Add(blog);

                db.SaveChanges();

                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
                Console.WriteLine("All Blogs in the database");
                foreach(var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }

           
        }
    }
}
