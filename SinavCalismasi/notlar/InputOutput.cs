/*
 * 
 * 
 * 
 * 
 using System.IO;

// Dosyaya yazma
string dosyaYolu = "ornek.txt";
string icerik = "Merhaba, bu bir test dosyasıdır.";

File.WriteAllText(dosyaYolu, icerik); // Bu yöntem, dosyayı oluşturur ve yazıyı yazar.

--------------------------------

using System.IO;

// Dosyayı okuma
string dosyaYolu = "ornek.txt";
string icerik = File.ReadAllText(dosyaYolu);
Console.WriteLine(icerik);

--------------------------------

using System.IO;

string dosyaYolu = "ornek2.txt";
using (StreamWriter writer = new StreamWriter(dosyaYolu))
{
    writer.WriteLine("Merhaba, StreamWriter ile yazıyorum!");
}

--------------------------------

using System.IO;

string dosyaYolu = "ornek2.txt";
using (StreamReader reader = new StreamReader(dosyaYolu))
{
    string satir;
    while ((satir = reader.ReadLine()) != null)
    {
        Console.WriteLine(satir);
    }
}
--------------------------------

string dosyaYolu = "ornek.txt";
if (File.Exists(dosyaYolu))
{
    Console.WriteLine("Dosya mevcut.");
}
else
{
    Console.WriteLine("Dosya bulunamadı.");
}

string klasorYolu = "C:\\TestKlasor";
if (Directory.Exists(klasorYolu))
{
    Console.WriteLine("Klasör mevcut.");
}
else
{
    Console.WriteLine("Klasör bulunamadı.");
}
--------------------------------
string kaynakDosya = "ornek.txt";
string hedefDosya = "yeniOrnek.txt";

if (File.Exists(kaynakDosya))
{
    File.Copy(kaynakDosya, hedefDosya, true); // true, var olan dosyanın üzerine yazmayı sağlar.
    Console.WriteLine("Dosya kopyalandı.");
}
--------------------------------
string dosyaYolu = "ornek2.txt";
if (File.Exists(dosyaYolu))
{
    File.Delete(dosyaYolu);
    Console.WriteLine("Dosya silindi.");
}
--- -----------------------------
string klasorYolu = "C:\\YeniKlasor";
if (!Directory.Exists(klasorYolu))
{
    Directory.CreateDirectory(klasorYolu);
    Console.WriteLine("Klasör oluşturuldu.");
}
--------------------------------
string klasorYolu = "C:\\YeniKlasor";
if (Directory.Exists(klasorYolu))
{
    Directory.Delete(klasorYolu, true); // true, içindeki dosyalarla birlikte siler.
    Console.WriteLine("Klasör silindi.");
}
--------------------------------


try
{
    int sayi = 10;
    int sonuc = sayi / 0;  // Bu satırda bir hata (bölme sıfıra) oluşur
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Sıfıra bölme hatası: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Bir hata oluştu: " + ex.Message);
}
--------------------------------
try
{
    // Hata oluşturabilecek kod
}
catch (Exception ex)
{
    // Hata yakalandığında yapılacak işlemler
    Console.WriteLine("Hata mesajı: " + ex.Message);
}
finally
{
    // Hata olsa da olmasa da çalışacak kod
    Console.WriteLine("Finally bloğu her durumda çalışır.");
}
--------------------------------
throw new InvalidOperationException("Geçersiz işlem!");
--------------------------------
public void Hesapla(int sayi)
{
    if (sayi < 0)
    {
        throw new ArgumentException("Sayı negatif olamaz!");
    }
    Console.WriteLine("Hesaplama başarılı.");
}

try
{
    Hesapla(-5);  // Negatif bir sayı gönderildiği için hata fırlatılır
}
catch (ArgumentException ex)
{
    Console.WriteLine("Hata: " + ex.Message);
}
--------------------------------
try
{
    int[] sayilar = { 1, 2, 3 };
    int deger = sayilar[5];  // Bu satırda bir hata (IndexOutOfRangeException) oluşur
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Dizi dışı indeks hatası: " + ex.Message);
}
catch (NullReferenceException ex)
{
    Console.WriteLine("Null referans hatası: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Bir hata oluştu: " + ex.Message);
}
--------------------------------
public class YetersizBakiyeException : Exception
{
    public YetersizBakiyeException(string mesaj) : base(mesaj) { }
}

public class BankaHesabi
{
    public decimal Bakiye { get; set; }

    public void ParaCek(decimal miktar)
    {
        if (miktar > Bakiye)
        {
            throw new YetersizBakiyeException("Yetersiz bakiye!");
        }

        Bakiye -= miktar;
        Console.WriteLine("Para çekildi, yeni bakiye: " + Bakiye);
    }
}

try
{
    var hesap = new BankaHesabi { Bakiye = 100 };
    hesap.ParaCek(150);  // Yetersiz bakiye hatası
}
catch (YetersizBakiyeException ex)
{
    Console.WriteLine("Özel Hata: " + ex.Message);
}
--------------------------------
List<int> sayilar = new List<int>();

// Eleman ekleme
sayilar.Add(10);
sayilar.Add(20);
sayilar.Add(30);

// Bir koleksiyonu ekleme
List<int> yeniSayilar = new List<int>() { 40, 50 };
sayilar.AddRange(yeniSayilar);

// Belirli bir indeks ile ekleme
sayilar.Insert(2, 25);  // 2. indexten önce 25 ekle

foreach (int sayi in sayilar)
{
    Console.WriteLine(sayi);
}
--------------------------------
List<int> sayilar = new List<int>() { 10, 20, 30, 40, 50 };

// Eleman kaldırma
sayilar.Remove(30);  // 30'u kaldırır

// İndekse göre eleman kaldırma
sayilar.RemoveAt(1);  // 1. indisteki elemanı (20) kaldırır

// Aralıkla eleman kaldırma
sayilar.RemoveRange(0, 2);  // İlk 2 elemanı (10, 40) kaldırır

// Tüm elemanları kaldırma
sayilar.Clear();

foreach (int sayi in sayilar)
{
    Console.WriteLine(sayi);
}
--------------------------------
List<int> sayilar = new List<int>() { 10, 20, 30, 40, 50 };

// Listeyi kontrol etme
Console.WriteLine(sayilar.Contains(30));  // true

// İndeksi bulma
Console.WriteLine(sayilar.IndexOf(40));  // 3

// Belirli bir şartı sağlayan elemanı bulma
int bulunanSayi = sayilar.Find(x => x > 30);  // 40
Console.WriteLine(bulunanSayi);
--------------------------------
List<int> sayilar = new List<int>() { 30, 10, 50, 40, 20 };

// Listeyi sıralama
sayilar.Sort();

foreach (int sayi in sayilar)
{
    Console.WriteLine(sayi);  // 10, 20, 30, 40, 50
}

// Listeyi tersine çevirme
sayilar.Reverse();

foreach (int sayi in sayilar)
{
    Console.WriteLine(sayi);  // 50, 40, 30, 20, 10
}
--------------------------------
using System.Linq;
using System.Collections.Generic;

List<int> sayilar = new List<int>() { 10, 20, 30, 40, 50 };

// Filtreleme (10'dan büyük olanları al)
var sonuc = sayilar.Where(x => x > 10).ToList();

foreach (var sayi in sonuc)
{
    Console.WriteLine(sayi);  // 20, 30, 40, 50
}
--------------------------------
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Anahtar türü string, değer türü int olan bir dictionary oluşturma
        Dictionary<string, int> sozluk = new Dictionary<string, int>();

        // Sözlüğe anahtar-değer çiftleri ekleme
        sozluk.Add("Ali", 30);
        sozluk.Add("Ayşe", 25);
        sozluk.Add("Mehmet", 35);

        // Anahtar ile değere erişme
        Console.WriteLine("Ali'nin yaşı: " + sozluk["Ali"]);
    }
}
--------------------------------
Dictionary<string, int> sozluk = new Dictionary<string, int>();
sozluk.Add("Ali", 30);
sozluk.Add("Ayşe", 25);

// Anahtar var mı kontrol etme
if (sozluk.ContainsKey("Ali"))
{
    Console.WriteLine("Ali'nin yaşı: " + sozluk["Ali"]);
}
else
{
    Console.WriteLine("Anahtar bulunamadı.");
}
--------------------------------
int yas;
if (sozluk.TryGetValue("Ayşe", out yas))
{
    Console.WriteLine("Ayşe'nin yaşı: " + yas);
}
else
{
    Console.WriteLine("Anahtar bulunamadı.");
}
--------------------------------
Dictionary<string, int> sozluk = new Dictionary<string, int>();
sozluk.Add("Ali", 30);
sozluk["Ayşe"] = 25;  // Bu da bir ekleme işlemi
sozluk["Mehmet"] = 35; // Bu da bir ekleme işlemi
--------------------------------
Dictionary<string, int> sozluk = new Dictionary<string, int>
{
    { "Ali", 30 },
    { "Ayşe", 25 },
    { "Mehmet", 35 }
};

// Anahtar ile eleman kaldırma
sozluk.Remove("Ayşe");

// Tüm elemanları kaldırma
sozluk.Clear();
--------------------------------
Dictionary<string, int> sozluk = new Dictionary<string, int>
{
    { "Ali", 30 },
    { "Ayşe", 25 },
    { "Mehmet", 35 }
};

// Dictionary üzerinden döngü ile geçme
foreach (KeyValuePair<string, int> item in sozluk)
{
    Console.WriteLine("Anahtar: " + item.Key + ", Değer: " + item.Value);
}
--------------------------------
Dictionary<string, int> sozluk = new Dictionary<string, int>
{
    { "Ali", 30 },
    { "Ayşe", 25 },
    { "Mehmet", 35 }
};

// Eleman sayısı
Console.WriteLine("Eleman sayısı: " + sozluk.Count);

// Anahtarları yazdırma
Console.WriteLine("Anahtarlar:");
foreach (var anahtar in sozluk.Keys)
{
    Console.WriteLine(anahtar);
}

// Değerleri yazdırma
Console.WriteLine("Değerler:");
foreach (var deger in sozluk.Values)
{
    Console.WriteLine(deger);
}
--------------------------------
Dictionary<string, int> sozluk = new Dictionary<string, int>
{
    { "Ali", 30 },
    { "Ayşe", 25 }
};

// Anahtarın değerini güncelleme
sozluk["Ali"] = 32;  // Ali'nin yaşı güncellendi

// Anahtar varsa değeri günceller, yoksa ekler
sozluk["Mehmet"] = 40;
--------------------------------
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> kitaplar = new Dictionary<string, string>()
        {
            { "1984", "George Orwell" },
            { "Fahrenheit 451", "Ray Bradbury" },
            { "Brave New World", "Aldous Huxley" }
        };

        // Kitap adını anahtar olarak kullanarak yazarı arama
        string yazar = kitaplar["1984"];
        Console.WriteLine("1984 kitabının yazarı: " + yazar);

        // Tüm kitapları ve yazarları yazdırma
        foreach (var kitap in kitaplar)
        {
            Console.WriteLine("Kitap: " + kitap.Key + ", Yazar: " + kitap.Value);
        }
    }
}

--------------------------------