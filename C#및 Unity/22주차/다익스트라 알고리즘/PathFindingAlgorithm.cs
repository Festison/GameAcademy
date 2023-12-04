using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


namespace Djistar
{
    public class PriorityQueue<TElement, TPriority>
    {
        private struct Node
        {
            public TElement Element;
            public TPriority Priority;
        }

        private List<Node> nodes;
        private IComparer<TPriority> comparer;

        public PriorityQueue()
        {
            this.nodes = new List<Node>();
            this.comparer = Comparer<TPriority>.Default;
        }

        public PriorityQueue(IComparer<TPriority> comparer)
        {
            this.nodes = new List<Node>();
            this.comparer = comparer;
        }

        public int Count { get { return nodes.Count; } }
        public IComparer<TPriority> Comparer { get { return comparer; } }

        public void Enqueue(TElement element, TPriority priority)
        {
            Node newNode = new Node() { Element = element, Priority = priority };

            PushHeap(newNode);
        }

        public TElement Peek()
        {
            if (nodes.Count == 0)
                throw new InvalidOperationException();

            return nodes[0].Element;
        }

        public bool TryPeek(out TElement element, out TPriority priority)
        {
            if (nodes.Count == 0)
            {
                element = default(TElement);
                priority = default(TPriority);
                return false;
            }

            element = nodes[0].Element;
            priority = nodes[0].Priority;
            return true;
        }

        public TElement Dequeue()
        {
            if (nodes.Count == 0)
                throw new InvalidOperationException();

            Node rootNode = nodes[0];
            PopHeap();
            return rootNode.Element;
        }

        public bool TryDequeue(out TElement element, out TPriority priority)
        {
            if (nodes.Count == 0)
            {
                element = default(TElement);
                priority = default(TPriority);
                return false;
            }

            Node rootNode = nodes[0];
            element = rootNode.Element;
            priority = rootNode.Priority;
            PopHeap();
            return true;
        }

