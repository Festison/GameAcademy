using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    void Start()
    {
        // Vector3.zero는 static 멤버 변수
        // static 객체는 프로그램이 종료되기 전까지 메모리를 해제하지 않고 객체를 생성하지 않고도 멤버에 접근이 가능하다는 장점이 있다.

        transform.position = Vector3.zero;
    }

    void Update()
    {
        // transform 컴포넌트 : 모든 오브젝트에 달려 있으며 오브젝트의 위치, 회전, 크기를 제어할 수 있다. 
        // Translate함수 사용이유 : 월드 좌표계를 이용해 맵을 기준으로 오브젝트를 이동시키거나 나를 기준으로 오브젝트를 이동시키기 위해
        // 함수의 원형 : public void Translate(Vector3 translation, [DefaultValue("Space.Self")] Space relativeTo)

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = Vector3.one * 2;
        }
    }
}
