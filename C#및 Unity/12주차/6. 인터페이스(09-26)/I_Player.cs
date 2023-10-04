using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public float Damage { get; }
    public void Attack(IHitable hitable);
}
public interface IHitable
{
    public float Hp { get; set; }
    public void Hit(IAttackable attackable);
}

// �������̽��� ��ӹ� ��ȣ�ۿ��̴�.
// �������̽��� Ŭ������ ���߻���� �� �� ���� ������ �����ϱ� ���� ������� �����̴�.
// ��, Ŭ������ �������̽��� ���� �� ��ӹ��� �� �ִ�.
// �������̽��� ��ӹ޴� Ŭ������ �������̽����� �����Ѹ���� ������ ���� �ؾ� �Ѵٴ� ������ִ�.
// �������̽��� ������ �߻�Ŭ������ ����ѵ� �������� �߻�ȭ�� ����Ѵٴ� ���̴�.
// �������̽� �̸��� Ŭ������� ������ �� �ֵ��� �̸� �տ� �빮�� I (����) �� �ٿ� �����.
// �޼���, ������Ƽ(property �Ӽ�), �ε���(indexer) ���� ����� ���� �� �ִ�.
// ����� ��� �߻�ȭ�� �����ϴ�. ��, ��� ���� �� �� �ִ�.
// �߻� Ŭ������ ���������� �ν��Ͻ�(��ü) �� ������ �� ����.
// �������̽��� ����ϴ� ���� : �������� ���ʰ�, ���鰳�� ��� �����۸��� GetComponent �� �ͼ� if�� ó���� �ϸ� �ڵ尡 ������� �������� ���̴�.
public class Player : MonoBehaviour, IAttackable, IHitable
{
    [SerializeField]
    private float hp;
    [SerializeField]
    private float atk;
    public float Damage
    {
        get 
        { 
            return atk; 
        }
    }

    public float Hp
    {
        get => hp;

        set
        {
            hp = value;

            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Attack(IHitable hitable)
    {
        hitable.Hit(this);
    }

    public void Hit(IAttackable attackable)
    {
        Hp -= attackable.Damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<IHitable>() != null)
        {
            Attack(collision.transform.GetComponent<IHitable>());
        }
    }
}
