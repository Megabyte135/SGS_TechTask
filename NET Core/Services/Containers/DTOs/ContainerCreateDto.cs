namespace Services.Containers.DTOs
{
    public class ContainerCreateDto
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public bool IsEmpty { get; set; }
        public DateTime ReceptionDate { get; set; }
    }
}
