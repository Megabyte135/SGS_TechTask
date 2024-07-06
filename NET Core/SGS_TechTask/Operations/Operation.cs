using Core;

public class Operation : BaseEntity
{
    public Guid Id { get; set; }

    public Guid? ContainerId { get; set; }

    public Guid? OperatorId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Type { get; set; }

    public string? InspectionPlace { get; set; }

    public virtual Container? Container { get; set; }

    public virtual Operator? Operator { get; set; }
}
