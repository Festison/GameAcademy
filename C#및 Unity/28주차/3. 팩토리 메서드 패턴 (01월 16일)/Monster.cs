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
        Debug.Log("가까이 붙으면서 공격");
    }
}

public class RangedBehaviourStrategy : BehaviourStrategy
{
    public override void Behaviour()
    {
        Debug.Log("멀리 떨어지면서 공격");
    }
}

//팩토리메서드 패턴 : 자식클래스에서 객체의 생성을 책임지도록하는 패턴
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
