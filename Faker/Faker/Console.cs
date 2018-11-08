using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class Console
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();

            Foo foo = faker.Create<Foo>();
            Bar bar = faker.Create<Bar>();

            /*ResultWriter newWriter = new ResultWriter();
            JSONSerializer newSerializer = new JSONSerializer();

            newWriter.write(newSerializer.serialize(foo));
            Console.Write("\n\n\n");

            newWriter.write(newSerializer.serialize(bar));
            Console.ReadLine();*/
        }
    }
}
