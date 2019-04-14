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

            // create a list of users to process
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });


            // find all users with the password "hello" and output to the stream
            stream.WriteLine("-= Users with password \"hello\" =-");
            users
                .Where(x => "hello".Equals(x.Password))
                .ToList()
                .ForEach(stream.WriteLine);

            stream.WriteLine();

            // remove any users where the password is the lowercase-case of the name
            stream.WriteLine("-= Remove users with password lowercase of the name =-");
            var count = users.RemoveAll(x => x.Name.ToLower().Equals(x.Password));
            stream.WriteLine(count);

            stream.WriteLine();

            // remove first user with the password "hello"
            stream.WriteLine("-= Remove users with password lowercase of the name =-");
            var user = users.FirstOrDefault(x => "hello".Equals(x.Password));
            stream.WriteLine(users.Remove(user));

            stream.WriteLine();

            // display remaining users
            users.ForEach(x => stream.WriteLine($"User: {x.Name} ; Password: {x.Password}"));

            stream.WriteLine();
        }
    }
}
