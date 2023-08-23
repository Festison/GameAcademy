using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 2. 충돌의 종류 : MonoBehaviour
{
    // 콜리전 충돌이 일어 났을 때
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "콜리전 충돌 함!");
    }

    // 콜리전 충돌이 지속 될 때
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "콜리전 충돌 중!");
    }

    // 콜리전 충돌에서 빠져 나올 때
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "콜리전 충돌 빠져나옴!");
    }

    // 트리거 충돌이 일어 났을 때
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "트리거 충돌 함!");
    }

    // 트리거 충돌이 지속 될 때
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + "트리거 충돌 중!");
    }

    // 트리거 충돌에서 빠져 나올 때
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + "트리거 충돌 빠져나옴!");
    }
}
