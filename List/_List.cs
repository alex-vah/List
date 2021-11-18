using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class _List
    {
        private const int _defaultCapacity = 4;

        private int[] _items;
        private int _size;
        private int _version;

        static readonly int[] _emptyArray = new int[0];

        public _List()
        {
            _items = _emptyArray;
        }

        public _List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (capacity == 0)
            {
                _items = _emptyArray;
            }
            else
            {
                _items = new int[capacity];
            }
        }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        int[] newItems = new int[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }
        public int Count
        {
            get
            {
                return _size;
            }
        }
        public int this[int index]
        {
            get
            {
                if (index >= _size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return _items[index];
            }
            set
            {
                if (index >= _size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _items[index] = value;
                _version++;
            }
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity;
                if (_items.Length == 0)
                {
                    newCapacity = _defaultCapacity;
                }
                else
                {
                    newCapacity = _items.Length * 2;
                }
                if (newCapacity > 0X7FEFFFFF)
                {
                    newCapacity = 0X7FEFFFFF;
                }
                if (newCapacity < min)
                {
                    newCapacity = min;
                }
                Capacity = newCapacity;

            }
        }

        public void Add(int item)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = item;
            _version++;
        }
        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
            _version++;
        }
        public bool Contains(int item)
        {
            if (item == (int)default)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_items[i] == (int)default)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    if (int.Equals(_items[i], item))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public void CopyTo(int[] array)
        {
            CopyTo(array, 0);
        }
        public void CopyTo(int[] array, int index)
        {
            Array.Copy(_items, 0, array, index, _size);
        }
        public int IndexOf(int item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }
        public int IndexOf(int item, int index)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Array.IndexOf(_items, item, index, _size - index);
        }
        public int IndexOf(int item, int index, int count)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (count < 0 || index > _size - count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Array.IndexOf(_items, item, index, count);
        }
        public void Insert(int index, int item)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
            _version++;
        }
        public bool Remove(int item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(int);
            _version++;
        }
        public void RemoveRange(int index,int count)
        {
            if(index<0)
            {
                throw new ArgumentOutOfRangeException();
                
            }
            if(count<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(_size-index<count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(count>0)
            {
                int i = _size;
                _size = _size - count;
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }
                Array.Clear(_items, _size, count);
                _version++;
            }
        }
    }
}
