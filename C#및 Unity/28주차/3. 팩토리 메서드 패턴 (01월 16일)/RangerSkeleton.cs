using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerSkeleton : Skeleton
{
    public override void Init()
    {
        behaviourStragety = BehaviourStrategy.Factory.Create(BehaviourStrategy.TYPE.Ranged);
    }
}
