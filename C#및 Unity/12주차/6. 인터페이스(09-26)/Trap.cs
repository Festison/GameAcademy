using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� �÷��̾� ������Ʈ�� ������ ���� ��
        if (collision.transform.GetComponent<IHitable>() != null)
        {
            AllHit(collision.transform.GetComponent<IHitable>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<IHitable>() != null)
        {
            AllHit(other.transform.GetComponent<IHitable>());
        }
    }

    public void AllHit(IHitable hitable)
    {
        hitable.Hp -= damage;
    }

    

}
