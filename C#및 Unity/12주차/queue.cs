using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오브젝트의 위치를 기억해 그 장소로 따라감
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
