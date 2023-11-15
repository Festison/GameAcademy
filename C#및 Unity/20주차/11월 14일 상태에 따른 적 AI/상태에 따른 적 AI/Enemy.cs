using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum ENEMY_STATE_TYPE
{
    IDLE,
    TRACE,
    ATTACK
}

public class State
{
    public Enemy enemy;
    public State(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public virtual void Update()
    {

    }
}

public class IdleState : State
{
    public IdleState(Enemy enemy) : base(enemy)
    {
    }

    public override void Update()
    {
        if (enemy.isDetectiveTarget)
            enemy.curState = new TraceState(enemy);
    }
}
public class TraceState : State
{
    public TraceState(Enemy enemy) : base(enemy)
    {
    }

    public override void Update()
    {
        if (enemy.isDetectiveTarget == false)
            enemy.curState = new IdleState(enemy);
        if (enemy.isAttackable)
            enemy.curState = enemy.attackStrategy;
        enemy.SetTarget();
    }
}
public class AttackState : State
{
    public AttackState(Enemy enemy) : base(enemy)
    {
    }

    public override void Update()
    {
        if (enemy.isAttackable == false)
            enemy.curState = new TraceState(enemy);
        Debug.Log("공격!");
    }
}

public class MeleeAttackState : AttackState
{
    public MeleeAttackState(Enemy enemy) : base(enemy)
    {
    }

    public override void Update()
    {
        if (enemy.isAttackable == false)
            enemy.curState = new TraceState(enemy);
        Debug.Log("근거리 공격!");
    }
}

public class RanageAttackState : AttackState
{
    public RanageAttackState(Enemy enemy) : base(enemy)
    {
    }

    public override void Update()
    {
        if (enemy.isAttackable == false)
            enemy.curState = new TraceState(enemy);
        Debug.Log("원거리 공격!");
    }
}

public enum ATTACK_TYPE
{
    Melee,
    Range
}
public class Enemy : MonoBehaviour
{
    // public ENEMY_STATE_TYPE curType;
    public State curState;

    public ATTACK_TYPE atkType;
    public LayerMask targetMask;
    public float detectiveRange;
    public float attackableRange;
    public AttackState attackStrategy = null;

    public Transform target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        if (atkType == ATTACK_TYPE.Melee)
        {
            attackStrategy = new MeleeAttackState(this);
        }
        else
        {
            attackStrategy = new RanageAttackState(this);
        }

        curState = new IdleState(this);
        agent = GetComponent<NavMeshAgent>();
    }

    public bool isDetectiveTarget;
    public bool isAttackable;

    private void Update()
    {
        isDetectiveTarget = Physics.OverlapSphere(transform.position, detectiveRange, targetMask).Length > 0;
        isAttackable = Physics.OverlapSphere(transform.position, attackableRange, targetMask).Length > 0;
        curState.Update();
    }

    public void SetTarget()
    {
        agent.SetDestination(target.position);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectiveRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackableRange);
    }
}