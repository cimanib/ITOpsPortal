namespace ITOpsPortal.Models;

public abstract class Entity
{
    public int Id { get; set; }
    public Entity Copy() => (Entity)MemberwiseClone();
}
