using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �켱 ���� ť
// ���� ����� �ڷᱸ���μ� Ű���� ������ �� ������ ������
// �� �� (Enqueue), Ű���� ���� �����ο��� �������ϰ�
// �� ��(Dequeue), ���� ��Ʈ �κ�(�ִ����̸� ���� ū Ű��, �ּ����̸� ���� ���� Ű��)�� ������ �����͸� ����.

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

            priortyQueue.Enqueue(1, "������");
            priortyQueue.Enqueue(2, "���̷���");
            priortyQueue.Enqueue(10, "�巡��");
            priortyQueue.Enqueue(5, "��-�罺�̷���");


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
