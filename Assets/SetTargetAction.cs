using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set target", story: "[self] setting [target] to [player1] or [player2]", category: "Action", id: "eed126982feb92f7dbc4ff5094fd9455")]
public partial class SetTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Player1;
    [SerializeReference] public BlackboardVariable<GameObject> Player2;
    protected override Status OnStart()
    {
        GameObject player1 = Player1.Value;
        GameObject player2 = Player2.Value;

        if (UnityEngine.Random.value < 0.5f) {
            Target.Value = player1;
        }
        else {
            Target.Value = player2;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Self.Value.GetComponent<Transform>().LookAt(Target.Value.GetComponent<Transform>());


        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

