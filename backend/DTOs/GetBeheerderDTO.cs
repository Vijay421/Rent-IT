namespace backend.DTOs
{
    public class GetBeheerderDTO
    {
        public int Id { get; set; }
        public string Bedrijfsrol { get; set; }
        public string? UserName { get; set; }
        public List<int> ZakelijkeHuurders {  get; set; }
    }
}
