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
            // ������ٵ��� AddForce�� ������ ����� ũ��� ���� �����ִ� �Լ�
            // �׳� AddForce�� ���� ��ǥ�� ����
            // ForceMode.Impulse : ������Ʈ�� ������ �̿��� �������� ���� ���Ѵ�.

            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector3(0,3,3), ForceMode.Impulse);

            // AddRelativeForce�� ���� ��ǥ�� ����
            // rigidbody.AddRelativeForce(Vector3.right * 1, ForceMode.Impulse);
        }

    }
}
