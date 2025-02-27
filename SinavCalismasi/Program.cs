using Newtonsoft.Json;

namespace SinavCalismasi
{
    internal class Program
    {
        static List<Person> persons = new List<Person>();
        static Person selectedPerson = new Person();
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("---MARMARAY---");
            Console.WriteLine("1) Kişileri Listele");
            Console.WriteLine("2) Yeni Kişi Ekle");
            Console.WriteLine("3) Yeni Yolculuk Ekle");
            Console.WriteLine("4) Z Raporu Görüntüle");
            Console.WriteLine("--------------");

            int islem = GetInput.GetChoice("Lütfen yapmak istediğiniz seçimi giriniz: ", 1, 4);

            switch (islem)
            {
                case 1:
                    //Kişi Listele
                    KisiListele();
                    break;
                case 2:
                    //Kişi Ekle
                    KisiEkle();
                    break;
                case 3:
                    //Kişi Seç
                    KisiSec();

                    //Yolculuk Ekle
                    YolculukEkle();
                    //Yolculuk işlemini kaydet

                    break;
                case 4:
                    //Z Raporu Görüntüle
                    break;
              
                default:
                    break;
            }
        }

        private static void YolculukEkle()
        {

        }

        private static void KisiSec()
        {
            KisiListele();
            int secim = GetInput.GetPositiveInt("Kişi seç: ");
            if (secim < 1 || secim > persons.Count)
            {
                Console.WriteLine("Geçersiz seçim.");
                return;
            }
            selectedPerson = persons[secim - 1];
        }

        private static void KisiListele()
        {
            //Önceden Kaydedilmiş Kişileri Yükle
            DosyadanOku(ref persons, JsonName.Persons);

            int counter = 1;
            if (persons.Count == 0)
            {
                Console.WriteLine("Henüz hiç kişi eklenmemiş.");
                return;
            }
            foreach (var person in persons)
            {
                Console.WriteLine($"{counter}: | Id: {person.Id}, İsim: {person.Name}");
                counter++;
            }
        }

        private static void KisiEkle()
        {
            string name = GetInput.GetString("İsim Soyisim: ");
            int id = GetInput.GetPositiveInt("Kişi Id: ");

            //Önceden Kaydedilmiş Kişileri Yükle
            DosyadanOku(ref persons, JsonName.Persons);

            if (persons.Any(p => p.Id == id))
            {
                Console.WriteLine("Bu id ile kayıtlı bir kişi zaten var.");
                return;
            }
            Person newPerson = new Person() { Id = id, Name = name };

            persons.Add(newPerson);
            DosyayaYaz(ref persons, JsonName.Persons);
        }
        private static void DosyayaYaz<T>(ref List<T> list, JsonName name)
        {
            // JSON formatına çevirme
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);

            // dosya adını belirle
            string filePath = name.ToString().ToLower() + ".json";

            // dosyaya yaz
            File.WriteAllText(filePath, json);
        }

        private static void DosyadanOku<T>(ref List<T> list, JsonName name)
        {
            // dosya adını belirle
            string filePath = name.ToString().ToLower() + ".json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var deserializedObject = JsonConvert.DeserializeObject<List<T>>(json);
                if (deserializedObject != null)
                {
                    list = deserializedObject;
                }
                else
                {
                    Console.WriteLine($"{filePath} dosyası boş veya hatalı.");
                }
            }
        }
    }
}
