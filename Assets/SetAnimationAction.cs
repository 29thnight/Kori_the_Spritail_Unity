using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Animation", story: "[Self] Set [Animationclip] to animation", category: "Action", id: "1e17ad7d8697a0b63df9b9e4eff561c8")]

public partial class SetAnimationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    
    private Animation anim;
    protected override Status OnStart()
    {

        if (!anim) {
            anim = Self.Value.GetComponentInChildren<Animation>();
        }
        

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

