using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BehaviourStrategy
{
    public enum TYPE
    {
        Melee,
        Ranged
    }
    public static class Factory
    {
        public static BehaviourStrategy Create(TYPE type)
        {
            switch (type)
            {
                case TYPE.Melee:
                    return new MeleeBehaviourStrategy();
                case TYPE.Ranged:
                    return new RangedBehaviourStrategy();
                default: 
                    return null;
            }
        }
    }
    public abstract void Behaviour();
}
public class MeleeBehaviourStrategy : BehaviourStrategy
{
    public override void Behaviour()
    {
        Debug.Log("������ �����鼭 ����");
    }
}

public class RangedBehaviourStrategy : BehaviourStrategy
{
    public override void Behaviour()
    {
        Debug.Log("�ָ� �������鼭 ����");
    }
}

//���丮�޼��� ���� : �ڽ�Ŭ�������� ��ü�� ������ å���������ϴ� ����
public abstract class Monster : MonoBehaviour
{
    public BehaviourStrategy behaviourStragety;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        behaviourStragety.Behaviour();
    }

    public abstract void Init();

}
