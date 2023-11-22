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

// 이진 탐색 트리 개념
// 이진 탐색 트리(BST)는 각 노드가 최대 두 개의 자식 노드를 가지는 이진 트리 자료 구조입니다. BST의 모든 노드는 다음 조건을 만족합니다.
// 왼쪽 서브트리의 모든 노드의 값은 현재 노드의 값보다 작습니다.
// 오른쪽 서브트리의 모든 노드의 값은 현재 노드의 값보다 큽니다.
// 이진 탐색 트리는 효율적인 검색, 삽입, 삭제 연산을 수행할 수 있습니다.

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
