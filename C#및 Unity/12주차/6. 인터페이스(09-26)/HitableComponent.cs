using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableComponent : MonoBehaviour,IHitable
{
    [SerializeField]
    private float durability;

    public float Hp
    {
        get
        {
            return durability;
        }
        set
        {
            durability = value;
            if(durability <= 0)
                Destroy(gameObject);
        }
    }

    public void Hit(IAttackable attackable)
    {
        Hp -= attackable.Damage;
    }
}
