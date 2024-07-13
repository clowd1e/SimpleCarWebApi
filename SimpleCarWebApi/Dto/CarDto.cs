namespace SimpleCarWebApi.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double TopSpeed { get; set; }
    }
}
