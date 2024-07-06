namespace Services.Operations.DTOs
{
    public class OperationDto
    {
        public Guid Id { get; set; }
        public Guid ContainerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OperatorFullName { get; set; }
        public string Type { get; set; }
        public string InspectionPlace { get; set; }
    }
}
