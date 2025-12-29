using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.AppUI.Core;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MeleeAtack",description: "MeleeAtack", story: "[self] at forword MeleeAtack to [Range] is [damage] Atack and [Animation]", category: "Action", id: "20ba3a6db2b808a3a2b2796634fd3c49")]
public partial class MeleeAtackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> Range;
    [SerializeReference] public BlackboardVariable<int> Damage;
    [SerializeReference] public BlackboardVariable<AnimationClip> Animation;
    private Animation anim;
    protected override Status OnStart()
    {
        if (!anim) {
            anim = Self.Value.GetComponentInChildren<Animation>();
        }
        anim.Play(Animation.Value.name);
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector2 dir = Self.Value.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(Self.Value.transform.position, dir, out hit, Range.Value)) {
            Debug.Log("Melee Atack Hit: " + hit.collider.name);
        }

        if (!anim.IsPlaying(Animation.Value.name)) {
            return Status.Running;
        }


        return Status.Success;
    }

    protected override void OnEnd()
    {

    }
}