        private void PushHeap(Node newNode)
        {
            nodes.Add(newNode);
            int newNodeIndex = nodes.Count - 1;
            while (newNodeIndex > 0)
            {
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = nodes[parentIndex];

                if (comparer.Compare(newNode.Priority, parentNode.Priority) < 0)
                {
                    nodes[newNodeIndex] = parentNode;
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
            nodes[newNodeIndex] = newNode;
        }

        private void PopHeap()
        {
            Node lastNode = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            while (index < nodes.Count)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                if (rightChildIndex < nodes.Count)
                {
                    int compareIndex = comparer.Compare(nodes[leftChildIndex].Priority, nodes[rightChildIndex].Priority) < 0 ?
                    leftChildIndex : rightChildIndex;

                    if (comparer.Compare(nodes[compareIndex].Priority, lastNode.Priority) < 0)
                    {
                        nodes[index] = nodes[compareIndex];
                        index = compareIndex;
                    }
                    else
                    {
                        nodes[index] = lastNode;
                        break;
                    }
                }
                else if (leftChildIndex < nodes.Count)
                {
                    if (comparer.Compare(nodes[leftChildIndex].Priority, lastNode.Priority) < 0)
                    {
                        nodes[index] = nodes[leftChildIndex];
                        index = leftChildIndex;
                    }
                    else
                    {
                        nodes[index] = lastNode;
                        break;
                    }
                }
                else
                {
                    nodes[index] = lastNode;
                    break;
                }
            }
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Dijkstra
    {
        class Node
        {
            public Point point;     //이 정점이 가진 위치
            public Point parent;    //이 정점을 탐색한 정점

            public int cost;

            public Node(Point point, Point parent, int cost)
            {
                this.point = point;
                this.parent = parent;
                this.cost = cost;
            }
        }

        const int costStraight = 10;
        const int costDiagonal = 14;

        Point[] dir = new Point[8];

        public Dijkstra()
        {
            dir[0] = new Point(0, 1);       //상
            dir[1] = new Point(0, -1);      //하
            dir[2] = new Point(-1, 0);      //좌
            dir[3] = new Point(1, 0);       //우
            dir[4] = new Point(-1, 1);      //좌상
            dir[5] = new Point(-1, -1);     //좌하
            dir[6] = new Point(1, 1);       //우상
            dir[7] = new Point(1, -1);      //우하
        }

        public bool PathFinding(int[,] tileMap, Point start, Point end, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            Node[,] nodes = new Node[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<Node, int> visitPQ = new PriorityQueue<Node, int>();

            //시작 정점을 생성하여 추가함.
            Node startNode = new Node(start, new Point(), 0);
            nodes[start.y, start.x] = startNode;
            visitPQ.Enqueue(startNode, startNode.cost);

            while (visitPQ.Count > 0)
            {
                //방문할 정점(노드)를 꺼냄, 우선순위 큐이므로 당연히 비용이 낮은거부터 꺼냄
                Node curVisitNode = visitPQ.Dequeue();

                //방문하엿다고 표시
                visited[curVisitNode.point.y, curVisitNode.point.x] = true;

                //목표 찾았다!
                if (curVisitNode.point.x == end.x &&
                   curVisitNode.point.y == end.y)
                {
                    path = new List<Point>();

                    Point point = end;
                    while (!(point.x == start.x && point.y == start.y))
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);
                    path.Reverse();

                    return true;
                }

                for (int i = 0; i < dir.Length; i++)
                {
                    int searchX = curVisitNode.point.x + dir[i].x;
                    int searchY = curVisitNode.point.y + dir[i].y;

                    if (searchX < 0 || searchY < 0 ||
                       searchX >= xSize || searchY >= ySize)
                        continue;
                    else if (tileMap[searchY, searchX] == 1)
                        continue;
                    else if (visited[searchY, searchX])
                        continue;
                    bool isStraight = curVisitNode.point.x == searchX;
                    isStraight |= curVisitNode.point.y == searchY;

                    int cost = curVisitNode.cost + (isStraight ? costStraight : costDiagonal);
                    Node newNode = new Node(new Point(searchX, searchY), curVisitNode.point, cost);

                    if (nodes[searchY, searchX] == null ||
                        nodes[searchY, searchX].cost > newNode.cost)
                    {
                        nodes[searchY, searchX] = newNode;
                        visitPQ.Enqueue(newNode, newNode.cost);
                    }
                }
            }
            path = null;
            return false;
        }
    }

    public class PathFindingAlgorithm : MonoBehaviour
    {
        int[,] tileMap;
        Dijkstra dijkstra;
        Color[,] colorMap;
        List<Point> path;

        void Start()
        {
            dijkstra = new Dijkstra();
            tileMap = new int[10, 10]
               {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 0, 1, 0, 0, 1 },
                { 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 1, 1, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
               };

            StartCoroutine(PathFindingCo());
        }

        IEnumerator PathFindingCo()
        {
            colorMap = new Color[10, 10];
            dijkstra.PathFinding(tileMap, new Point(2, 2), new Point(4, 5), out path);

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (tileMap[y, x] == 0)
                        colorMap[y, x] = Color.white;
                    else
                        colorMap[y, x] = Color.black;
                }
            }
            Point start = path.First();
            Point end = path.Last();

            colorMap[start.y, start.x] = Color.blue;
            colorMap[end.y, end.x] = Color.red;

            foreach (Point p in path)
            {
                colorMap[p.y, p.x] = Color.gray;
                yield return new WaitForSeconds(0.1f);
            }
        }


        private void OnDrawGizmos()
        {
            if (tileMap == null) return;
            if (colorMap == null) return;


            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Gizmos.color = colorMap[y, x];
                    Vector3 offset = new Vector3(y, x);
                    Gizmos.DrawCube(transform.position + offset, Vector3.one);
                }
            }
        }

    }

}