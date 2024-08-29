using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IRoleAction
{
    InfectTargets RoleTargets { get; set; }

    void OnCollisionAction(IRoleAction obj);
}

public class Role : MonoBehaviour, IRoleAction
{
    [SerializeField] private InfectTargets role;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{transform.name} collides with {other.transform.name}");
        var target = other.transform.GetComponent<IRoleAction>();
        if (target != null)
        {
            if (role.targets.Contains(target.RoleTargets))
            {
                target.OnCollisionAction(this);
            }
        }
    }

    public InfectTargets RoleTargets
    {
        get => role;
        set => role = value;
    }

    public void OnCollisionAction(IRoleAction obj)
    {
        Debug.Log($"{this.name} collides with: {obj}");
    }
}