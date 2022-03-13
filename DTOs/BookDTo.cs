namespace MyULibrary_API.DTOs
{
    public class BookDTo
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public int Stock { get; set; }
        public string GenreName { get; set; }
        public int GenreId { get; set; }
    }
}
