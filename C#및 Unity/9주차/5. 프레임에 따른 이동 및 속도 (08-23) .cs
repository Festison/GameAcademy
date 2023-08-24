using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playervelocity : MonoBehaviour
{
    public int speed = 1;
    Rigidbody rigidbody;
  
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // FPS(Frame For Second) 1초동안 보여지는 프레임 수
        // 144fps 는 1초에 144장의 화면을 보여줌
        // 60fps 는 1초에 60장의 화면을 보여줌
        // 10fps 는 1초에 10장의 화면을 보여줌
        // 컴퓨터의 성능이 좋으면 현재 프레임과 이전 프레임의 시간 차이가 더 적어진다.
        // deltaTime을 이용해 컴퓨터의 성능이 다르더라도 속도를 같게 한다.

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.up * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.down * speed * Time.deltaTime);
        //}

        Vector3 vec = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            vec += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            vec += new Vector3(0, 1, 0);
            Debug.Log(vec);
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec += new Vector3(0, -1, 0);
        }

        // vec.normalized 는 벡터의 방향성은 냅두고 길이를 1 로 만들어준다.
        // nomalized를 이용하면 어떤 각도로 이동해도 같은 속도로 이동한다.
        // 오브젝트 균일한 이동을 위하여 벡터의 정규화가 필요하다.
        vec = vec.normalized * speed;

        // velocity를 사용해 속도를 제어하면 충돌이 먼저 일어난다.   
        // Rigidbody의 velocity(속도)자체를 변경시킬 수 있다.
        // Transform의 position을 직접 변경하는것이 아니라서
        // 물리적인 영역에서의 속도를 통한 이동이 일어나기 떄문에, 빨라져도 벽을 통과하지 않는다.
        rigidbody.velocity = vec;
    }
}
