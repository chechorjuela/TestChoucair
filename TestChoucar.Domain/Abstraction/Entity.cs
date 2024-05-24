using TestChoucair.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity
{
    protected Entity()
    {

    }
    
    protected Entity(TEntityId id)
    {
        Id = id;
    }
    
    public TEntityId? Id {get ; init;}

 

    public void ClearDomainEvents()
    {
    }


}