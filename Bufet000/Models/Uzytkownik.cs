namespace Bufet000.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public ICollection<Zamowienia> Zamowienia { get; } = new List<Zamowienia>();
    }
}
