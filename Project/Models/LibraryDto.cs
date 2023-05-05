namespace LibrariesPr.Models
{
    public class LibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public List<BookDto> Books { get; set; }

    }
}
