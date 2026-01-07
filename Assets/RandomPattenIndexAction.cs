using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Random = UnityEngine.Random;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RandomPattenIndex", story: "set [watightlist] watight to [pattanEnum]", category: "Action", id: "d4573b120e60b72c4232fb522e230db8")]
public partial class RandomPattenIndexAction : Action
{
    [SerializeReference] public BlackboardVariable<List<float>> Watightlist;
    [SerializeReference] public BlackboardVariable<Phase1Enum> PattanEnum;

    int selectedIndex = -1;
    protected override Status OnStart()
    {
        int pattenCount = Enum.GetValues(typeof(Phase1Enum)).Length;
        int waightCount = Watightlist.Value.Count; 

        /*Debug.Log("Pattern Count: " + pattenCount);
        Debug.Log("Weight Count: " + waightCount);*/

        if (pattenCount != waightCount) {
            Debug.LogError("Pattern count and weight count do not match!");
            return Status.Failure;
        }

        float totalWeight = 0f;

        foreach (var weight in Watightlist.Value) {
            if (weight < 0f) {
                Debug.LogError("Weight cannot be negative!");
                return Status.Failure;
            }

            totalWeight += weight;
        }

        float randomValue = Random.Range(0f, totalWeight);

        float acc = 0f;

        for (int i = 0; i < Watightlist.Value.Count; i++) {
            acc += Watightlist.Value[i];
            if (randomValue < acc) {
                selectedIndex = i;
                break;
            }
        }


        /*Phase1Enum selectedPattern = (Phase1Enum)selectedIndex;

        PattanEnum.Value = selectedPattern;*/


        return Status.Running;
    }

    protected override Status OnUpdate()
    {

        if (!Enum.IsDefined(typeof(Phase1Enum), selectedIndex))
            return Status.Failure;

        PattanEnum.Value = (Phase1Enum)selectedIndex;

        Debug.Log("Selected Pattern: " + PattanEnum.Value);
        
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

