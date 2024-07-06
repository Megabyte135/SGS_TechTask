using Core;

public class Operator : BaseEntity
{
    public Guid Id { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
