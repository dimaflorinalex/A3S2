namespace Lab.Models
{
    public class Stire
    {
        public required int Id { get; set; }

        public required string Titlu { get; set; }

        public required string Lead { get; set; }

        public required string Continut { get; set; }

        public required string Autor { get; set; }

        public required DateTime Data { get; set; }

        public required int CategorieId { get; set; }

        public Categorie? Categorie { get; set; }
    }
}
