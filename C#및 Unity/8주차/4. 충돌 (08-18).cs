using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody : MonoBehaviour
{
    // Rigidbody란 오브젝트의 중력 질량등을 제어 해 충돌시 효과를 일어나게 합니다.

    // Mass 오브젝트의 질량입니다.
    // Drag 오브젝트가 힘에 의해 움직일 때 공기 저항이 영향을 미치는 정도를 나타냅니다. 0이면 공기 저항이 없으며 무한대라면 오브젝트가 즉시 정지합니다.
    // Angular Drag    오브젝트가 토크로 회전할 때 공기 저항이 영향을 미치는 정도를 나타냅니다. 0이면 공기 저항이 없습니다. 앵글 드래그를 무한대로 설정한다고 해서 오브젝트의 회전이 멈추지는 않으니 주의해야 합니다.
    // Use Gravity 활성화되면 오브젝트는 중력의 영향을 받습니다.
    // Is Kinematic    활성화되면 오브젝트는 물리 엔진으로 제어되지 않고 오로지 Transform 으로만 조작됩니다. 플랫폼을 옮기는 경우나 HingeJoint 가 추가된 리지드바디를 애니메이션화하는 경우에 유용합니다.
    
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
