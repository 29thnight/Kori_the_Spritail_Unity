using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "lowerEquel percent", story: "[integer] LowerEquel [percent] at [int]", category: "Conditions", id: "59cfc79803e78017cb6a4079a2640bba")]
public partial class LowerEquelPercentCondition : Condition
{
    [SerializeReference] public BlackboardVariable<int> Integer;
    [SerializeReference] public BlackboardVariable<float> Percent;
    [SerializeReference] public BlackboardVariable<int> Int;

    public override bool IsTrue()
    {
        if (Percent == null || Int == null || Integer == null) 
        {
            Debug.LogWarning("LowerEquelPercentCondition: One or more variables are not set.");
            return false;
        }
        if (0 >= Percent) 
        {
            Debug.LogWarning("LowerEquelPercentCondition: Percent must be greater than 0.");
            return false;
        }
        if (Percent >= 1) 
        {
            Debug.LogWarning("LowerEquelPercentCondition: Percent must be less than 1.");
            return false;
        }
        
        return Integer <= Int*Percent;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
