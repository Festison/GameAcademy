using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 1. 객체의 회전 : MonoBehaviour
{ 
    // 객체의 회전
    // Rotate(회전하고자하는 축, 회전할 앵글값, Space.Self는 로컬 좌표계 (자신을 기준으로) , Space.World는 월드 좌표계 (세상을 기준으로))

    void Update()
    {
        if (Input.GetKey(KeyCode.Q)
        {
            transform.Rotate(Vector3.up, -1, Space.Self);
        }
        if (Input.GetKey(KeyCode.E)
        {
            transform.Rotate(Vector3.up, 1, Space.Self);
        }
    }
}
