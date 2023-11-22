using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int item;
    public Node left = null;
    public Node right = null;

    public Node(int item)
    {
        this.item = item;
    }
}

// ���� Ž�� Ʈ�� ����
// ���� Ž�� Ʈ��(BST)�� �� ��尡 �ִ� �� ���� �ڽ� ��带 ������ ���� Ʈ�� �ڷ� �����Դϴ�. BST�� ��� ���� ���� ������ �����մϴ�.
// ���� ����Ʈ���� ��� ����� ���� ���� ����� ������ �۽��ϴ�.
// ������ ����Ʈ���� ��� ����� ���� ���� ����� ������ Ů�ϴ�.
// ���� Ž�� Ʈ���� ȿ������ �˻�, ����, ���� ������ ������ �� �ֽ��ϴ�.

public class BST
{
    public Node root;
    public void AddItem(int item)
    {
        if (root == null)
        {
            root = new Node(item);
            return;
        }

        Node curNode = root;
        Node prevNode = null;

        while (curNode != null)
        {
            prevNode = curNode;
            curNode = (curNode.item >= item) ? curNode.left : curNode.right;
        }

        if (prevNode.item >= item)
            prevNode.left = new Node(item);
        else
            prevNode.right = new Node(item);
    }

    public bool IsSearchItem(int item)
    {
        Node curNode = root;
        int depth = 0;

        while (curNode != null)
        {
            if (curNode.item == item)
            {
                Debug.Log(depth);
                return true;
            }

            if (item < curNode.item)
                curNode = curNode.left;
            else
                curNode = curNode.right;
            depth++;
        }
        Debug.Log(depth);
        return false;
    }
}

public class BinarySearch : MonoBehaviour
{
    BST bst = null;

    private void Start()
    {
        bst = new BST();
        bst.AddItem(10);
        bst.AddItem(20);
        bst.AddItem(25);
        bst.AddItem(9);
        bst.AddItem(7);
        bst.AddItem(1);
        bst.AddItem(15);
        bst.AddItem(8);

        int targetItem = -1;
    }
}
