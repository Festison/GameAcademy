using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ�� ��ġ�� ����� �� ��ҷ� ����
public class queue : MonoBehaviour
{
    Queue<Vector3> Queue = new Queue<Vector3>();
    public Transform target;
    public int maxDistance; 

    void Update()
    {
        Queue.Enqueue(target.position);
        
        if (Queue.Count>maxDistance)
        {
            gameObject.transform.position = Queue.Dequeue()+Vector3.one;    
        }
        
    }
}
