
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Marmaray
{
    public class Data
    {
        public string Id { get; set; }
        public double Kazanc { get; set; }
    }
    public enum Abonman
    {
        Ogrenci,
        Tam,
        Ucretsiz
    }
    internal class Program
    {
        public static Dictionary<DateTime, double> kazanclar = new Dictionary<DateTime, double>();
        public static Dictionary<string, double> kazanclarIsim = new Dictionary<string, double>();
        public static Dictionary<int, string> duraklar = new Dictionary<int, string>();
        public static Dictionary<string, string> kisiler = new Dictionary<string, string>();
        public static Dictionary<string, string> abonmanlar = new Dictionary<string, string>();
        public static List<Data> _data = new List<Data>();
        public static string aktifKullaniciId = "";

        static void Main(string[] args)
        {

            BilgiGoster();
            List<string> duraklarIsımleri = new List<string> { "Gebze",
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
                "Göztepe", "Feneryolu", "Söğütlüçeşme", "Ayrılık Çeşmesi", "Üsküdar",
                "Sirkeci", "Yenikapı", "Kazlıçeşme", "Fişekhane", "Yenimahalle", "Bakırköy", "Ataköy", "Yeşilyurt", "Yeşilköy", "Florya Akvaryum", "Florya", "Küçükçekmece", "Mustafa Kemal", "Halkalı"};

            for (int i = 0; i < duraklarIsımleri.Count; i++)
            {
                duraklar.Add(i + 1, duraklarIsımleri[i]);
            }


            IslemSec();

        }

        private static void BilgiGoster()
        {
            Console.WriteLine("------MARMARAY------");
            Console.WriteLine("1) Nereden bindiniz?");
            Console.WriteLine("2) Nerede ineceksiniz?");
            Console.WriteLine("3) Z - Raporu al");
            Console.WriteLine("4) Giriş yap");
            Console.WriteLine("0) Çıkış yap");
            Console.WriteLine("------MARMARAY------");

            //Console.WriteLine("4) Kart bakiyesi öğren");
            //Console.WriteLine("5) Karta bakiye yükle");
        }

        private static void GirisYap()
        {

            Console.Write("İsim Soyisim: ");
            string isim = Console.ReadLine();

            Console.Write("Id: ");
            aktifKullaniciId = Console.ReadLine();
            kisiler.Add(aktifKullaniciId, isim);

            Console.Write("abonman türü: ");
            string abonmanTuru = Console.ReadLine().ToLower();
            abonmanlar.Add(aktifKullaniciId, abonmanTuru);
            Console.Clear();
        }

        private static void IslemSec()
        {
            int islem;
            int binilenDurakIndex = -1;
            int inilenDurakIndex;

            do
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz: ");
            }
            while (!int.TryParse(Console.ReadLine(), out islem));

            switch (islem)
            {
                case 0:
                    Cikis();
                    break;

                case 1:
                    NeredenBindi(out binilenDurakIndex);
                    Console.Clear();
                    Console.WriteLine("Anlık kazanç: " + kazanclar.ElementAt(kazanclar.Count - 1));
                    BilgiGoster();
                    IslemSec();
                    break;

                case 2:
                    NeredeIndi(out inilenDurakIndex, binilenDurakIndex);
                    Console.Clear();
                    Console.WriteLine("Anlık kazanç: " + kazanclar.ElementAt(kazanclar.Count - 1));
                    BilgiGoster();
                    IslemSec();
                    break;

                case 3:
                    ZRaporu();
                    BilgiGoster();
                    IslemSec();
                    break;

                case 4:
                    GirisYap();
                    BilgiGoster();
                    IslemSec();
                    break;
                default:
                    Console.WriteLine("Hatalı işlem seçildi");
                    break;
            }

        }

        private static void ZRaporu()
        {
           

            // write to json
            var json = JsonSerializer.Serialize(new Data()
            {
                Id = aktifKullaniciId,
                Kazanc = 100
            });
            Console.WriteLine(json);

            // write to file
            System.IO.File.WriteAllText("data.json", json);

            int counter = 0;
            Console.WriteLine("------Z RAPORU------");
            for (int i = 0; i <= kazanclar.Count - 1; i++)
            {
                var item = kazanclar.ElementAt(i);
                var itemKey = item.Key;
                var itemValue = item.Value;

                Console.WriteLine($"Tarih: {itemKey}\tkazanç: {itemValue}");
            }
        }

        private static void NeredeIndi(out int inilenDurak, int binilenDurak)
        {
            Console.Clear();
            foreach (var item in duraklar)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            do
            {
                Console.Write("Lütfen indiğiniz durağı seçiniz: ");
            }
            while (!int.TryParse(Console.ReadLine(), out inilenDurak));

            Console.WriteLine("İade almak istiyor musunuz?");
            string secim = Console.ReadLine().ToLower();
            if (secim == "e")
            {
                double iadeUcreti = IadeYap(binilenDurak, inilenDurak);
                kazanclar.Add(DateTime.Now, iadeUcreti * -1);

                _data.Add(new Data()
                {
                    Id = aktifKullaniciId,
                    Kazanc = 210
                });
            }

        }

        private static double IadeYap(int binilenDurak, int inilenDurak)
        {
            int gidilenDurakSayisi = Math.Abs(binilenDurak - inilenDurak);
            int ucretlendirmeSeviyesi = gidilenDurakSayisi / 7;
            double tamBilet = 59.76;
            if (ucretlendirmeSeviyesi == 0)
                return tamBilet - 17.70;
            else if (ucretlendirmeSeviyesi == 1)
                return tamBilet - 22.76;
            else if (ucretlendirmeSeviyesi == 2)
                return tamBilet - 26.27;
            else if (ucretlendirmeSeviyesi == 3)
                return tamBilet - 30.30;
            else if (ucretlendirmeSeviyesi == 4)
                return tamBilet - 35.39;
            else if (ucretlendirmeSeviyesi == 5)
                return tamBilet - 39.18;
            else
                return 0;
        }

        private static void NeredenBindi(out int binilenDurak)
        {
            Console.Clear();
            foreach (var item in duraklar)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            do
            {
                Console.Write("Lütfen bindiğiniz durağı seçiniz: ");
            }
            while (!int.TryParse(Console.ReadLine(), out binilenDurak));

            double ucret = OdenenTutar();
            kazanclar.Add(DateTime.Now, ucret);

            //_data.Add(new data()
            //{
            //    Id = aktifKullaniciId,
            //    Kazanc = ucret
            //});
        }

        private static double OdenenTutar()
        {
            return 59.76;
        }

        private static void Cikis()
        {
            Environment.Exit(0);
        }
    }
}


/*
 * 
 * InisIslemi()
 * 1- kişiyi seç
 * 2- durak seç
 * 3- iade almak ister misiniz?
 * 4- JSON'a yaz
 * 5- kiiyi binenler listesinden çıkar
 * todo: bakiye güncelle
 */