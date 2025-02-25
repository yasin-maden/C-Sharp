using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace Otopark
{
    internal class Program
    {
        public static List<Arac> araclar = new List<Arac>();
        public static Otopark otopark = new Otopark();
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
        private static void Menu()
        {
            Console.WriteLine("--------------OTOPARK--------------");
            Console.WriteLine("1- Arac listesi");
            Console.WriteLine("2- Arac ekle");
            Console.WriteLine("3- Giriş bilgisi ekle");
            Console.WriteLine("4- Çıkış bilgisi ekle");
            Console.WriteLine("5- Otoparktaki araçlar");
            Console.WriteLine("6- Z Raporu");
            Console.WriteLine("--------------OTOPARK--------------");

            Console.Write("Seçiminiz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    AracListesi();
                    break;
                case 2:
                    AracEkle();
                    break;
                case 3:
                    GirisBilgisiEkle();
                    break;
                case 4:
                    CikisBilgisiEkle();
                    break;
                case 5:
                    OtoparktakiAraclar();
                    break;
                case 6:
                    ZRaporu();
                    break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız.");
                    break;
            }
        }

        private static void ZRaporu()
        {
            Console.WriteLine("Alınan ücretlerin listesi");
            int counter = 1;    
            foreach (var item in otopark.Ucret)
            {
                Console.WriteLine($"{counter} - {item}");
                counter++;
            }
            Console.WriteLine("-------------------------------");
            counter = 1;
            foreach (var item in araclar)
            {
                Console.WriteLine($"{counter} - {item}");
                counter++;
            }
        }

        private static void OtoparktakiAraclar()
        {
            Console.WriteLine("otoparktaki araçlar");
            foreach (var item in otopark.Arac)
            {
                Console.WriteLine($"Plaka: {item.Plaka}\tAraç Tipi: {item.AracTipi}");
            }
        }

        private static void CikisBilgisiEkle()
        {
            Random random = new Random();
            Console.WriteLine("Araç sec: ");
            foreach (var item in otopark.Arac)
            {
                Console.WriteLine($"Plaka: {item.Plaka}\tAraç Tipi: {item.AracTipi}");
            }
            int secim = int.Parse(Console.ReadLine());

            DateTime cikisSaati = otopark.GirisSaati[otopark.Arac[secim]].AddHours(random.Next(1, 7)).AddMinutes(random.Next(1, 60));

            int saatFarkı = otopark.GirisSaati[otopark.Arac[secim]].Hour - cikisSaati.Hour;
            double ucret = UcretHesapla(otopark.Arac[secim], saatFarkı);
            otopark.Ucret.Add(ucret);
            otopark.CikisSaati.Add(otopark.Arac[secim], cikisSaati);

            otopark.Arac.Remove(otopark.Arac[secim]);
        }

        private static void GirisBilgisiEkle()
        {
            Random random = new Random();
            Console.WriteLine("Araç sec: ");
            AracListesi();
            int secim = int.Parse(Console.ReadLine());
            Console.WriteLine(araclar[secim].Plaka);
            otopark.Arac.Add(araclar[secim]);
            otopark.GirisSaati.Add(
                araclar[secim],
                DateTime.Now.AddHours(random.Next(1, 3)).AddMinutes(random.Next(1, 60))
                );



        }

        private static double UcretHesapla(Arac arac, int saat)
        {
            List<int> temelUcret = new List<int> { 80, 110, 130, 170, 210, 310 };
            switch (arac.AracTipi)
            {
                case "otomobil":
                    if (0 <= saat && saat <= 1)
                        return temelUcret[0];
                    else if (1 < saat && saat <= 2)
                        return temelUcret[1];
                    else if (2 < saat && saat <= 4)
                        return temelUcret[2];
                    else if (4 < saat && saat <= 8)
                        return temelUcret[3];
                    else if (8 < saat && saat <= 12)
                        return temelUcret[4];
                    else
                        return temelUcret[5];
                case "minibus":
                    if (0 <= saat && saat <= 1)
                        return 2 * temelUcret[0];
                    else if (1 < saat && saat <= 2)
                        return 2 * temelUcret[1];
                    else if (2 < saat && saat <= 4)
                        return 2 * temelUcret[2];
                    else if (4 < saat && saat <= 8)
                        return 2 * temelUcret[3];
                    else if (8 < saat && saat <= 12)
                        return 2 * temelUcret[4];
                    else
                        return 2 * temelUcret[5];
                case "otobus":
                    if (0 <= saat && saat <= 1)
                        return 3 * temelUcret[0];
                    else if (1 < saat && saat <= 2)
                        return 3 * temelUcret[1];
                    else if (2 < saat && saat <= 4)
                        return 3 * temelUcret[2];
                    else if (4 < saat && saat <= 8)
                        return 3 * temelUcret[3];
                    else if (8 < saat && saat <= 12)
                        return 3 * temelUcret[4];
                    else
                        return 3 * temelUcret[5];
                case "motosiklet":
                    if (0 <= saat && saat <= 1)
                        return 0.5 * temelUcret[0];
                    else if (1 < saat && saat <= 2)
                        return 0.5 * temelUcret[1];
                    else if (2 < saat && saat <= 4)
                        return 0.5 * temelUcret[2];
                    else if (4 < saat && saat <= 8)
                        return 0.5 * temelUcret[3];
                    else if (8 < saat && saat <= 12)
                        return 0.5 * temelUcret[4];
                    else
                        return 0.5 * temelUcret[5];
                default:
                    Console.WriteLine("Hatalı araç tipi");
                    return -1;
            }

        }

        private static void AracEkle()
        {
            Arac arac = new Arac();
            Console.Write("Plaka: ");
            arac.Plaka = Console.ReadLine();
            Console.Write("Araç Tipi: ");
            arac.AracTipi = Console.ReadLine();
            araclar.Add(arac);
        }

        private static void AracListesi()
        {
            int counter = 0;
            foreach (var item in araclar)
            {
                Console.WriteLine($"{counter} - Plaka: {item.Plaka}\tAraç Tipi: {item.AracTipi}");
                counter++;
            }
        }
        public class Arac
        {
            public string Plaka { get; set; }
            public string AracTipi { get; set; }
        }
        public class Otopark
        {
            public List<Arac> Arac { get; set; } = new List<Arac>();
            public Dictionary<Arac, DateTime> GirisSaati { get; set; } = new Dictionary<Arac, DateTime>();
            public Dictionary<Arac, DateTime> CikisSaati { get; set; } = new Dictionary<Arac, DateTime>();
            public List<double> Ucret { get; set; } = new List<double>();
        }
    }
}
/*
 * OOP: otopark otomasyon programı
 * 
 * araç plakası, giriş saati, araç tipi, çıkış saati, ücret
 */