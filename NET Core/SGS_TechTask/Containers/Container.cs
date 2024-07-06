using Core;

public class Container : BaseEntity
{

    public int? Number { get; set; }

    public string? Type { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Weight { get; set; }

    public bool? Empty { get; set; }

    public DateTime? ReceiptionDate { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
