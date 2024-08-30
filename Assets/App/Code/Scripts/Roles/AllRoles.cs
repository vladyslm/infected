using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AllRoles : ScriptableObject
{
    public InfectTargets player;
    public InfectTargets infected;
    public InfectTargets clean;
    public InfectTargets cleaner;
}