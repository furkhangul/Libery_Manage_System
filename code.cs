using System;
using System.Collections.Generic;

class Kitap
{
    public int ISBN { get; set; }
    public string KitapAdi { get; set; }
    public string Yazar { get; set; }
    public int YayinYili { get; set; }
    public bool Mevcut { get; set; }

    public Kitap(int isbn, string kitapAdi, string yazar, int yayinYili, bool mevcut)
    {
        ISBN = isbn;
        KitapAdi = kitapAdi;
        Yazar = yazar;
        YayinYili = yayinYili;
        Mevcut = mevcut;
    }
}

class Kullanici
{
    public int ID { get; set; }
    public string Isim { get; set; }
    public string Soyisim { get; set; }
    public string Bolum { get; set; }
    public int DogumYili { get; set; }
    public List<int> OduncKitaplar { get; set; }

    public Kullanici(int id, string isim, string soyisim, string bolum, int dogumYili)
    {
        ID = id;
        Isim = isim;
        Soyisim = soyisim;
        Bolum = bolum;
        DogumYili = dogumYili;
        OduncKitaplar = new List<int>();
    }

    public void OduncKitapEkle(int isbn)
    {
        OduncKitaplar.Add(isbn);
    }
}

class Program
{
    static List<Kitap> kitapListesi = new List<Kitap>();
    static List<Kullanici> kullaniciListesi = new List<Kullanici>();

    static void Main()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(" _  ___  _ _   _  _      _                   __   ___   _         _   _         ___ _    _             _ ");
        Console.WriteLine("| |/ (_)(_) |_(_)(_)_ __| |_  __ _ _ _  ___  \\ \\ / (_)_(_) _  ___| |_(_)_ __   / __(_)__| |_ ___ _ __ (_)");
        Console.WriteLine("| ' <| || |  _| || | '_ \\ ' \\/ _` | ' \\/ -_)  \\ V / / _ \\ ' \\/ -_)  _| | '  \\  \\__ \\ (_-<  _/ -_) '  \\| |");
        Console.WriteLine("|_|\\_\\\\_,_|\\__|\\_,_| .__/_||_\\__,_|_||_\\___|   |_|  \\___/_||_\\___|\\__|_|_|_|_| |___/_/__/\\__\\___|_|_|_|_|");
        Console.WriteLine("                   |_|                                                                                   ");
        Console.WriteLine("                                 Furkan Gül  | Nesne Yönelimli Programlama I                             ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n[*]Bu program 'Nesne Yönelimli Programlama I' dersinin ödevi olarak Furkan Gül tarafından kodlanmıştır.");
        Console.WriteLine("[*]Kütüphane uygulamasında kullanıcı ekleme/çıkarma, kitap ekleme/çıkarma, kullanım bilgileri gibi özellikler mevcuttur.");
        Console.WriteLine("[*]Lütfen sadece yönergeleri takip ediniz!");

