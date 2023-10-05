using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 전략 패턴 : 행동을 정의하고 캡슐화해서 각각의 행동이 추가될 떄 유연하고 독립적으로 변경하여 사용할 수 있게 도와 주는 패턴
// 특정 상황에 따라 행동을 바꾸고 싶을 때 적용하면 유용한 패턴
// 예) 특정 아이템을 먹었을 때 무기를 교체

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
        Debug.Log("주먹공격");
    }
}

public class GunStrategy : AttackStrategy
{
    public override void Attack()
    {
        Debug.Log("총으로 공격");
    }
}

public class SwordStrategy : AttackStrategy
{
    public override void Attack()
    {
        Debug.Log("검으로 공격");
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
