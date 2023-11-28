namespace Bufet000.Models
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Kanapki> Kanapki { get; } = new List<Kanapki>();
    }
}