using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();

            Foo foo = faker.Create<Foo>();
            Bar bar = faker.Create<Bar>();

            Console.Write("{0}\n", foo.GetString());
        }
    }
}
