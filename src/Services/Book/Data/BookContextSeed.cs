using MongoDB.Driver;



namespace Book.API.Data
{
    public class BookContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Book> bookCollection)
        {
            bool existBook = bookCollection.Find(p => true).Any();
            if (!existBook)
            {
                bookCollection.InsertManyAsync(GetPreconfiguredBooks());
            }
        }

        private static IEnumerable<Entities.Book> GetPreconfiguredBooks()
        {
            return new List<Entities.Book>()
            {
                new Entities.Book()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Brand = "book",
                    Model = "asd",
                    Price = 300000,
                    Year = "2011",
                    ImageFile = "book-1.png",
                    DrivedCountKm = 120000
                },
                new Entities.Book()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Brand = "Opel",
                    Model = "Astra",
                    Price = 212033,
                    Year = "2010",
                    ImageFile = "book-2.png",
                    DrivedCountKm = 121123
                },
                new Entities.Book()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Brand = "Opel",
                    Model = "Astra",
                    Price = 212033,
                    Year = "2010",
                    ImageFile = "book-2.png",
                    DrivedCountKm = 121123
                }
            };
        }
    }
}