using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class Bar
    {
        public object _object;

        public char _char;

        public bool _bool;

        public byte _byte;

        public sbyte _sbyte;

        public int _int;

        public uint _uint;

        public short _short;

        public ushort _ushort;

        public long _long;

        public ulong _ulong;

        public decimal _decimal;

        public float _float;

        public double _double;

        public DateTime _date;

        public string _string; 

        public List<short> _list;

        public void Output()
        {
            Console.Write("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n{11}\n{12}\n{13}\n{14}\n{15}\n{16}\n", _object, _char,
                            _bool, _byte, _sbyte, _int, _uint, _short, _ushort, _long, _ulong, _decimal, _float, _double, _date, _string, _list);
        }
    }
}
