using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface IBehavior
{
    void OnCollisionAction(Role obj);
}


public class Role : MonoBehaviour
{
    [SerializeField] private InfectTargets role;
    [SerializeField] private UnityEvent onCollisionAction;

    private InfectTargets _originalRole;
    private Renderer _renderer;

    private IBehavior _roleBehavior;

    public InfectTargets RoleTargets
    {
        get => role;
        set => role = value;
    }

    public InfectTargets OriginalRole => _originalRole;


    void Start()
    {
        _originalRole = role;
        _renderer = transform.GetComponent<MeshRenderer>();

        if (role == role.allRoles.clean)
        {
            _roleBehavior = new CleanBehaviour(this);
        }

        if (role == role.allRoles.cleaner)
        {
            _roleBehavior = new CleanerBehaviour(this);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log($"{transform.name} collides with {other.transform.name}");
        var target = other.transform.GetComponent<Role>();
        if (target == null) return;
        if (!role.targets.Contains(target.RoleTargets)) return;
        // Debug.Log($"{transform.name} says {other.transform.name} is a valid target");
        target.OnCollisionAction(this);
        onCollisionAction?.Invoke();
    }

    public void OnCollisionAction(Role obj)
    {
        // Debug.Log($"{this.name} collides with: {obj} that has {obj.role}");
        _roleBehavior.OnCollisionAction(obj);
    }

    public void ApplyMaterial(Material material)
    {
        _renderer.material = material;
    }
}