namespace backend.DTOs
{
    public class AbonnementPerZakelijkeHuurderDTO
    {
        public int Id { get; set; }

        public required string Naam { get; set; }
        public double PrijsPerMaand { get; set; }
        public int MaxHuurders { get; set; }
        public required DateOnly Einddatum { get; set; }
        public required string Soort { get; set; }
        public List<string> ZakelijkeHuurders { get; set; }
    }
}
