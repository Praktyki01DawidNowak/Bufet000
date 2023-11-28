namespace Bufet000.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Etap { get; set; }
        public ICollection<Zamowienia> Zamowienia { get; } = new List<Zamowienia>();
    }
}
