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
        // FPS(Frame For Second) 1�ʵ��� �������� ������ ��
        // 144fps �� 1�ʿ� 144���� ȭ���� ������
        // 60fps �� 1�ʿ� 60���� ȭ���� ������
        // 10fps �� 1�ʿ� 10���� ȭ���� ������
        // ��ǻ���� ������ ������ ���� �����Ӱ� ���� �������� �ð� ���̰� �� ��������.
        // deltaTime�� �̿��� ��ǻ���� ������ �ٸ����� �ӵ��� ���� �Ѵ�.

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

        // vec.normalized �� ������ ���⼺�� ���ΰ� ���̸� 1 �� ������ش�.
        // nomalized�� �̿��ϸ� � ������ �̵��ص� ���� �ӵ��� �̵��Ѵ�.
        // ������Ʈ ������ �̵��� ���Ͽ� ������ ����ȭ�� �ʿ��ϴ�.
        vec = vec.normalized * speed;

        // velocity�� ����� �ӵ��� �����ϸ� �浹�� ���� �Ͼ��.   
        // Rigidbody�� velocity(�ӵ�)��ü�� �����ų �� �ִ�.
        // Transform�� position�� ���� �����ϴ°��� �ƴ϶�
        // �������� ���������� �ӵ��� ���� �̵��� �Ͼ�� ������, �������� ���� ������� �ʴ´�.
        rigidbody.velocity = vec;
    }
}
