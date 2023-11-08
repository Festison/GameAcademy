using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lambda : MonoBehaviour
{
    public Action OnDie = null;
    private int hp = 100;

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

    public void Start()
    {
        // �����Լ� : ���� �޼��� - �Լ��� �̸��� ���� �Լ��� �Ｎ���� �����ȴ�.
        // ��ġ ������Ʈ, ����ó�� �̸� ���� ������ �� �ִ� ���� �Ǳ⵵ �Ѵ�.
        // �� ������ �����ʴ� Ư���� �� ��¥�� �Լ��� �Ｎ���� �����Ѵ�.
        // ���� : (input-parameters) => expression
        OnDie += () => { Destroy(gameObject); };
    }

}
