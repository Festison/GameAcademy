using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 1. ��ü�� ȸ�� : MonoBehaviour
{ 
    // ��ü�� ȸ��
    // Rotate(ȸ���ϰ����ϴ� ��, ȸ���� �ޱ۰�, Space.Self�� ���� ��ǥ�� (�ڽ��� ��������) , Space.World�� ���� ��ǥ�� (������ ��������))

    void Update()
    {
        if (Input.GetKey(KeyCode.Q)
        {
            transform.Rotate(Vector3.up, -1, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q)
        {
            transform.Rotate(Vector3.up, 1, Space.Self);
        }
    }
}
