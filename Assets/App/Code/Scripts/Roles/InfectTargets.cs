using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InfectTargets :ScriptableObject
{
    public Material material;
    public List<InfectTargets> targets = new();
    
}
