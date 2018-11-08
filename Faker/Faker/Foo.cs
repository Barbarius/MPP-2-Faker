using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class Foo
    {
        //private object _object;

        private char _char;

        private bool _bool;

        private byte _byte;

        private sbyte _sbyte;

        //private int _int;

        private uint _uint;

        private short _short;

        private ushort _ushort;

        private long _long;

        private ulong _ulong;

        private decimal _decimal;

        private float _float;

        private double _double;

        private DateTime _date;

        private string _string;

        private List<short> _list;

        private Bar _bar;

        /*public object GetObject()
        {
            return _object;
        }*/

        public char GetChar()
        {
            return _char;
        }

        public bool GetBool()
        {
            return _bool;
        }

        public byte GetByte()
        {
            return _byte;
        }

        public sbyte GetSByte()
        {
            return _sbyte;
        }

        /*public int GetInt()
        {
            return _int;
        }*/

        public uint GetUInt()
        {
            return _uint;
        }

        public short GetShort()
        {
            return _short;
        }

        public ushort GetUShort()
        {
            return _ushort;
        }

        public long GetLong()
        {
            return _long;
        }

        public ulong GetULong()
        {
            return _ulong;
        }

        public decimal GetDecimal()
        {
            return _decimal;
        }

        public float GetFloat()
        {
            return _float;
        }

        public double GetDouble()
        {
            return _double;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public string GetString()
        {
            return _string;
        }

        public List<short> GetList()
        {
            return _list;
        }

        public Bar GetBar()
        {
            return _bar;
        }

        public Foo(/*object o,*/ char c, bool b, byte by, sbyte sby, /*int i,*/ uint ui, short s, ushort us, long l, ulong ul,
            decimal d, float f, double dob, DateTime dt, string str, List<short> list, Bar bar)
        {
            //_object = o;
            _char = c;
            _bool = b;
            _byte = by;
            _sbyte = sby;
            //_int = i;
            _uint = ui;
            _short = s;
            _ushort = us;
            _long = l;
            _ulong = ul;
            _decimal = d;
            _float = f;
            _double = dob;
            _date = dt;
            _list = list;
            _bar = bar;
        }
    }
}
