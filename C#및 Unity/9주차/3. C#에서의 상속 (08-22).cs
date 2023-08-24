using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C#������ ���
public class Monster
{
    public int hp;
    public int atk;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("���� ����");
    }
}

public class Skeleton : Monster
{
    public override void Die()
    {
        Debug.Log("���̷��� ����");
    }
}

public class Daragon : Monster
{
    public override void Die()
    {
        Debug.Log("�巡�� ����");
    }
}

public class Inheritance : MonoBehaviour
{
    private void Start()
    {
        Monster monster;
        Daragon dragon = new Daragon();
        Skeleton skeleton = new Skeleton();

        skeleton.Die();
        dragon.Die();

        monster = dragon;
        monster.Die();

    }
}
