namespace TestChoucair.Domain.Permissions
{

    public sealed class Permission : Entity<PermissionId>
    {
        public Nombre? Nombre { get; init; }

        public Permission(PermissionId id, Nombre nombre) : base(id)
        {
            Nombre = nombre;
        }

    }
}