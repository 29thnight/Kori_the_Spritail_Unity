using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Modifier = Unity.Behavior.Modifier;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PercentRandom", story: "[item] as [percent] access", category: "Flow", id: "8fea4b772ed1b46362aa451a18cdd16a")]
public partial class PercentRandomModifier : Modifier
{
    [SerializeReference] public BlackboardVariable<BehaviorGraph> Item;
    [SerializeReference] public BlackboardVariable<List<float>> Percent;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

