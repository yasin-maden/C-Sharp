
using System.Globalization;
using System.Xml;

namespace Marmaray_Revize
{
    internal class Program
    {
        static MarmaraySistem marmaray = new MarmaraySistem();
        static List<string> marmarayDuraklari = new List<string> {
  "Gebze",
  "Darıca",
  "Osmangazi",
  "GTÜ – Fatih",
  "Çayırova",
  "Tuzla",
  "İçmeler",
  "Aydıntepe",
  "Güzelyalı",
  "Tersane",
  "Kaynarca",
  "Pendik",
  "Yunus",
  "Kartal",
  "Başak",
  "Atalar",
  "Cevizli",
  "Maltepe",
  "Süreyya Plajı",
  "İdealtepe",
  "Küçükyalı",
  "Bostancı",
  "Suadiye",
  "Erenköy",
  "Göztepe",
  "Feneryolu",
  "Söğütlüçeşme",
  "Ayrılık Çeşmesi",
  "Üsküdar",
  "Sirkeci",
  "Yenikapı",
  "Kazlıçeşme",
  "Fişekhane",
  "Yenimahalle",
  "Bakırköy",
  "Ataköy",
  "Yeşilyurt",
  "Yeşilköy",
  "Florya Akvaryum",
  "Florya",
  "Küçükçekmece",
  "Mustafa Kemal",
  "Halkalı"
};
        static void Main(string[] args)
        {
            DuraklariEkle();
            while (true)
            {
                Menu();
            }
        }
        private static void Menu()
        {

            Console.WriteLine("----------------MARMARAY----------------");
            Console.WriteLine("1) Kişileri Listele");
            Console.WriteLine("2) Kişi Ekle");
            Console.WriteLine("3) Yolculuk Ekle");
            Console.WriteLine("4) Z Raporu Göster");
            Console.WriteLine("5) Çıkış");
            Console.WriteLine("----------------------------------------");

            int secim = GetInput.getChoice("Seçiminizi yapınız: ", 1, 5);
            Console.Clear();

            switch (secim)
            {
                case 1:
                    KisileriListele();
                    break;
                case 2:
                    KisiEkle();
                    break;
                case 3:
                    Console.WriteLine("Yolculuk Ekleniyor...");
                    YolculukEkle();
                    break;
                case 4:
                    ZRaporuYazdir();
                    break;
                case 5:
                    Console.WriteLine("Çıkış yapılıyor...");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void ZRaporuYazdir()
        {
            marmaray.ZRaporuOlustur();
        }

        private static void YolculukEkle()
        {
            KisileriListele();
            int secim = GetInput.GetInt("Yolculuk yapacak kişinin Id'sini giriniz: ");
            Kisi yolcu = marmaray.Kisiler[secim];

            DuraklariListele();
            int binilenDurak = GetInput.GetInt("Binilen durak Id'sini giriniz: ");

            DuraklariListele();
            int inilenDurak = GetInput.GetInt("İnilecek durak Id'sini giriniz: ");

            string abonmanTipi = GetInput.GetString("Abonman tipini giriniz: ");

            AbonmanTuru abonmanTuru = (AbonmanTuru)Enum.Parse(typeof(AbonmanTuru), abonmanTipi, true);
            Console.WriteLine("Abonman tipi: " + abonmanTuru);

            string iadeCevap = GetInput.GetString("İade yapılacak mı? (E/H): ");
            bool iadeYapilacakMi = iadeCevap.ToLower() == "e" ? true : false;
            Yolculuk yolculuk = new Yolculuk()
            {
                Yolcu = yolcu,
                Binis = marmaray.Duraklar[binilenDurak],
                Inis = marmaray.Duraklar[inilenDurak],
                Abonman = abonmanTuru,
                Tarih = DateTime.Now,
                IadeYapilacakMi = iadeYapilacakMi
            };
            Console.Clear();

            marmaray.YolculukEkle(yolculuk);

        }

        private static void DuraklariListele()
        {
            marmaray.Duraklar.ForEach(durak =>
            {
                Console.WriteLine($"{durak.Id} - Durak Adı: {durak.Name}");
            });
        }

        private static void DuraklariEkle()
        {
            int counter = 0;
            foreach (var item in marmarayDuraklari)
            {
                marmaray.DurakEkle(new Durak { Name = item, Id = counter });
                counter++;
            }
        }

        private static void KisileriListele()
        {
            Console.WriteLine("---------------KİŞİ LİSTESİ---------------");
            int counter = 0;
            marmaray.Kisiler.ForEach(kisi =>
            {
                Console.WriteLine($"{counter} | {kisi.AdSoyad}|\t|\tid: {kisi.Id}");
                counter++;
            });
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void KisiEkle()
        {
            Console.WriteLine("-------------KİŞİ EKLEME EKRANI-------------");
            Kisi eklencekKisi = new Kisi();
            eklencekKisi.AdSoyad = GetInput.GetString("Kişi Adı Soyadı: ");
            eklencekKisi.Id = GetInput.getPositiveInt("Kişi Id: ");
            marmaray.KisiEkle(eklencekKisi);
        }
    }
}
