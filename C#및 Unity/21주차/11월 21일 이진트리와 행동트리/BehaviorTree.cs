using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface INode
{
    public enum State
    {
        RUN, SUCCESS, FAIL
    }

    public State Evaluate();
}

public class ActionNode : INode
{
    public Func<INode.State> stateAction = null;

    public INode.State Evaluate()
    {
        return stateAction();
    }
}

public class SelectorNode : INode
{
    List<INode> childs;

    public INode.State Evaluate()
    {
        foreach (INode child in childs)
        {
            switch (child.Evaluate())
            {
                case INode.State.SUCCESS:
                    return INode.State.SUCCESS;
                case INode.State.RUN:
                    return INode.State.RUN;
            }           
        }
        return INode.State.FAIL;
    }
}

public class SequenceNode : INode
{
    List<INode> childs;
    public INode.State Evaluate()
    {
        foreach (INode child in childs)
        {
            switch (child.Evaluate())
            {
                case INode.State.FAIL:
                    return INode.State.FAIL;
                case INode.State.SUCCESS:
                    continue;
            }
        }
        return INode.State.SUCCESS;
    }
}


public class BehaviorTree : MonoBehaviour
{
    // 행위 트리
    // Behavior Tree
    // BT의 요소 일단 BT는 트리의 형태를 하고 있으며 아래 요소들을 포함하고 있습니다.

    // 루트(root), 흐름 제어 노드(flow-control node)
    // Sequence node : and 역할을 하는 노드
    // Selector node : or 역할을 하는 노드, Node들은 SUCCESS, RUN, FAIL의 상태를 가짐
    // 리프 노드(leaf node, action node 라고도 함) : 항상 단말에 위치 실제 행동이 들어가 있는 노드

    // 루트에서 여러 흐름제어 노드를 타고 내려가 최종적으로 리프 노드에 도달하는 형태입니다.
    // 때문에 트리의 리프 노드는 항상 Action을 담고 있어야 하고 루트와 리프를 제외하고는 전부 흐름 제어 노드들이 차지하게 됩니다.

    ActionNode an;
    public bool isCheck;

    private void Start()
    {
        an = new ActionNode();

        an.stateAction += () =>
        {
            Debug.Log("액션");
            if (isCheck)
                return INode.State.SUCCESS;
            else
                return INode.State.FAIL;
        };

        an.Evaluate();
    }
}
