using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;
using static UnityEngine.UI.GridLayoutGroup;

public enum STATE_TYPE
{
    IDLE,
    WALK,
    RUN
}

public class PlayerState : State
{
    protected Player player;
    public override void Init(IStateMachine sm)
    {
        this.sm = sm;
        player = (Player)sm.GetOwner();
    }
}
public class IdleState : PlayerState
{
    public override void Update()
    {
        if (player.MoveVec != Vector3.zero)
            sm.SetState("Walk");
        if (Input.GetKeyDown(KeyCode.V))
            sm.SetState("Attack");

    }
}
public class WalkState : PlayerState
{
    public override void Update()
    {
        if (player.MoveVec == Vector3.zero)
            sm.SetState("Idle");
        if (Input.GetKeyDown(KeyCode.LeftShift))
            sm.SetState("Run");
    }
}
public class RunState : PlayerState
{
    public override void Update()
    {
        if (player.MoveVec == Vector3.zero)
            sm.SetState("Idle");
        if (Input.GetKeyUp(KeyCode.LeftShift))
            sm.SetState("Walk");
    }
}

public class AttackState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("╬Нец!");
        sm.SetState("Idle");
    }
}



public class Player : MonoBehaviour
{

    StateMachine<Player> sm;
    Vector3 moveVec;
    public Vector3 MoveVec
    {
        get { return moveVec; }
    }

    private void Start()
    {
        sm = new StateMachine<Player>();
        sm.owner = this;
        sm.AddState("Idle", new IdleState());
        sm.AddState("Walk", new WalkState());
        sm.AddState("Run", new RunState());
        sm.AddState("Attack", new AttackState());
        sm.SetState("Idle");
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        moveVec = new Vector3(x, 0, z).normalized;
        sm.Update();
    }
}
