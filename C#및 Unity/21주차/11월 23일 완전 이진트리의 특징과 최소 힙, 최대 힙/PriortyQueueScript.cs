using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 우선 순위 큐
// 힙을 사용한 자료구조로서 키값과 데이터 두 가지를 가지고
// 들어갈 떄 (Enqueue), 키값을 통해 힙내부에서 정렬을하고
// 뺄 때(Dequeue), 힙의 루트 부분(최대힙이면 가장 큰 키값, 최소힙이면 가장 작은 키값)을 가져와 데이터를 쓴다.

namespace PriortyQueue
{
   public class PriortyQueueNode
    {
        public int key;
        public string data;

        public PriortyQueueNode(int key, string data)
        {
            this.key = key;
            this.data = data;
        }
    }

    public class PriortyQueue : MaxHeap
    {
        Dictionary<int, PriortyQueueNode> nodeDic;

        public PriortyQueue()
        {
            nodeDic = new Dictionary<int, PriortyQueueNode>();
        }
        public void Enqueue(int key, string data)
        {
            nodeDic.Add(key, new PriortyQueueNode(key, data));
            Add(key);
        }
        public string Dequeue()
        {
            return nodeDic[Remove()].data;
        }
    }

    public class PriortyQueueScript : MonoBehaviour
    {
        void Start()
        {
            PriortyQueue priortyQueue = new PriortyQueue();

            priortyQueue.Enqueue(1, "슬라임");
            priortyQueue.Enqueue(2, "스켈레톤");
            priortyQueue.Enqueue(10, "드래곤");
            priortyQueue.Enqueue(5, "골-든스켈레톤");


            Debug.Log(priortyQueue.Dequeue());
            Debug.Log(priortyQueue.Dequeue());
            Debug.Log(priortyQueue.Dequeue());
            Debug.Log(priortyQueue.Dequeue());

        }

        void Update()
        {

        }
    }
}
