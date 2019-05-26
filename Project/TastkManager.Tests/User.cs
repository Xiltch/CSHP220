using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastkManager.Tests
{
    public class User : IUser
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

    }
}
