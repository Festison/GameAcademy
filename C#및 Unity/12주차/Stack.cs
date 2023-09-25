using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ�� ��ġ�� ����� �� ��ҷ� �̵�
public class Stack : MonoBehaviour
{
    Stack<Vector3> stack = new Stack<Vector3>();
    public Transform target;
    public int maxDistance;

    private void Update()
    {
        stack.Push(target.position);

        if (Input.GetKeyDown(KeyCode.E)&& stack.Count > maxDistance)
        {
            gameObject.transform.position = stack.Pop()+Vector3.forward;
        }
        
    }

}
