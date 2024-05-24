namespace TestChoucair.Domain.Model{
    public record TaskUserId(Guid Value) {
        public static TaskUserId New() => new(Guid.NewGuid());
    }
}