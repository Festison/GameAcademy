using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� : �ൿ�� �����ϰ� ĸ��ȭ�ؼ� ������ �ൿ�� �߰��� �� �����ϰ� ���������� �����Ͽ� ����� �� �ְ� ���� �ִ� ����
// Ư�� ��Ȳ�� ���� �ൿ�� �ٲٰ� ���� �� �����ϸ� ������ ����
// ��) Ư�� �������� �Ծ��� �� ���⸦ ��ü

public enum WEAPON_TYPE
{
    NONE,
    GUN,
    SWORD
}

public abstract class AttackStrategy
{
    public abstract void Attack();
}

public class PunchStrategy : AttackStrategy
{
    public override void Attack()
    {
        Debug.Log("�ָ԰���");
    }
}

public class GunStrategy : AttackStrategy
{
    public override void Attack()
    {
        Debug.Log("������ ����");
    }
}

public class SwordStrategy : AttackStrategy
{
    public override void Attack()
    {
        Debug.Log("������ ����");
    }
}

public class StrategyPattern : MonoBehaviour
{
    [SerializeField]
    private WEAPON_TYPE weaponType;
    private AttackStrategy attackStrategy = null;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            attackStrategy = new SwordStrategy();
        }

        
    }

}
