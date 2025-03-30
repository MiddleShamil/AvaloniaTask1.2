using System;
using System.Collections.Generic;

namespace QueueApp.Models
{
    public class Queue<T>
    {
        private readonly System.Collections.Generic.Queue<T> _queue = new System.Collections.Generic.Queue<T>();

        // Свойства
        public int Count => _queue.Count; // Количество элементов
        public bool IsEmpty => _queue.Count == 0; // Признак пустоты очереди

        // Методы
        public void Enqueue(T item)
        {
            _queue.Enqueue(item); // Добавление элемента в конец очереди
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста.");
            return _queue.Dequeue(); // Извлечение элемента с начала очереди
        }

        public void Clear()
        {
            _queue.Clear(); // Очистка очереди
        }

        // Новый метод: Получение элементов очереди
        public IEnumerable<T> GetElements()
        {
            return _queue.ToArray(); // Возвращаем копию элементов очереди
        }
    }
}