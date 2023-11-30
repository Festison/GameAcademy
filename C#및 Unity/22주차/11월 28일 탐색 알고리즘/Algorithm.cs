using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

namespace Algorithm
{
    public enum SEARCH_TYPE { DFS, BFS }
    public interface IPopPushable
    {
        public void Push();
        public void Pop();
    }

    public class CustomQueue<T> : Queue, IPopPushable
    {
        public void Pop()
        {
            Dequeue();
        }

        public void Push()
        {
            Enqueue(0);
        }
    }

    public class CustomStack : Stack, IPopPushable
    {
        public void Push()
        {
            Push();
        }

        void IPopPushable.Pop()
        {
            Pop();
        }
    }

    public class Node
    {
        public int value;
        public bool isVisit;

        public Node(int value, bool isVisit = false)
        {
            this.value = value;
            this.isVisit = isVisit;
        }
    }

    public class Algorithm : MonoBehaviour
    {
        public SEARCH_TYPE type;
        int[,] graph;
        Node[,] nodes;
        const int start = 2;
        const int goal = 3;

        //�ʺ�켱 Ž�� BFS�� �ϱ����� ť
        CustomQueue<Vector2> queue;

        //���̿켱 Ž�� DFS�� �ϱ����� ����
        Stack<Vector2> stack;

        Dictionary<int, Color> colorDic;
        void Start()
        {
            colorDic = new Dictionary<int, Color>();
            graph = new int[10, 10]
            {
            { 1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,1,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,2,0,1,0,0,0,1 },
            { 1,0,0,0,0,1,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,1,0,0,1 },
            { 1,0,0,0,0,0,1,3,0,1 },
            { 1,0,0,0,0,0,1,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1 }
            };
            nodes = new Node[10, 10];
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    nodes[y, x] = new Node(graph[y, x]);
                }
            }

            colorDic.Add(0, Color.white);
            colorDic.Add(1, Color.black);
            colorDic.Add(start, Color.blue);
            colorDic.Add(goal, Color.red);
            colorDic.Add(99, Color.gray);


            if (type==SEARCH_TYPE.BFS)
            {
                queue = new CustomQueue<Vector2>();
            }
            else
            {
                stack = new Stack<Vector2>();
            }
                    
            StartCoroutine(FindGoalCo());
        }
        public float speed = 1;
        IEnumerator FindGoalCo()
        {
            int y = 3;  //���� Y��
            int x = 3;  //���� X��
            bool isFind = false; //Ž�����۵� ���ؼ� �翬�� ������ã����.
            while (isFind == false) //goal�� ã�������� �ݺ�
            {
                //refŰ���� : �������簡 �Ͼ�� ����ü�����Ͽ� �������簡 �Ͼ��������.
                if (TryVisit(y, x, ref isFind)) //�湮�� �õ��ؼ� ��������
                    yield return new WaitForSeconds(speed); //�� ��ٸ�
                else                        //�湮�� ��������(�̹� �湮�߰ų�(isVisit==true),
                {                           //               x��y�� �迭�� �ִ������ �Ѿ�ų�,
                    Pop(out y, out x);      //               ����(value�� 1��) ���������� ����)
                                            //�湮�� ���������ϱ� ���ο� ���ɼ��� �̾ƿ�)
                }
                yield return null;
            }

        }

        void Pop(out int y, out int x)
        {
            if (type == SEARCH_TYPE.BFS)
            {
                Vector2 temp = (Vector2)queue.Dequeue();
                x = (int)temp.x;
                y = (int)temp.y;
            }
            else
            {
                Vector2 temp = stack.Pop();
                x = (int)temp.x;
                y = (int)temp.y;
            }                    
        }

        bool TryVisit(int curY, int curX, ref bool isFind)
        {
            if (curY >= 10 || curY <= 0 || curX >= 10 || curX <= 0)
                return false;
            if (nodes[curY, curX].isVisit)
                return false;
            if (nodes[curY, curX].value == 1)
                return false;


            if (isCheckGoal(curY, curX))
            {
                Debug.Log("ã�Ҵ� ������");
                isFind = true;
                return false;
            }

            Visit(curY, curX);
            return true;
        }

        //   ���°���   3   ,    3 �̶� ����
        void Visit(int curY, int curX)
        {
            //�湮�ߴٰ� ǥ��, �׷��� ���ķ� �ٽ� Ž������ �ʱ⶧��
            nodes[curY, curX].isVisit = true;
            nodes[curY, curX].value = 99;   //�̰� �� �� �ٲ۰��� (ȸ������)


            if (type == SEARCH_TYPE.BFS)
            {
                queue.Enqueue(new Vector2(curX - 1, curY));   // 2,3   ����
                queue.Enqueue(new Vector2(curX, curY + 1));   // 3,4   ����
                queue.Enqueue(new Vector2(curX + 1, curY));   // 4,3   ������
                queue.Enqueue(new Vector2(curX, curY - 1));   // 3,2   �Ʒ���
            }
            else
            {
                stack.Push(new Vector2(curX - 1, curY));
                stack.Push(new Vector2(curX, curY + 1));
                stack.Push(new Vector2(curX + 1, curY));
                stack.Push(new Vector2(curX, curY - 1));
            }
        }

        bool isCheckGoal(int curY, int curX)
        {
            return nodes[curY, curX].value == goal;
        }

        private void OnDrawGizmos()
        {
            if (nodes == null)
                return;

            for (int y = 0; y < nodes.GetLength(0); y++)
            {
                for (int x = 0; x < nodes.GetLength(1); x++)
                {
                    Vector3 offset = new Vector3(x * 2, y * 2, 0);

                    Gizmos.color = colorDic[nodes[y, x].value];
                    Gizmos.DrawSphere(transform.position - offset, 1);
                }
            }

        }
    }
}
