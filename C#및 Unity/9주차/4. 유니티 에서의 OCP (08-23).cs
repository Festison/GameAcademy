using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 4. OCP : MonoBehaviour
{
    public int hp = 100;
    public int atk = 10;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    //�浹ü(Collider)�� �浹�� �߻����� �� ȣ�� �Ǵ� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "�ݸ��� �浹�Ͼ");
        // ���� �ε��� ���ӿ�����Ʈ�� �±װ� Enemy�϶��� TakeDamage(10) ȣ��.

        // �巡���� �浹���� �� �� ü���� 40�� �ް��ϰ�Ͱ�,
        // ���̷����� �浹���� �� �� ü���� 10�� �ް��ϰ����.

        // �±׸� ���� �б⸦ ������, �±��� ������ �߰��ɶ�����,
        // �Ʒ��κ��� ��� ������ �Ͼ���Ѵ�.
        // ��, ��������� ��Ģ(OCP)�� ���谡�ȴ�.
        // OCP�� Ȯ�忡 �����ְ� ���濡 �����ִٴ� ���̴�. �� �ѹ�§ �ҽ��� �ٽ� ���������ʴ°��� ���� �ҽ���.

        // OCP�� �̿��� �ڵ�
        // �� ĳ������ �Ͼ�� ���͸� ��ӹ��� �巡��, ���̷��� ���� ���� �� �� �ִ�.
        Monster monster = collision.gameObject.GetComponent<Monster>();

        if (monster != null)
        {
            hp -= monster.atk;
            monster.TakeDamage(10);
        }            
        // tag�� �̿��� �ڵ�
        /*
        if(collision.gameObject.tag == "Skeleton") 
        {
            TakeDamage(10);
        }
        if (collision.gameObject.tag == "Dragon")
        {
            TakeDamage(40);
        }
        */       
    }
}
