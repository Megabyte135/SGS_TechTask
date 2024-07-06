using Core.Operations;

namespace Services.Operations.DTOs
{
    public class OperationCreateDto
    {
        public Guid ContainerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OperatorFullName { get; set; }
        public string Type { get; set; }
        public string InspectionPlace { get; set; }
    }
}
