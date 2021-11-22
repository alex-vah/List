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
            _List<int> _list = new _List<int>();
            _list.Add(0);
            _list.Add(1);
            _list.Add(2);

            _list.Add(26);
            foreach(int item in _list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
