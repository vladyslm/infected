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
        if (obj.RoleTargets == ParentRole.RoleTargets.allRoles.player)
        {
            ParentRole.RoleTargets = ParentRole.RoleTargets.allRoles.infected;
            ParentRole.CheckCharacter();
        }

        if (obj.RoleTargets == ParentRole.RoleTargets.allRoles.infected)
        {
            ParentRole.RoleTargets = ParentRole.RoleTargets.allRoles.infected;
            ParentRole.CheckCharacter();
            return;
        }

        if (obj.RoleTargets == ParentRole.RoleTargets.allRoles.cleaner)
        {
            ParentRole.RoleTargets = ParentRole.OriginalRole;
            ParentRole.CheckCharacter();
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
        if (obj.RoleTargets == ParentRole.RoleTargets.allRoles.player)
        {
            ParentRole.RoleTargets = ParentRole.RoleTargets.allRoles.infected;
            ParentRole.CheckCharacter();
        }

        if (obj.RoleTargets == ParentRole.RoleTargets.allRoles.cleaner)
        {
            ParentRole.RoleTargets = ParentRole.OriginalRole;
            ParentRole.CheckCharacter();
        }
    }
}