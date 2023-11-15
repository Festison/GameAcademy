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

        //특정한 조건에 만족하는 원소의 인덱스를
        //가져오는 함수.
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

    // C#에서는 Stack과 Queue가 배열 기반이다.
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
        // C#에서의 콜렉션
        // C#에서의 List는 C++에서의 Vector이다.
        // List의 특징 : 데이터의 추가 삭제가 자유롭다. 생성 시 크기를 지정하지 않는다.
        // Array의 특징 : 생성 시 사용할 공간을 미리 할당한다. 인덱스를 사용 데이터 접근에 빠르다. 데이터의 크기를 변경하지 못한다.
        // List<T> 가변배열 : 크기가 변할 수 있는 배열
        // Array   정적배열 : 크기가 변하지 않는 배열

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
