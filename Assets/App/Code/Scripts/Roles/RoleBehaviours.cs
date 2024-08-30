public abstract class AbstractBehaviour
{
    protected Role ParentRole;
}

public class CleanBehaviour : AbstractBehaviour, IBehavior
{
    public CleanBehaviour(Role parentRole)
    {
        ParentRole = parentRole;
    }

    public void OnCollisionAction(Role obj)
    {
        if (obj.RoleTargets == ParentRole.allRoles.player)
        {
            ParentRole.RoleTargets = ParentRole.allRoles.infected;
            ParentRole.ApplyMaterial(ParentRole.RoleTargets.material);
        }

        if (obj.RoleTargets == ParentRole.allRoles.infected)
        {
            ParentRole.RoleTargets = ParentRole.allRoles.infected;
            ParentRole.ApplyMaterial(ParentRole.RoleTargets.material);
            return;
        }

        if (obj.RoleTargets == ParentRole.allRoles.cleaner)
        {
            ParentRole.RoleTargets = ParentRole.OriginalRole;
            ParentRole.ApplyMaterial(ParentRole.RoleTargets.material);
        }
    }
}


public class CleanerBehaviour : AbstractBehaviour, IBehavior
{
    public CleanerBehaviour(Role parentRole)
    {
        {
            ParentRole = parentRole;
        }
    }

    public void OnCollisionAction(Role obj)
    {
        if (obj.RoleTargets == ParentRole.allRoles.player)
        {
            ParentRole.RoleTargets = ParentRole.allRoles.infected;
            ParentRole.ApplyMaterial(ParentRole.RoleTargets.material);
        }

        if (obj.RoleTargets == ParentRole.allRoles.cleaner)
        {
            ParentRole.RoleTargets = ParentRole.OriginalRole;
            ParentRole.ApplyMaterial(ParentRole.RoleTargets.material);
        }
    }
}