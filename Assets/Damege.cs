using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Damege")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Damege", message: "demage", category: "Events", id: "a07a077d38cadf60a2463ec85d0f7829")]
public sealed partial class Damege : EventChannel {
    
}

