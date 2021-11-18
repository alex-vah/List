using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            _List _list = new _List();
            _list.Add(0);
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(4);
            _list.Add(5);
            _list.Add(6);
            _list.Add(7);
            _list.Add(8);
            _list.Add(9);
            _list.Add(10);
            _list.Add(11);
            var res =_list.IndexOf(10);
            _list.Remove(5);
            _list.RemoveRange(2,1);
            _list.Insert(4, 11);
        }
    }
}