        Menu();
    }

    static void Menu()
    {
        int secim;
        do
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("| [1] Kitap Ekle              |");
            Console.WriteLine("| [2] Kullanıcı Ekle          |");
            Console.WriteLine("| [3] Kitap Teslim Al         |");
            Console.WriteLine("| [4] Kitap Teslim Et         |");
            Console.WriteLine("| [5] Kullanıcı Listele       |");
            Console.WriteLine("| [6] Kitap Listele           |");
            Console.WriteLine("| [0] Ana Menüye Dön          |");
            Console.WriteLine("-------------------------------");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("Lütfen yapmak istediğiniz işlemin numarasını giriniz: ");
            secim = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            switch (secim)
            {
                case 0:
                    Main();
                    break;
                case 1:
                    KitapEkle();
                    break;
                case 2:
                    KullaniciEkle();
                    break;
                case 3:
                    KitapTeslimAl();
                    break;
                case 4:
                    KitapTeslimEt();
                    break;
                case 5:
                    KullaniciListele();
                    break;
                case 6:
                    KitapListele();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("$Hata: Geçersiz işlem numarası girdiniz!\nLütfen tekrar deneyiniz.");
                    break;
            }
        } while (secim != 0);
    }

    static void KitapEkle()
    {
        Console.Clear();
        Console.WriteLine("    __ __ _ __                 ________   __   ");
        Console.WriteLine("   / //_/(_) /_____ _____     / ____/ /__/ /__ ");
        Console.WriteLine("  / ,<  / / __/ __ `/ __ \\   / __/ / //_/ / _ \\");
        Console.WriteLine(" / /| |/ / /_/ /_/ / /_/ /  / /___/ ,< / /  __/");
        Console.WriteLine("/_/ |_/_/\\__/\\__,_/ .___/  /_____/_/|_/_/\\___/ ");
        Console.WriteLine("                 /_/                           ");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("[*]Kitap ekleme bölümüne hoş geldiniz. Eklemek istediğiniz kitabın bilgilerini giriniz.");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("\n\n");

        Console.Write("ISBN (yalnızca sayı giriniz): ");
        int isbn = Convert.ToInt32(Console.ReadLine());

        Console.Write("Kitap Adı: ");
        string kitapAdi = Console.ReadLine();

        Console.Write("Yazar: ");
        string yazar = Console.ReadLine();

        Console.Write("Yayın Yılı: ");
        int yayinYil = Convert.ToInt32(Console.ReadLine());

        Console.Write("Mevcut (true/false): ");
        bool mevcut = Convert.ToBoolean(Console.ReadLine());

        Kitap kitap = new Kitap(isbn, kitapAdi, yazar, yayinYil, mevcut);
        kitapListesi.Add(kitap);
        Console.Clear();
        Console.WriteLine("\n\n\n[*]Kitap ekleme işleminiz başarılı bir şekilde kaydedilmiştir!");
    }

    static void KullaniciEkle()
    {
        Console.Clear();
        Console.WriteLine("    __ __      ____                        ________   __   ");
        Console.WriteLine("   / //_/_  __/ / /___ _____  _  ____ _   / ____/ /__/ /__ ");
        Console.WriteLine("  / ,< / / / / / / __ `/ __ \\/ / ___/ /  / __/ / //_/ / _ \\");
        Console.WriteLine(" / /| / /_/ / / / /_/ / / / / / /__/ /  / /___/ ,< / /  __/");
        Console.WriteLine("/_/ |_\\__,_/_/_/\\__,_/_/ /_/_/\\___/_/  /_____/\\___/_/\\___/ ");
        Console.WriteLine("");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("[*]Kullanıcı ekleme bölümüne hoş geldiniz. Kullanıcı hakkındaki bilgileri eksiksiz girerek kullanıcı ekleyebilirsiniz.");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        Console.Write("ID (yalnızca sayı giriniz): ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("İsim: ");
        string isim = Console.ReadLine();

        Console.Write("Soyisim: ");
        string soyisim = Console.ReadLine();

        Console.Write("Doğum Yılı: ");
        int dogumYili = Convert.ToInt32(Console.ReadLine());

        Console.Write("Okuduğu Bölüm: ");
        string bolum = Console.ReadLine();

        Kullanici kullanici = new Kullanici(id, isim, soyisim, bolum, dogumYili);
        kullaniciListesi.Add(kullanici);

        Console.Clear();
        Console.WriteLine("\n\n\n[*]Kullanıcı ekleme işleminiz başarılı bir şekilde kaydedilmiştir!");
    }

    static void KitapTeslimAl()
    {
        Console.Clear();
        Console.WriteLine("    __ __ _ __                 ______          ___              ___    __");
        Console.WriteLine("   / //_/(_) /_____ _____     /_  __/__  _____/ (_)___ ___     /   |  / /");
        Console.WriteLine("  / ,<  / / __/ __ `/ __ \\     / / / _ \\/ ___/ / / __ `__ \\   / /| | / / ");
        Console.WriteLine(" / /| |/ / /_/ /_/ / /_/ /    / / /  __(__  ) / / / / / / /  / ___ |/ /  ");
        Console.WriteLine("/_/ |_/_/\\__/\\__,_/ .___/    /_/  \\___/____/_/_/_/ /_/ /_/  /_/  |_/_/   ");
        Console.WriteLine("                 /_/                                                     ");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("[*]Kitap teslim alma bölümüne hoş geldiniz. Kullanıcıdan ID ve ISBN bilgilerini alarak kitabı teslim alabilirsiniz.");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        Console.Write("Kullanıcı ID'sini giriniz: ");
        string idStr = Console.ReadLine();
        int id;
        if (!int.TryParse(idStr, out id))
        {
            Console.Clear();
            Console.WriteLine("$Hata: ID yalnızca sayısal bir değer olmalıdır!\nLütfen tekrar deneyiniz.");
            KitapTeslimAl();
            return;
        }

        Console.Write("Kitap ISBN'sini giriniz: ");
        string isbnStr = Console.ReadLine();
        int isbn;
        if (!int.TryParse(isbnStr, out isbn))
        {
            Console.Clear();
            Console.WriteLine("$Hata: ISBN yalnızca sayısal bir değer olmalıdır!\nLütfen tekrar deneyiniz.");
            KitapTeslimAl();
            return;
        }

        Kullanici kullanici = kullaniciListesi.Find(k => k.ID == id);
        Kitap kitap = kitapListesi.Find(k => k.ISBN == isbn);

        if (kullanici == null)
        {
            Console.WriteLine("\n\n$Hata: Belirtilen ID ile kayıtlı bir kullanıcı bulunamadı!");
        }
        else if (kitap == null)
        {
            Console.WriteLine("\n\n$Hata: Belirtilen ISBN ile kayıtlı bir kitap bulunamadı!");
        }
        else if (!kitap.Mevcut)
        {
            Console.WriteLine("\n\n$Hata: Belirtilen kitap zaten ödünç verilmiş!");
        }
        else
        {
            kitap.Mevcut = false;
            kullanici.OduncKitapEkle(isbn);
            Console.WriteLine("\n\n[*]Kitap başarıyla teslim alındı!");
        }
    }

    static void KitapTeslimEt()
    {
        Console.Clear();
        Console.WriteLine("    __ __ _ __                 ______          ___              ________               ");
        Console.WriteLine("   / //_/(_) /_____ _____     /_  __/__  _____/ (_)___ ___     / ____/ /_____ ___  ___ ");
        Console.WriteLine("  / ,<  / / __/ __ `/ __ \\     / / / _ \\/ ___/ / / __ `__ \\   / __/ / __/ __ `__ \\/ _ \\");
        Console.WriteLine(" / /| |/ / /_/ /_/ / /_/ /    / / /  __(__  ) / / / / / / /  / /___/ /_/ / / / / / /  __/");
        Console.WriteLine("/_/ |_/_/\\__/\\__,_/ .___/    /_/  \\___/____/_/_/_/ /_/ /_/  /_____/\\__/_/ /_/ /_/\\___/");
        Console.WriteLine("                 /_/                                                                   ");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("[*]Kitap teslim etme bölümüne hoş geldiniz. Kullanıcıdan ID ve ISBN bilgilerini alarak kitabı teslim edebilirsiniz.");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

        Console.Write("Kullanıcı ID'sini giriniz: ");
        string idStr = Console.ReadLine();
        int id;
        if (!int.TryParse(idStr, out id))
        {
            Console.Clear();
            Console.WriteLine("$Hata: ID yalnızca sayısal bir değer olmalıdır!\nLütfen tekrar deneyiniz.");
            KitapTeslimEt();
            return;
        }

        Console.Write("Kitap ISBN'sini giriniz: ");
        string isbnStr = Console.ReadLine();
        int isbn;
        if (!int.TryParse(isbnStr, out isbn))
        {
            Console.Clear();
            Console.WriteLine("$Hata: ISBN yalnızca sayısal bir değer olmalıdır!\nLütfen tekrar deneyiniz.");
            KitapTeslimEt();
            return;
        }

        Kullanici kullanici = kullaniciListesi.Find(k => k.ID == id);
        Kitap kitap = kitapListesi.Find(k => k.ISBN == isbn);

        if (kullanici == null)
        {
            Console.WriteLine("\n\n$Hata: Belirtilen ID ile kayıtlı bir kullanıcı bulunamadı!");
        }
        else if (kitap == null)
        {
            Console.WriteLine("\n\n$Hata: Belirtilen ISBN ile kayıtlı bir kitap bulunamadı!");
        }
        else if (kitap.Mevcut)
        {
            Console.WriteLine("\n\n$Hata: Belirtilen kitap zaten kütüphanede mevcut!");
        }
        else if (!kullanici.OduncKitaplar.Contains(isbn))
        {
            Console.WriteLine("\n\n$Hata: Belirtilen kullanıcı ödünç alınan bu kitabı bulundurmuyor!");
        }
        else
        {
            kitap.Mevcut = true;
            kullanici.OduncKitaplar.Remove(isbn);
            Console.WriteLine("\n\n[*]Kitap başarıyla teslim edildi!");
        }
    }
}
