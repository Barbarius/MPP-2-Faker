using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    interface IGenericGenerator
    {
        object Generate(Type baseType);
    }
}
