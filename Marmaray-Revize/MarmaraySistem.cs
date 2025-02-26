using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmaray_Revize
{
    internal class MarmaraySistem
    {
        public List<Kisi> Kisiler { get; set; } = new List<Kisi>();
        public List<Durak> Duraklar { get; set; } = new List<Durak>();
        public List<Yolculuk> Yolculuklar { get; set; } = new List<Yolculuk>();

        public void KisiEkle(Kisi kisi)
        {
            Kisiler.Add(kisi);
        }
        public void DurakEkle(Durak durak)
        {
            Duraklar.Add(durak);
        }
        public void YolculukEkle(Yolculuk yolculuk)
        {
            yolculuk.Tarih = DateTime.Now;
            yolculuk.Ucret = UcretHesapla(yolculuk);
            Yolculuklar.Add(yolculuk);
            Console.WriteLine($"{yolculuk.Yolcu.AdSoyad} isimli yolcu {yolculuk.Binis.Name} durağından {yolculuk.Inis.Name} durağına {yolculuk.Ucret} TL karşılığında yolculuk yaptı.");
        }
        public void ZRaporuOlustur()
        {
            double toplamUcret = 0;
            int toplamYolcu = 0;
            int toplamIadeSayisi = 0;
            foreach (var yolculuk in Yolculuklar)
            {
                toplamUcret += yolculuk.Ucret;
                toplamYolcu++;
                if (yolculuk.IadeYapilacakMi)
                {
                    toplamIadeSayisi++;
                }
            }
            Console.WriteLine("----------------------Z RAPORU------------------------");
            Console.WriteLine($"Toplam Yolcu: {toplamYolcu}");
            Console.WriteLine($"Toplam Ücret: {toplamUcret}");
            Console.WriteLine($"Toplam İade Sayısı: {toplamIadeSayisi}");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("-----------------TÜM YOLCULUKLAR------------------------");
            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in Yolculuklar)
            {
                Console.WriteLine($"{item.Yolcu.AdSoyad} isimli yolcu {item.Binis.Name} durağından {item.Inis.Name} durağına {item.Ucret} TL karşılığında yolculuk yaptı.");
            }
        }

        private double UcretHesapla(Yolculuk yolculuk)
        {
            List<double> temelUcretler = new List<double> { 59.76, 27, 0 };
            double ucret;
            int gidilenDurakSayisi = Math.Abs(yolculuk.Binis.Id - yolculuk.Inis.Id);
            int iadeTarifesi = gidilenDurakSayisi / 7;

            if (yolculuk.Abonman == AbonmanTuru.Tam)
            {
                if (yolculuk.IadeYapilacakMi)
                {
                    List<double> iadeliUcretler = new List<double> { 27, 34.72, 40.08, 46.22, 53.99, 59.76 };
                    switch (iadeTarifesi)
                    {
                        case 0:
                            ucret = iadeliUcretler[0];
                            break;
                        case 1:
                            ucret = iadeliUcretler[1];
                            break;
                        case 2:
                            ucret = iadeliUcretler[2];
                            break;
                        case 3:
                            ucret = iadeliUcretler[3];
                            break;
                        case 4:
                            ucret = iadeliUcretler[4];
                            break;
                        case 5:
                            ucret = iadeliUcretler[5];
                            break;
                        default:
                            ucret = 0;
                            break;
                    }
                }
                else
                {
                    ucret = temelUcretler[0];
                }
            }
            else if (yolculuk.Abonman == AbonmanTuru.Ogrenci)
            {
                if (yolculuk.IadeYapilacakMi)
                {
                    List<double> iadeliUcretler = new List<double> { 13.18, 16.23, 19.33, 21.98, 25.84, 27 };
                    switch (iadeTarifesi)
                    {
                        case 0:
                            ucret = iadeliUcretler[0];
                            break;
                        case 1:
                            ucret = iadeliUcretler[1];
                            break;
                        case 2:
                            ucret = iadeliUcretler[2];
                            break;
                        case 3:
                            ucret = iadeliUcretler[3];
                            break;
                        case 4:
                            ucret = iadeliUcretler[4];
                            break;
                        case 5:
                            ucret = iadeliUcretler[5];
                            break;
                        default:
                            ucret = 0;
                            break;
                    }
                }
                else
                {
                    ucret = temelUcretler[1];
                }
            }
            else
            {
                ucret = temelUcretler[2];
            }

            return ucret;

        }


    }
}
