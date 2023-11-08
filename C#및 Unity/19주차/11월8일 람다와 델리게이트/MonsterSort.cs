using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 2. 대리자를 이용한 템플릿 매서드 실행
public class Monster2
{
    protected int hp;
    protected int atk;
    protected Action processOne = null;
    protected Action processThree = null;

    public void Attack()
    {
        if (processOne!=null)
        {
            processOne();
        }       
        Debug.Log("공격 2");

        // 널인지 먼저 체크후 실행
        processThree?.Invoke();

        Debug.Log("공격 4");
        Debug.Log("공격 5");
    }
}

public class Dragon : Monster2
{
    public Dragon(int hp, int atk)
    {
        this.hp = hp;
        this.atk = atk;
        processOne = AttackProcessOne;
        processThree = AttackProcessThree;
    }

    public void AttackProcessOne()
    {
        Debug.Log("어택 프로세스1");
    }
    public void AttackProcessThree()
    {
        Debug.Log("어택 프로세스3");
    }

}
public class MonsterSort : MonoBehaviour
{
    Dragon dragon;
    private void Start()
    {
        dragon = new Dragon(50, 10);
        dragon.Attack();
    }
}
