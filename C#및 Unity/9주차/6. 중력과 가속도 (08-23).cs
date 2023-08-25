using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbody : MonoBehaviour
{
    public int hp;
    public float speed;
    Rigidbody rigidbody;

    void Start()
    {
        hp = 100;
        speed = 5f;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    { 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 리지드바디의 AddForce는 벡터의 방향과 크기로 힘을 가해주는 함수
            // 그냥 AddForce는 월드 좌표계 기준
            // ForceMode.Impulse : 오브젝트의 질량을 이용해 순간적인 힘을 가한다.
            
            // velocity를 zero로 초기화시켜서 중력의 힘을 없앤다.
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector3(0,3,3), ForceMode.Impulse);

            // AddRelativeForce는 로컬 좌표계 기준
            // rigidbody.AddRelativeForce(Vector3.right * 1, ForceMode.Impulse);
        }

    }
}
