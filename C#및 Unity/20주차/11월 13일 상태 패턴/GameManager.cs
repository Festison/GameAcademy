using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IStateMachine
{
    void SetState(string name);
    object GetOwner();
}

public class State
{

    public IStateMachine sm = null;
    public event Action onEnter;

    public virtual void Init(IStateMachine sm)
    {
        this.sm = sm;
    }
    public virtual void Enter()
    {
        if(onEnter != null)
            onEnter();
    }
    public virtual void Update()
    {

    }
    public virtual void Exit()
    {

    }
}

public class GMState : State
{
    public GameManager gm = null;

    public override void Init(IStateMachine sm)
    {
        base.Init(sm);
        gm = (GameManager)sm.GetOwner();
    }
}
public class DefaultState : GMState
{
    public override void Update()
    {
        Debug.Log("DDDD");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            sm.SetState("Play");
        }
    }
}

public class PlayState : GMState
{
    public override void Update()
    {
        Debug.Log("SSSS"+ gm.score);
    }
}

public class StateMachine<T> : IStateMachine where T : class
{
    public T owner = null;
    public State curState = null;

    Dictionary<string, State> stateDic = null;

    public StateMachine()
    {
        stateDic = new Dictionary<string, State>();
    }

    public void AddState(string name, State state)
    {
        if(stateDic.ContainsKey(name))
            return;

        state.Init(this);
        stateDic.Add(name, state);
    }

    public object GetOwner()
    {
        return owner;
    }

    public void SetState(string name)
    {
        if(stateDic.ContainsKey(name))
        {

            if (curState != null)
                curState.Exit();
            curState = stateDic[name];
            curState.Enter();
        }
    }

    public void Update()
    {
        curState.Update();
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score=0;
    StateMachine<GameManager> sm;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        sm = new StateMachine<GameManager>();
        sm.owner = this;

        PlayState ps = new PlayState();
        ps.onEnter += () => { Debug.Log("TESTSET"); };
        sm.AddState("Default", new DefaultState());
        sm.AddState("Play", ps);
        sm.SetState("Default");

    }


    // Update is called once per frame
    void Update()
    {
        sm.Update();
    }
}
