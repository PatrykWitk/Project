namespace Project.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }

        public int LibraryId { get; set; }
        
        public virtual Library Library { get; set; }
    }
}
