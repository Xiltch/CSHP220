using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeworkTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            // capture a stream to be used for outputting the results to
            TextWriter stream = Console.Out;

            // Create a list of users to process
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            // Finds all users with the password "hello" and outputs them to the console
            users
                .Where(x => "hello".Equals(x.Password))
                .ToList()
                .ForEach(stream.WriteLine);

        }
    }
}
