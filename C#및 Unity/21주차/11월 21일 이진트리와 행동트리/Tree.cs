using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestCollection
{
    public class Node
    {
        public int item;
        public Node left = null;
        public Node right = null;

        public Node(int item = 0)
        {
            this.item = item;
        }
    }

    public class Tree : MonoBehaviour
    {
        // 트리
        // 트리는 그래프의 일종, 비 선형 자료구조

        // 트리 관련 주요 용어
        // Node	: 트리를 구성하는 기본 원소
        // Root node : 부모가 없는 최상위 루트 노드 트리는 하나의 루트 노드만을 가진다.
        // Leaf node : 자식이 없는 노드 (맨 마지막 끝 노드)
        // Internal : Leaf node 가 아닌 노드
        // Edge/Branch/Link : 노드를 연결하는 선 , 뿌리(root)와 잎(leaf)사이의 모든 노드
        // Degree : 하위 트리개수 / 각 노드가 지닌 가지의 수 (연결된자식 노드의 수)
        // Order : 자식 노드들 중 최대 개수
        // Depth : 루트에서 어떤 노드에 도달하기 위해 거쳐야 하는 간선의 수
        // Level : 특정 깊이를 가지는 노드의 집합 (같은 깊이)
        // Height : 루트 노드에서 가장 깊숙히 있는 노드의 깊이
        // Size : 특정 노드가 자신을 포함한 자손의 수
        // Parent Node : 선조( ancestor ) : 부모 노드와 그의 부모들
        // Child Node : 자손( descendant ) : 자식 노드와 그 자식들
        // Sibling Node : 같은 부모를 가지는 노드
        // Subtree : 자식에서 트리구조가 또 나오게 되는 경우

        // 전위 순회, 전위 : 자신 -> 왼쪽 -> 오른쪽
        public void PreOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            Debug.Log(root.item);
            PreOrder(root.left);
            PreOrder(root.right);
        }

        // 중위 순회, 중위 : 왼쪽 -> 자신 -> 오른쪽
        public void InOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.left);
            Debug.Log(root.item);
            InOrder(root.right);
        }

        // 후위 순회, 후위 : 왼쪽 -> 오른쪽 -> 자신
        public void PostOrder(Node root)
        {
            if (root == null)
            {
                return;
            }
            PostOrder(root.left);
            PostOrder(root.right);
            Debug.Log(root.item);
        }

        void RemoveNode(Node targetNode)
        {
            if (targetNode == null)
            {
                return;
            }
            RemoveNode(targetNode.left);
            RemoveNode(targetNode.right);
            Debug.Log(targetNode.item);
        }

        Node root = null;

        private void Start()
        {
            root = new Node(0);
            root.left = new Node(1);
            root.right = new Node(2);
            root.left.left = new Node(3);
            root.left.right = new Node(4);
            root.right.left = new Node(5);
            root.right.right = new Node(6);

            RemoveNode(root.left);
            PreOrder(root);
            InOrder(root);
            PostOrder(root);
        }
    }
}
