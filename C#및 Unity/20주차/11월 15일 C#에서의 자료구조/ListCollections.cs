using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomCollections
{
    public class List<T>
    {
        const int defaultCapacity = 4;
        T[] items;
        int size = 0;
        public int Capacity { get { return items.Length; } }
        public int Count { get { return size; } }

        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public List()
        {
            items = new T[defaultCapacity];
        }

        //Ư���� ���ǿ� �����ϴ� ������ �ε�����
        //�������� �Լ�.
        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (match(items[i]))
                    return i;
            }
            throw new Exception();
        }

        public void Add(T item)
        {
            if (size >= items.Length)
                Grow();

            items[size] = item;
            size++;
        }

        public int indexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
            size--;
        }

        public void Remove(T item)
        {
            int index = indexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void Clear()
        {
            items = new T[defaultCapacity];
            size = 0;
        }

        public void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];

            Array.Copy(items, 0, newItems, 0, size);
            /*
            for(int i=0;i<items.Length;i++)
            {
                newItems[i] = items[i];
            }
            */
            items = newItems;
        }
    }

    // C#������ Stack�� Queue�� �迭 ����̴�.
    public class Stack<T>
    {
        const int defaultCapacity = 4;
        T[] array;
        int size = 0;

        public Stack()
        {
            array = new T[defaultCapacity];
        }

        public void Clear()
        {
            array = new T[defaultCapacity];
            size = 0;
        }

        public void Push(T item)
        {
            if (IsFull())
                Grow();

            array[size] = item;
            size++;
        }

        public T Pop()
        {
            size--;
            return array[size];
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
        public bool IsFull()
        {
            return size == array.Length;
        }

        public T Peek()
        {
            return array[size];
        }

        public bool TryPop(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }
            else
            {
                result = array[size];
                return true;
            }
        }

        public void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];
            Array.Copy(array, 0, newArray, 0, size);
            array = newArray;
        }
    }

    public class Queue<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int head;
        private int tail;

        public Queue()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
        }
        public int Count
        {
            get
            {
                if (head <= tail)
                    return tail - head;
                else
                    return tail + (array.Length - head);
            }
        }
        private bool IsFull()
        {
            if (head > tail)
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;
            }
        }

        private bool IsEmpty()
        {
            return head == tail;
        }

        public void Clear()
        {
            array = new T[DefaultCapacity];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Grow();
            }

            array[tail] = item;
            MoveNext(ref tail);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[head];
        }
        private void Grow()
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];

            if (head < tail)
            {
                Array.Copy(array, head, newArray, 0, tail);
            }
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }

            array = newArray;
            tail = Count;
            head = 0;
        }
        private void MoveNext(ref int index)
        {
            index = (index == array.Length - 1) ? 0 : index + 1;
        }
    }
}

    public class ListCollections : MonoBehaviour
    {
        // C#������ �ݷ���
        // C#������ List�� C++������ Vector�̴�.
        // List�� Ư¡ : �������� �߰� ������ �����Ӵ�. ���� �� ũ�⸦ �������� �ʴ´�.
        // Array�� Ư¡ : ���� �� ����� ������ �̸� �Ҵ��Ѵ�. �ε����� ��� ������ ���ٿ� ������. �������� ũ�⸦ �������� ���Ѵ�.
        // List<T> �����迭 : ũ�Ⱑ ���� �� �ִ� �迭
        // Array   �����迭 : ũ�Ⱑ ������ �ʴ� �迭

        List<int> list;

        public bool IsUpperThanTen(int value)
        {
            return value > 10;
        }
        void Start()
        {
            list = new List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(50);
            list.Add(60);

            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log(list[i]);
            }

            Debug.Log(list.FindIndex((int value) => { return value == 50; }));
        }
    }
