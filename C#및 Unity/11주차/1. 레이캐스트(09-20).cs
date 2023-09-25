using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float maxDistance = 1;

    public bool isGround;
    public bool isJumpable;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (isJumpable)
        {
            rb.AddRelativeForce(transform.up * 10, ForceMode.Impulse);
        }
    }

    // in키워드 : 값을 바꾸지 마라,  out키워드 : 값을 바꿔라
    private void Update()
    {
        // 레이 캐스트
        RaycastHit hit;
        isGround = Physics.Raycast(transform.position, -transform.up, out hit, maxDistance, (1 << 7 | 1 << 6)); // 7번쨰 레이어랑 6번쨰 레이어 검출
        Debug.DrawLine(transform.position, transform.position + (-transform.up * maxDistance), Color.red);
        isJumpable = isGround;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.V))
        {
            RaycastHit enemyHit;
            Debug.DrawLine(transform.position, transform.position + (transform.forward * maxDistance) , Color.blue);
            if (Physics.Raycast(transform.position, transform.forward, out enemyHit, maxDistance))
            {
                // 몬스터가 null이 아닐시
                if (enemyHit.collider.GetComponent<Monster>() != null)
                {
                    // 레이캐스트에 맞은 게임오브젝트에 접근
                    enemyHit.collider.gameObject.GetComponent<Monster>().Hp -= 10;
                }
            }
        }

    }
}
