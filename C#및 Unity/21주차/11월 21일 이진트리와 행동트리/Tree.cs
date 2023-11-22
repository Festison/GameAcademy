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
        // Ʈ��
        // Ʈ���� �׷����� ����, �� ���� �ڷᱸ��

        // Ʈ�� ���� �ֿ� ���
        // Node	: Ʈ���� �����ϴ� �⺻ ����
        // Root node : �θ� ���� �ֻ��� ��Ʈ ��� Ʈ���� �ϳ��� ��Ʈ ��常�� ������.
        // Leaf node : �ڽ��� ���� ��� (�� ������ �� ���)
        // Internal : Leaf node �� �ƴ� ���
        // Edge/Branch/Link : ��带 �����ϴ� �� , �Ѹ�(root)�� ��(leaf)������ ��� ���
        // Degree : ���� Ʈ������ / �� ��尡 ���� ������ �� (������ڽ� ����� ��)
        // Order : �ڽ� ���� �� �ִ� ����
        // Depth : ��Ʈ���� � ��忡 �����ϱ� ���� ���ľ� �ϴ� ������ ��
        // Level : Ư�� ���̸� ������ ����� ���� (���� ����)
        // Height : ��Ʈ ��忡�� ���� ����� �ִ� ����� ����
        // Size : Ư�� ��尡 �ڽ��� ������ �ڼ��� ��
        // Parent Node : ����( ancestor ) : �θ� ���� ���� �θ��
        // Child Node : �ڼ�( descendant ) : �ڽ� ���� �� �ڽĵ�
        // Sibling Node : ���� �θ� ������ ���
        // Subtree : �ڽĿ��� Ʈ�������� �� ������ �Ǵ� ���

        // ���� ��ȸ, ���� : �ڽ� -> ���� -> ������
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

        // ���� ��ȸ, ���� : ���� -> �ڽ� -> ������
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

        // ���� ��ȸ, ���� : ���� -> ������ -> �ڽ�
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
