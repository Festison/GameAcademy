using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SearchAlgorithm
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

    public class Node
    {
        public string name;
        public List<Edge> egdesInNode;
        public Node(string name)
        {
            this.name = name;
            egdesInNode = new List<Edge>();
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Node sNode;
        public Node eNode;
        public int cost;

        public Edge(Node sNode, Node eNode, int cost)
        {
            this.sNode = sNode;
            this.eNode = eNode;
            this.cost = cost;
        }

        public int CompareTo(Edge other)
        {
            if (cost > other.cost)
                return 1;
            else if (cost < other.cost)
                return -1;

            return 0;
        }
    }

    public class Graph
    {
        public List<Node> nodeList;
        public List<Edge> edgeList;
        public Dictionary<Node, bool> hasNodeChecDic;

        public Graph()
        {
            nodeList = new List<Node>();
            edgeList = new List<Edge>();
            hasNodeChecDic = new Dictionary<Node, bool>();
        }

        public void AddEdge(Node sNode, Node eNode, int cost)
        {
            TryAddNode(sNode);
            TryAddNode(eNode);

            Edge newEdge = new Edge(sNode, eNode, cost);

            edgeList.Add(newEdge);
            sNode.egdesInNode.Add(newEdge);
        }
        public void AddEdge(Edge edge)
        {
            AddEdge(edge.sNode, edge.eNode, edge.cost);
        }

        bool TryAddNode(Node node)
        {
            if (hasNodeChecDic.ContainsKey(node) == false)
            {
                hasNodeChecDic[node] = true;
                nodeList.Add(node);
                return true;
            }
            return false;
        }
    }

    public interface IMSTStretegy
    {
        event Func<MST> GetOwner;
        void SetMST(Graph graph);
    }

    public class KruskalStretegy : IMSTStretegy
    {
        public event Func<MST> GetOwner;

        public void SetMST(Graph graph)
        {
            MST mst = GetOwner();
            //1. ���� �׷����� ��������Ʈ�� �״�� �����ؼ� �����´�.
            List<Edge> sortedList = new List<Edge>(graph.edgeList);
            //2. �����Ѵ�.
            sortedList.Sort();
            //3. �ϳ��� ������ ��ȯ������ �ƴҶ��� �ִ´�.
            foreach (Edge curEdge in sortedList)
            {
                if (mst.IsCycle(curEdge) == false)
                    mst.AddEdge(curEdge);
            }
        }
    }

    public class PrimStretegy : IMSTStretegy
    {
        public event Func<MST> GetOwner;
        public void SetMST(Graph graph)
        {
            MST mst = GetOwner();

            //���۳�带 ���Ѵ�.         //�� ���//
            Node startNode = graph.nodeList[0];

            //1. �켱���� ť�� �����.
            PriorityQueue<Edge, int> pq = new PriorityQueue<Edge, int>();
            //2. ���۳�峻�� �������� �켱����ť�� �ִ´�.
            foreach (Edge edge in startNode.egdesInNode)
            {
                pq.Enqueue(edge, edge.cost);
            }

            int count = 1;  //�߰��� ������ ���� ��尳��-1�� �϶����� �ݺ�
            while (count < graph.nodeList.Count)
            {
                //3. �켱����ť���� �ϳ� �����´� (������ ���� cost�� ���� ����)
                Edge curEdge = pq.Dequeue();

                //4. ��ȯ���� �ʴ´ٸ� �߰��Ѵ�.
                if (mst.IsCycle(curEdge) == false)
                {
                    mst.AddEdge(curEdge);
                    //5. ������ �����鵵 �켱���� ť�� �߰��Ѵ�.
                    foreach (Edge edge in curEdge.eNode.egdesInNode)
                    {
                        pq.Enqueue(edge, edge.cost);
                    }
                    count++;
                }
            }
        }
    }

    // �ּҽ��� Ʈ��
    public class MST : Graph
    {
        IMSTStretegy stretegy;

        public MST(IMSTStretegy stretegy = null)
        {
            this.stretegy = stretegy ?? new KruskalStretegy();
            stretegy.GetOwner += () => this;
        }

        public void SetMST(Graph graph)
        {
            stretegy.SetMST(graph);
        }
        public bool IsCycle(Edge curEdge)
        {
            //�� ��尡 ������ �̹� ��ϵ� ���� ��ȯ.
            bool check = hasNodeChecDic.ContainsKey(curEdge.sNode) &&
                         hasNodeChecDic.ContainsKey(curEdge.eNode);

            return check;
        }
    }

    public class Test : MonoBehaviour
    {
        Graph graph;
        Dictionary<string, Node> nodeDic;
        void Start()
        {
            PriorityQueue<string, int> monstAgroPQ = new PriorityQueue<string, int>();
            monstAgroPQ.Enqueue("���̷���", 5);
            monstAgroPQ.Enqueue("�巡��", 15);
            monstAgroPQ.Enqueue("������", 1);

            Debug.Log(monstAgroPQ.Dequeue());

            graph = new Graph();
            nodeDic = new Dictionary<string, Node>();
            nodeDic.Add("��", new Node("��"));
            nodeDic.Add("�б�", new Node("�б�"));
            nodeDic.Add("�̿��", new Node("�̿��"));
            nodeDic.Add("������", new Node("������"));
            nodeDic.Add("������", new Node("������"));
            nodeDic.Add("�ҹ漭", new Node("�ҹ漭"));

            graph.AddEdge(nodeDic["��"], nodeDic["�б�"], 3);
            graph.AddEdge(nodeDic["��"], nodeDic["�̿��"], 10);
            graph.AddEdge(nodeDic["��"], nodeDic["�ҹ漭"], 20);

            graph.AddEdge(nodeDic["�б�"], nodeDic["�̿��"], 5);
            graph.AddEdge(nodeDic["�б�"], nodeDic["������"], 4);
            graph.AddEdge(nodeDic["�б�"], nodeDic["�ҹ漭"], 16);

            graph.AddEdge(nodeDic["�̿��"], nodeDic["������"], 11);

            graph.AddEdge(nodeDic["������"], nodeDic["������"], 15);
            graph.AddEdge(nodeDic["������"], nodeDic["�ҹ漭"], 17);


            MST mst = new MST();
            mst.SetMST(graph);

            int totalCost = 0;
            foreach (Edge edge in mst.edgeList)
            {
                Debug.Log(edge.sNode.name + "---" + edge.cost + "----" + edge.eNode.name);
                totalCost += edge.cost;
            }

            Debug.Log("�� �ڽ�Ʈ : " + totalCost);
        }
    }
}

