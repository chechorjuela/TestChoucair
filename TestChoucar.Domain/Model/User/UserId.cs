namespace TestChoucair.Domain.Model{
    public record UserId(Guid Value) {
        public static UserId New() => new(Guid.NewGuid());
    }
}