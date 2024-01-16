using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSkeleton : Skeleton
{
    public override void Init()
    {
        behaviourStragety = BehaviourStrategy.Factory.Create(BehaviourStrategy.TYPE.Melee);
    }
}
