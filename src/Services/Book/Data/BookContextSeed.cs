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
                    Name = "Beş Dakika Daha - Marta Altés - Marta Altes",
                    Writer ="Marta Altes",
                    Publisher = "Domingo Yayınevi",
                    Price = 54,
                    Year = "2023",
                    ImageFile = "book-1.png",
                    Abstract = "uhaf şey şu zaman. Sürekli babamın dilinde. Ama ben babamdan daha iyi anlıyorum zamanı."
                },
                     new Entities.Book()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Yüzler ve Sözler - Gülten Dayıoğlu",
                    Writer ="Gülten Dayıoğlu",
                    Publisher = "Yapı Kredi Yayınları",
                    Price = 77,
                    Year = "2023",
                    ImageFile = "book-2.png",
                    Abstract = "Yazmaya başladığım bu yaşam maratonu paylaşımları, bilindik nitelikte bir anı kitabı olmayacak. Anlatıların baş kahramanları, yaşam maratonunda karşılaştığım, cumhurbaşkanından, hapisanedeki tutukluya, en varlıklıdan, pek yoksula, aydından, kara cahile, en ünlüden, en sıradana, canını sevdiğim insanlar olacak… Bu paylaşımlarda tanıdıklarınıza, hatta kendinize bile rastlayabilirsiniz. Açıkçası, epey kalabalık olacağız. Kahramanlarımız, en belirgin özellikleriyle, olabildiğince kısa kısa, bu paylaşımlarda yer alacak. Üç kuşak boyunca çocukların okuyup sevdiği Gülten Dayıoğlu bu kez eski bir telefon defterinin kılavuzluğunda “büyükler” için yazıyor. Tanıştığı, yollarının kesiştiği kişilerin portreleri, tanık olduğu, kimi zaman beslendiği olaylara ilişkin izlenimleri ve anıları yazarın iç dünyasına da benzersiz bir kapı aralıyor."
                },    new Entities.Book()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Bana Rağmen",
                    Publisher = "Masa Kitap",
                    Price = 53,
                    Year = "2022",
                    ImageFile = "book-3.png",
                    Abstract = "Biz kendi ayakları üzerinde durmaya çalışan Ortadoğu’nun kadınlarıydık. Bir şey yapmak istediğimizde önce kuşkuyla bakılan, işin başına geçtiğimizde de olmamasına dair gerekçelerle boğulan... Buna rağmen vazgeçmeme düşüncesizliğini gösterirsek de tüm gözlerin üzerimize çevrildiği, açık arandığı bir podyuma çıkardık."
                }
            };
        }
    }
}