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
    // ���� Ʈ��
    // Behavior Tree
    // BT�� ��� �ϴ� BT�� Ʈ���� ���¸� �ϰ� ������ �Ʒ� ��ҵ��� �����ϰ� �ֽ��ϴ�.

    // ��Ʈ(root), �帧 ���� ���(flow-control node)
    // Sequence node : and ������ �ϴ� ���
    // Selector node : or ������ �ϴ� ���, Node���� SUCCESS, RUN, FAIL�� ���¸� ����
    // ���� ���(leaf node, action node ��� ��) : �׻� �ܸ��� ��ġ ���� �ൿ�� �� �ִ� ���

    // ��Ʈ���� ���� �帧���� ��带 Ÿ�� ������ ���������� ���� ��忡 �����ϴ� �����Դϴ�.
    // ������ Ʈ���� ���� ���� �׻� Action�� ��� �־�� �ϰ� ��Ʈ�� ������ �����ϰ�� ���� �帧 ���� ������ �����ϰ� �˴ϴ�.

    ActionNode an;
    public bool isCheck;

    private void Start()
    {
        an = new ActionNode();

        an.stateAction += () =>
        {
            Debug.Log("�׼�");
            if (isCheck)
                return INode.State.SUCCESS;
            else
                return INode.State.FAIL;
        };

        an.Evaluate();
    }
}
