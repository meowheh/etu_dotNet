using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    //класс элемента списка
    public class ListNode<T>
    {
        public ListNode(T data)
        {
            Data = data;
        }
        public T           Data { get; set; }
        public ListNode<T> Next { get; set; }
    }
    //класс связного списка
    //наследуемся от интерфейса перечисления
    public class List<T> : IEnumerable<T>
    {
        private ListNode<T> _first;       //первый элемент
        private ListNode<T> _last;        //последний элемент
        private int         count;        //количество элементов
        
        //добавление элемента в конец списка
        public void Add(T data)
        {
            var node = new ListNode<T>(data);
            if (_first != null)
            {
                _last.Next = node;
            }
            else
            {
                _first = node;
            }
            _last = node;
            count++;
        }
        //добавление элемента в начало списка
        public void AddFirst(T data)
        {
            ListNode<T> node = new ListNode<T>(data) {Next = _first};
            _first = node;
            if (count == 0)
                _last = _first;
            count++;
        }
        //добавление элемента в произвольную позицию 
        public void insert(int pos, T data)
        {
            if(pos == 0)
                AddFirst(data);
            else if(pos == count)
                Add(data);
            else if (pos > 0 && pos < count)
            {
                var previous = _first;
                for (var i = 0; i < pos - 1; i++)
                    previous = previous.Next;
                var next = previous.Next;
                var node = new ListNode<T>(data) {Next = next};
                previous.Next = node;
                count++;
            }
        }
        //удалить первый элемент
        public bool RemoveFirst()
        {
            if (_first != null)
            {
                _first = _first.Next;
                if (_first == null)
                    _last = null;
                count--;
                return true;
            }
            return false;
        }
        //удалить последний элемент
        public bool RemoveLast()
        {
            var previous = _first;
            if (previous != null)
            {
                while (previous.Next != _last)
                {
                    previous = previous.Next;
                }
                previous.Next = null;
                _last = previous;
                count--;
                return true;
            }
            return false;
        }
        //удаление элемента из списка по индексу
        public bool Remove(int index)
        {
            if (index >= count || index < 0)
                return false;
            if (index == count - 1)
                RemoveLast();
            else if (index == 0)
                RemoveFirst();
            else
            {
                var previous = _first;
                for (var i = 0; i < index - 1; i++)
                {
                    previous = previous.Next;
                }
                var current = previous.Next;
                var next = current.Next;
                previous.Next = next;
                current.Next = null;
                count--;
                return true;
            }
            return false;
        }
        public void Reverse()
        {
            ListNode<T> current  = _first,
                        previous = null;
            while (current != null)
            {
                var next = current.Next;
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            _last = _first;
            _first = previous;
            

        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        
        
        
    }
}