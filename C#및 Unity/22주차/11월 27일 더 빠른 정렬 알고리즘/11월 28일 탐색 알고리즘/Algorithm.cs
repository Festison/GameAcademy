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

        //너비우선 탐색 BFS를 하기위한 큐
        CustomQueue<Vector2> queue;

        //깊이우선 탐색 DFS를 하기위한 스택
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
            int y = 3;  //시작 Y값
            int x = 3;  //시작 X값
            bool isFind = false; //탐색시작도 안해서 당연히 아직못찾았음.
            while (isFind == false) //goal을 찾을때까지 반복
            {
                //ref키워드 : 깊은복사가 일어나는 구조체에대하여 얕은복사가 일어나도록해줌.
                if (TryVisit(y, x, ref isFind)) //방문을 시도해서 성공했음
                    yield return new WaitForSeconds(speed); //좀 기다림
                else                        //방문에 실패했음(이미 방문했거나(isVisit==true),
                {                           //               x든y든 배열의 최대범위를 넘어서거나,
                    Pop(out y, out x);      //               벽을(value가 1인) 만났을때는 실패)
                                            //방문에 실패했으니까 새로운 가능성을 뽑아옴)
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
                Debug.Log("찾았다 목적지");
                isFind = true;
                return false;
            }

            Visit(curY, curX);
            return true;
        }

        //   들어온값이   3   ,    3 이라 가정
        void Visit(int curY, int curX)
        {
            //방문했다고 표시, 그래야 이후로 다시 탐색하지 않기때문
            nodes[curY, curX].isVisit = true;
            nodes[curY, curX].value = 99;   //이건 걍 색 바꾼거임 (회색으로)


            if (type == SEARCH_TYPE.BFS)
            {
                queue.Enqueue(new Vector2(curX - 1, curY));   // 2,3   왼쪽
                queue.Enqueue(new Vector2(curX, curY + 1));   // 3,4   위쪽
                queue.Enqueue(new Vector2(curX + 1, curY));   // 4,3   오른쪽
                queue.Enqueue(new Vector2(curX, curY - 1));   // 3,2   아래쪽
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
