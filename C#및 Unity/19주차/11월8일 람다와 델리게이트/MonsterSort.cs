using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 2. �븮�ڸ� �̿��� ���ø� �ż��� ����
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
        Debug.Log("���� 2");

        // ������ ���� üũ�� ����
        processThree?.Invoke();

        Debug.Log("���� 4");
        Debug.Log("���� 5");
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
        Debug.Log("���� ���μ���1");
    }
    public void AttackProcessThree()
    {
        Debug.Log("���� ���μ���3");
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
