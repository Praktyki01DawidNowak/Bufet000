namespace Bufet000.Models
{
    public class Kanapki
    {
        public int Id { get; set; }
        public int IdKategoria { get; set; }
        public Kategoria? Kategoria { get; set; }
        public string Skladniki { get; set; }
        public bool CzyDostepne { get; set; }
        public ICollection<Zamowienia> Zamowienia { get; } = new List<Zamowienia>();
    }
}