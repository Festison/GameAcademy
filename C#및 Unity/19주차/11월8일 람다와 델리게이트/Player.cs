using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Action OnDie = null;
    private int hp = 100;
    private int atk = 10;
    public int exp = 0;

    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            value = hp;

            if (hp <= 0)
            {
                OnDie?.Invoke();
            }

        }
    }

    private void Start()
    {
        OnDie += () => { Destroy(gameObject); };
    }

    public void OnTriggerEnter(Collider other)
    {
        Monster mon = other.GetComponent<Monster>();

        if (mon!=null)
        {
            mon.HP -= atk;
            // 몬스터가 죽었을 때 호출
            mon.MonsterOnDie += () => { exp += mon.dropExp; };
        }
    }
}
