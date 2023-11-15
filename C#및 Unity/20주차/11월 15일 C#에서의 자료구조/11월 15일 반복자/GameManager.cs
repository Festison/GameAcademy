using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;


namespace CustomCollections
{
    // IEnumerator�� �÷����� ���������� �ݺ��� �� �ֵ��� �����Ѵ�.
    // ���Ҹ� �������ִ� ����
    // Current : ���� ��ġ�� ������ ��ȯ
    // MoveNext : ���� ��ġ�� �̵� �� ���� ��ġ�� ������ ���� ���� ��ȯ (��, true�� return�ϸ� ���� ����, false�� return�ϸ� ���Ḧ �ǹ�)
    // Reset : �ε����� �ʱ� ��ġ�� ����
    public class FloatListEnumerator : IEnumerator
    {
        FloatList floatList = null;
        int currentIndex;
        public FloatListEnumerator(FloatList floatList)
        {
            this.floatList = floatList;
            currentIndex = floatList.Count;
        }

        public object Current => floatList[currentIndex];

        public bool MoveNext()
        {
            currentIndex--;
            return currentIndex >= 0;
        }

        public void Reset()
        {
            currentIndex = floatList.Count;
        }
    }

    // IEnumerable : �ݺ��ڸ� �������ִ� �ݺ��� �� �ִ� ģ��
    public class FloatList : IEnumerable
    {
        const int defaultCapacity = 4;
        float[] items;
        int size = 0;
        public int Capacity { get { return items.Length; } }
        public int Count { get { return size; } }

        public float this[int index]
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
        public FloatList()
        {
            items = new float[defaultCapacity];
        }

        public void Add(float item)
        {
            if (size >= items.Length)
                Grow();

            items[size] = item;
            size++;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
            size--;
        }
        public void Grow()
        {
            int newCapacity = items.Length * 2;
            float[] newItems = new float[newCapacity];

            Array.Copy(items, 0, newItems, 0, size);
            items = newItems;
        }

        // IEnumerator�� ���� ��Ű�� Getter�� ������ �ϴ� �������̽��̴�.
        // Collection�� ��ȸ�� �� foreach���� �ַ� ����ϴµ� �̰��� �����ϰ� ���ִ� ���� �ٷ� IEnumerable Interface�� GetEnumerator �Լ��̴�.
        public IEnumerator GetEnumerator()
        {
            return new FloatListEnumerator(this);
        }
    }

    public class GameManager : MonoBehaviour
    {
        //�ݺ��� ����
        void Start()
        {
            FloatList list = new FloatList();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            foreach (float value in list)
            {
                Debug.Log(value);
            }

        }
    }

}