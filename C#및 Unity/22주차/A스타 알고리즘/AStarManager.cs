using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

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

[System.Serializable]
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
internal class AStar
{
    /******************************************************
     * A* 알고리즘
     * 
     * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
     * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
     ******************************************************/

    const int costStraight = 10;
    const int costDiagonal = 14;

    static Point[] dir =
        {
            new Point(  0, +1 ),			// 상
			new Point(  0, -1 ),			// 하
			new Point( -1,  0 ),			// 좌
			new Point( +1,  0 ),			// 우
			new Point( -1, +1 ),		    // 좌상
			new Point( -1, -1 ),		    // 좌하
			new Point( +1, +1 ),		    // 우상
			new Point( +1, -1 )		        // 우하
		};

    public static bool PathFinding(in NodeComponent[,] tileMap, in Point start, in Point end, out List<Point> path)
    {
        int ySize = tileMap.GetLength(0);
        int xSize = tileMap.GetLength(1);

        Node[,] nodes = new Node[ySize, xSize];
        bool[,] visited = new bool[ySize, xSize];
        PriorityQueue<Node, int> visitPQ = new PriorityQueue<Node, int>();

        Node startNode = new Node(start, new Point(), 0, Heuristic(start, end));
        nodes[startNode.point.y, startNode.point.x] = startNode;
        visitPQ.Enqueue(startNode, startNode.f);

        while (visitPQ.Count > 0)
        {
            Node curVisitNode = visitPQ.Dequeue();

            visited[curVisitNode.point.y, curVisitNode.point.x] = true;

            if (curVisitNode.point.x == end.x && curVisitNode.point.y == end.y)
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
                int x = curVisitNode.point.x + dir[i].x;
                int y = curVisitNode.point.y + dir[i].y;


                if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                    continue;
                else if (tileMap[y, x].CostType == 1)
                    continue;
                else if (visited[y, x])
                    continue;

                else if (i >= 4)
                {
                    if (tileMap[y, curVisitNode.point.x].CostType == 1 && tileMap[curVisitNode.point.y, x].CostType == 1)
                        continue;
                    if (tileMap[y, curVisitNode.point.x] != tileMap[curVisitNode.point.y, x])
                        continue;
                }

                int g = curVisitNode.g + ((curVisitNode.point.x == x || curVisitNode.point.y == y) ? costStraight : costDiagonal);
                int h = Heuristic(new Point(x, y), end);

                g += (tileMap[y, x].CostType == 2) ? 300 : 0;

                Node newNode = new Node(new Point(x, y), curVisitNode.point, g, h);


                if (nodes[y, x] == null ||
                    nodes[y, x].f > newNode.f)
                {
                    nodes[y, x] = newNode;
                    visitPQ.Enqueue(newNode, newNode.f);
                }
            }
        }

        path = null;
        return false;
    }

    private static int Heuristic(Point start, Point end)
    {
        int xSize = Math.Abs(start.x - end.x);
        int ySize = Math.Abs(start.y - end.y);

        return costStraight * (xSize + ySize);
    }

    private class Node
    {
        public Point point;
        public Point parent;

        public int g;
        public int h;
        public int f;

        public Node(Point point, Point parent, int g, int h)
        {
            this.point = point;
            this.parent = parent;

            this.g = g;
            this.h = h;
            this.f = g + h;
        }
    }
}

public class AStarManager : MonoBehaviour
{
    int[,] tileMap;
    Color[,] pathMap;
    List<Point> path;
    NodeComponent[,] costType;

    public Point startPos;
    public Point endPos;

    private void Start()
    {
        tileMap = new int[10, 10]
           {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 1, 1, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
           };
    }
    IEnumerator AstarCo()
    {
        pathMap = new Color[tileMap.GetLength(0), tileMap.GetLength(1)];

        AStar.PathFinding(costType, new Point(2, 2), new Point(7, 7), out path);


        for (int y = 0; y < pathMap.GetLength(0); y++)
        {
            for (int x = 0; x < pathMap.GetLength(1); x++)
            {
                if (tileMap[y, x] == 0)
                    pathMap[y, x] = Color.white;
                else
                    pathMap[y, x] = Color.black;
            }
        }
        Point start = path.First();
        Point end = path.Last();
        pathMap[start.y, start.x] = Color.blue;
        pathMap[end.y, end.x] = Color.red;

        foreach (Point point in path)
        {
            pathMap[point.y, point.x] = Color.gray;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AstarCo());
        }
    }


    private void OnDrawGizmos()
    {
        if (tileMap == null)
            return;
        if (pathMap == null)
            return;

        for (int i = 0; i < pathMap.GetLength(0); i++)
        {
            for (int j = 0; j < pathMap.GetLength(1); j++)
            {
                Gizmos.color = pathMap[i, j];
                Vector3 offset = new Vector3(i, -j);
                Gizmos.DrawCube(transform.position + offset, Vector3.one);
            }
        }
    }
}