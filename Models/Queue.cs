using System;
using System.Collections.Generic;

namespace QueueApp.Models
{
    public class Queue<T>
    {
        private readonly System.Collections.Generic.Queue<T> _queue = new System.Collections.Generic.Queue<T>();

        public int Count => _queue.Count;
        public bool IsEmpty => _queue.Count == 0;

        public void Enqueue(T item)
        {
            _queue.Enqueue(item); 
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста.");
            return _queue.Dequeue();
        }

        public void Clear()
        {
            _queue.Clear(); 
        }

        public IEnumerable<T> GetElements()
        {
            return _queue.ToArray();
        }
    }
}