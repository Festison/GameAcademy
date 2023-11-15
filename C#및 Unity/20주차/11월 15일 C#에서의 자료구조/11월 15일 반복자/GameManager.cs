using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;


namespace CustomCollections
{
    // IEnumerator는 컬렉션을 순차적으로 반복할 수 있도록 지원한다.
    // 원소를 전달해주는 순서
    // Current : 현재 위치의 데이터 반환
    // MoveNext : 다음 위치로 이동 후 다음 위치에 데이터 존재 여부 반환 (즉, true를 return하면 다음 값을, false를 return하면 종료를 의미)
    // Reset : 인덱스를 초기 위치로 변경
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

    // IEnumerable : 반복자를 가지고있는 반복할 수 있는 친구
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

        // IEnumerator를 리턴 시키는 Getter의 역할을 하는 인터페이스이다.
        // Collection을 순회할 때 foreach문을 주로 사용하는데 이것을 가능하게 해주는 것이 바로 IEnumerable Interface의 GetEnumerator 함수이다.
        public IEnumerator GetEnumerator()
        {
            return new FloatListEnumerator(this);
        }
    }

    public class GameManager : MonoBehaviour
    {
        //반복자 패턴
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