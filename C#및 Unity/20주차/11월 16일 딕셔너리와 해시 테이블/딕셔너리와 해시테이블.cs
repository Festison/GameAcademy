using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Test
{
    public class Hashtable
    {
        private const int defaultCapacity = 1000;

        public struct Entry
        {
            public enum State
            {
                None, Using
            }

            public State state;
            public object key;
            public object value;
        }

        private Entry[] table;

        public object this[object key]
        {
            get
            {
                return GetValue(key);
            }
        }

        public Hashtable()
        {
            table = new Entry[defaultCapacity];
        }

        public void Add(object key, object value)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);
            table[index].key = key;
            table[index].value = value;
        }

        public object GetValue(object key)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);
            return table[index].value;
        }
    }

    public class Dictionary<TKey, TValue>
    {
        private const int defaultCapacity = 1000;
        public struct Entry
        {
            public enum State
            {
                None, Using
            }

            public State state;
            public TKey key;
            public TValue value;
        }

        private Entry[] table;

        public TValue this[TKey key]
        {
            get
            {
                return GetValue(key);
            }
        }
        public Dictionary()
        {
            table = new Entry[defaultCapacity];
        }

        public void Add(TKey key, TValue value)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);
            table[index].state = Entry.State.Using;
            table[index].key = key;
            table[index].value = value;
        }

        public TValue GetValue(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);
            return table[index].value;
        }

        public bool ContainsKey(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);

            if (table[index].state == Entry.State.Using)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class GameManager : MonoBehaviour
    {
        // 키와 값으로 한쌍을 이루는 컨테이너인 연관컨테이너
        // 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑

        Dictionary<string, Color> colorDic;
        Hashtable colorHash;

        void Start()
        {
            colorDic = new Dictionary<string, Color>();
            colorHash = new Hashtable();

            colorHash.Add("RED", Color.red);
            colorHash.Add("CUSTOM", new Color(1, 0, 0.5f));

            colorDic.Add("RED", Color.red);
            colorDic.Add("CUSTOM", new Color(1, 0, 0.5f));

            GetComponent<Renderer>().material.color = colorDic["RED"];

            if (colorDic.ContainsKey("RED"))
            {
                Debug.Log("RED");
            }
        }
    }
}
