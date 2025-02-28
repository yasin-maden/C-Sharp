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

private static void DosyayaYaz<T>(ref List<T> list, JsonName name)
{
    try
    {
        // JSON formatına çevirme
        string json = JsonConvert.SerializeObject(list, Formatting.Indented);

        // dosya adını belirle
        string filePath = name.ToString().ToLower() + ".json";

        // dosya yolu geçerli mi?
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("Geçersiz dosya yolu.");
        }

        // dosyaya yaz
        File.WriteAllText(filePath, json);
        Console.WriteLine("Dosya başarıyla yazıldı: " + filePath);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("Hata: " + ex.Message);
    }
    catch (JsonException ex)
    {
        Console.WriteLine("JSON dönüştürme hatası: " + ex.Message);
    }
    catch (IOException ex)
    {
        Console.WriteLine("Dosya yazma hatası: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Bilinmeyen bir hata oluştu: " + ex.Message);
    }
}
Açıklamalar:
ArgumentException: Dosya yolunun geçersiz olduğuna dair bir hata fırlatılır.
JsonException: JSON serileştirme işlemi sırasında bir hata oluşursa, bu hata yakalanır.
IOException: Dosya yazma işlemi sırasında (örneğin, dosya erişilemiyorsa) meydana gelen hatalar için bir kontrol eklenir.
Exception: Diğer beklenmeyen hatalar için genel bir hata yakalama bloğu.
--------------------------------
private static void DosyadanOku<T>(ref List<T> list, JsonName name)
{
    try
    {
        // dosya adını belirle
        string filePath = name.ToString().ToLower() + ".json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            
            try
            {
                var deserializedObject = JsonConvert.DeserializeObject<List<T>>(json);
                if (deserializedObject != null)
                {
                    list = deserializedObject;
                    Console.WriteLine("Dosya başarıyla okundu: " + filePath);
                }
                else
                {
                    Console.WriteLine($"{filePath} dosyası boş veya hatalı.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON çözümleme hatası: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine($"{filePath} dosyası bulunamadı.");
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine("Dosya okuma hatası: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Bilinmeyen bir hata oluştu: " + ex.Message);
    }
}

Açıklamalar:
File.Exists: Dosyanın var olup olmadığını kontrol eder.
IOException: Dosya okuma işlemi sırasında meydana gelen hatalar (örneğin, dosyanın erişilememesi) için bir kontrol eklenmiştir.
JsonException: JSON verisinin çözümleme sırasında (deserialization) oluşabilecek hatalar için kontrol eklenmiştir.
Genel Exception: Herhangi bir bilinmeyen hata durumu için genel bir hata yakalama bloğu eklenmiştir.
--------------------------------
private static void KisiEkle()
{
    try
    {
        // Kullanıcıdan İsim Soyisim ve ID al
        string name = GetInput.GetString("İsim Soyisim: ");
        if (string.IsNullOrWhiteSpace(name)) 
        {
            Console.WriteLine("Geçersiz isim soyisim.");
            return;
        }

        int id = GetInput.GetPositiveInt("Kişi Id: ");
        if (id <= 0) 
        {
            Console.WriteLine("Geçersiz ID. Lütfen pozitif bir ID girin.");
            return;
        }

        // Önceden Kaydedilmiş Kişileri Yükle
        List<Person> persons = new List<Person>();
        try
        {
            DosyadanOku(ref persons, JsonName.Persons);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Kişileri yüklerken bir hata oluştu: " + ex.Message);
            return;
        }

        // Aynı ID'ye sahip kişi kontrolü
        if (persons.Any(p => p.Id == id))
        {
            Console.WriteLine("Bu id ile kayıtlı bir kişi zaten var.");
            return;
        }

        // Yeni kişi oluştur
        Person newPerson = new Person() { Id = id, Name = name };
        persons.Add(newPerson);

        // Kişiyi dosyaya yaz
        try
        {
            DosyayaYaz(ref persons, JsonName.Persons);
            Console.WriteLine("Kişi başarıyla eklendi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Kişiyi dosyaya yazarken bir hata oluştu: " + ex.Message);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Bir hata oluştu: " + ex.Message);
    }
}

Açıklamalar:
Giriş doğrulama: name'in boş olup olmadığını kontrol ediyoruz. Aynı şekilde, id'nin pozitif olup olmadığını kontrol ediyoruz.
Dosya okuma ve yazma hatası: DosyadanOku ve DosyayaYaz işlemleri için try-catch blokları ekledik. Eğer dosya okuma veya yazma sırasında hata oluşursa, kullanıcıya hata mesajı gösterilir.
Kişi ID kontrolü: persons listesinde zaten mevcut olan bir ID'nin eklenmeye çalışılması durumunda bir uyarı mesajı görüntülenir.
--------------------------------