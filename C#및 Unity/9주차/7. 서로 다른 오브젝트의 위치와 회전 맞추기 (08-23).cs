using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // public을 통해서 불릿 오브젝트의 게임오브젝트를 인스펙터 창에서 접근 가능하게 해준다.
    public GameObject bulletObj;
    // public을 통해서 베럴 오브젝트의 트랜스폼 컴포넌트를 인스펙터 창에서 접근 가능하게 해준다.
    public Transform barrelTransform;
    // 불렛 오브젝트의 리지드 바디를 넣을 변수
    Rigidbody bulletRigid;

    void Start()
    {
        // 불렛 오브젝트의 리지드바디 컴포넌트를 가져온다.
        bulletRigid = bulletObj.GetComponent<Rigidbody>();
        // 불릿오브젝트의 포지션에 베럴오브젝트의 포지션을 대입해 불릿오브젝트의 위치를 이동
        bulletObj.transform.position = barrelTransform.position;
        // 불릿오브젝트의 로테이트에 베럴오브젝트의 로테이트를 대입해 불릿오브젝트의 각도를 맞춤
        bulletObj.transform.rotation = barrelTransform.rotation;
    }
}
