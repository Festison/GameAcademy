using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 2. �浹�� ���� : MonoBehaviour
{
    // �ݸ��� �浹�� �Ͼ� ���� ��
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "�ݸ��� �浹 ��!");
    }

    // �ݸ��� �浹�� ���� �� ��
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "�ݸ��� �浹 ��!");
    }

    // �ݸ��� �浹���� ���� ���� ��
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "�ݸ��� �浹 ��������!");
    }

    // Ʈ���� �浹�� �Ͼ� ���� ��
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "Ʈ���� �浹 ��!");
    }

    // Ʈ���� �浹�� ���� �� ��
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + "Ʈ���� �浹 ��!");
    }

    // Ʈ���� �浹���� ���� ���� ��
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + "Ʈ���� �浹 ��������!");
    }
}
