using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IHitable
{
    [SerializeField]
    private float hp;

    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Hit(IAttackable attackable)
    {
        Hp -= attackable.Damage;
    }
}
