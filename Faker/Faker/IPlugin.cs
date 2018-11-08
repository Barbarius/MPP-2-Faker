using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public interface IPlugin : IValueGenerator
    {
        Type GeneratedType { get; }
    }
}
