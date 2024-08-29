using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanRole : MonoBehaviour, IRoleAction
{
    [SerializeField] private AllRoles allRoles;
    [SerializeField] private InfectTargets role;


    private InfectTargets _originalRole;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _originalRole = role;
        _renderer = transform.GetComponent<MeshRenderer>();
    }
    
    public InfectTargets RoleTargets
    {
        get => role;
        set => role = value;
    }

    public void OnCollisionAction(IRoleAction obj)
    {
        if (obj.RoleTargets == allRoles.player)
        {
            role = allRoles.infected;
            _renderer.material = role.material;
            return;
        }

        if (obj.RoleTargets == allRoles.infected)
        {
            role = allRoles.infected;
            _renderer.material = role.material;
            return;
        }

        if (obj.RoleTargets == allRoles.cleaner)
        {
            role = _originalRole;
            _renderer.material = role.material;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        var target = other.transform.GetComponent<IRoleAction>();
        if (target != null)
        {
            if (role.targets.Contains(target.RoleTargets))
            {
                target.OnCollisionAction(this);
            }
        }
    }
}