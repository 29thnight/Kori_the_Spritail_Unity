using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DeadAction", story: "[self] is [dead]", category: "Action", id: "1558f620604238242a1c5aa6c5314185")]
public partial class DeadAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<bool> Dead;
    private Animator _animator;

    protected override Status OnStart()
    {

        if (!_animator) { 
            _animator= Self.Value.GetComponentInChildren<Animator>();
        }

        if (false == Dead.Value)
        {
            _animator.SetTrigger("IsDead");
        }


        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (false == Dead.Value)
        {
            Dead.Value = true;

            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

            var boss = Self.Value.GetComponent<Boss>();
            boss.isDead = true;
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

