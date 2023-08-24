using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C#¿¡¼­ÀÇ »ó¼Ó
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
        Debug.Log("¸ó½ºÅÍ Á×À½");
    }
}

public class Skeleton : Monster
{
    public override void Die()
    {
        Debug.Log("½ºÄÌ·¹Åæ Á×À½");
    }
}

public class Daragon : Monster
{
    public override void Die()
    {
        Debug.Log("µå·¡°ï Á×À½");
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
