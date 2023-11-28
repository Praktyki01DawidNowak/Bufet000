namespace Bufet000.Models
{
    public class Zamowienia
    {
        public int Id { get; set; }
        public string Zamowienie { get; set; }
        public DateTime Data { get; set; }
        public float Cena { get; set; }
        public int IdKanapki { get; set; }
        public Kanapki? Kanapki { get; set; }
        public int IdUzytkownik { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }
        public int IdStatus { get; set; }
        public Status? Status { get; set; }
    }
}