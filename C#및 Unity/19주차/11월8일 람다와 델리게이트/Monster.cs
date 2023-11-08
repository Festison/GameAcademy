using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster : MonoBehaviour
{
    public List<Player> attackPlayerList = new List<Player>();
    public Action MonsterOnDie = null;
    [SerializeField]
    private int hp = 100;
    public int dropExp = 10;
    public int hitCount = 0;

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
                MonsterOnDie?.Invoke();
            }

        }
    }

    private void Start()
    {
        MonsterOnDie += () =>
        {
            Destroy(gameObject);

            foreach (Player player in attackPlayerList)
            {
                player.exp += dropExp;
            }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (other.GetComponent<Player>() != null)
        {
            if (attackPlayerList.Contains(player))
            {
                return;
            }
            attackPlayerList.Add(player);
        }
    }
}
