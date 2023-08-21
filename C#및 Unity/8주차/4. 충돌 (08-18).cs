using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody : MonoBehaviour
{
    // Rigidbody가 없는 콜라이더를 static 콜라이더라고 한다.
    // (정적) 움직이지 않는 오브젝트를 만들 때 사용한다.

    // Rigidbody가 없는 콜라이더를 Rigidbody 콜라이더라고 한다.
    // (동적) 움직이는 오브젝트를 만들 때 사용한다.

    // kinematic : 외부에서 가해지는 물리적 힘에 반응하지 않는 오브젝트라는 의미이다.

    // OnTriggerEnter 트리거 충돌이 일어날 때
    // other는 이 게임오브젝트와 트리거 충돌한 상대방의 콜라이더

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        // 태그를 통한 충돌 구분
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }

    
}
