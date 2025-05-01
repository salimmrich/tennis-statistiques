namespace TennisStats.Application.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Shortname { get; set; }
        public string Sex { get; set; }
        public string CountryCode { get; set; }
        public string Picture { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public List<int> LastResults { get; set; }
    }
}
