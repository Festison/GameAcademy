using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody : MonoBehaviour
{
    // Rigidbody�� ���� �ݶ��̴��� static �ݶ��̴���� �Ѵ�.
    // (����) �������� �ʴ� ������Ʈ�� ���� �� ����Ѵ�.

    // Rigidbody�� ���� �ݶ��̴��� Rigidbody �ݶ��̴���� �Ѵ�.
    // (����) �����̴� ������Ʈ�� ���� �� ����Ѵ�.

    // kinematic : �ܺο��� �������� ������ ���� �������� �ʴ� ������Ʈ��� �ǹ��̴�.

    // OnTriggerEnter Ʈ���� �浹�� �Ͼ ��
    // other�� �� ���ӿ�����Ʈ�� Ʈ���� �浹�� ������ �ݶ��̴�

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        // �±׸� ���� �浹 ����
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }

    
}
