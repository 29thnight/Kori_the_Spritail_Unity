using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Percent lower", story: "[integer] lower [percent]", category: "Conditions", id: "21f0a60134b676c0ebf88464755b6b39")]
public partial class PercentLowerCondition : Condition
{
    [SerializeReference] public BlackboardVariable<int> Integer;
    [SerializeReference] public BlackboardVariable<float> Percent;

    public override bool IsTrue()
    {
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
