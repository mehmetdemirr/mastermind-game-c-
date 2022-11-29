using System;
using System.Linq;

namespace MasterMind
{
    public class Program
    {
        static Random rastgele = new Random();
        static int boyut = 4;
        private static int deger;
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    string sec;
                    do
                    {
                        //Console.Clear();
                        Menu();
                        Console.Write("Seçim yapınız:");
                        sec = Console.ReadLine();
                        while (!(sec == "1" || sec == "2" || sec == "3" || sec == "4"))
                        {
                            Console.Write("Lütfen geçerli bir seçim yapınız:");
                            sec = Console.ReadLine();
                        }
                        switch (sec)
                        {
                            case "1":
                                {
                                    PcSifresiniKir();
                                    break;
                                }
                            case "2":
                                {
                                    BenimSifremiPcKir();
                                    break;
                                }
                            case "3":
                                {
                                    OyunSeviyesi();
                                    //boyut değişkeni genel olarak değiştimi onu gözlemledim.
                                    //Console.WriteLine("Boyut:{0}", boyut); 
                                    break;
                                }
                            case "4":
                                Console.WriteLine("Çıkış Yapıldı.");
                                break;
                            default:
                                {
                                    Console.WriteLine("Lütfen geçerli bir seçim yapınız!");
                                    break;
                                }
                        }
                    }
                    while (sec != "4");
                }
                else if (args.Length == 2)
                {
                    if (args[0] == "-bul")
                    {
                        if (args[1] == "3" || args[1] == "4" || args[1] == "5" || args[1] == "6")
                        {
                            boyut = int.Parse(args[1]);
                            BenimSifremiPcKir();
                        }
                        else
                        {
                            Console.WriteLine("Seviye Hatası!");
                        }
                    }
                    else if (args[0] == "-tut")
                    {
                        if (args[1] == "3" || args[1] == "4" || args[1] == "5" || args[1] == "6")
                        {
                            boyut = int.Parse(args[1]);
                            PcSifresiniKir();
                        }
                        else
                        {
                            Console.WriteLine("Seviye Hatası!");
                        }
                    }
                    else
                    {
                        Console.WriteLine(@"
                          __  __           _              __  __ _           _  
                         |  \/  |         | |            |  \/  (_)         | | 
                         | \  / | __ _ ___| |_ ___ _ __  | \  / |_ _ __   __| | 
                         | |\/| |/ _` / __| __/ _ \ '__| | |\/| | | '_ \ / _` | 
                         | |  | | (_| \__ \ ||  __/ |    | |  | | | | | | (_| | 
                         |_|  |_|\__,_|___/\__\___|_|    |_|  |_|_|_| |_|\__,_| 
                                                         
_______________________________________________________________________________________                                                                          
");
                        Console.WriteLine("-------------YARDIM-----------------");
                        Console.WriteLine("| *İki tane parametre alıyor*       |");
                        Console.WriteLine("|    mastermind.exe –bul seviye     |");
                        Console.WriteLine("|    mastermind.exe –tut seviye     |");
                        Console.WriteLine("-------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine(@"
                          __  __           _              __  __ _           _  
                         |  \/  |         | |            |  \/  (_)         | | 
                         | \  / | __ _ ___| |_ ___ _ __  | \  / |_ _ __   __| | 
                         | |\/| |/ _` / __| __/ _ \ '__| | |\/| | | '_ \ / _` | 
                         | |  | | (_| \__ \ ||  __/ |    | |  | | | | | | (_| | 
                         |_|  |_|\__,_|___/\__\___|_|    |_|  |_|_|_| |_|\__,_| 
                                                         
_______________________________________________________________________________________                                                                          
");
                    Console.WriteLine("-------------YARDIM-----------------");
                    Console.WriteLine("| *İki tane parametre alıyor*       |");
                    Console.WriteLine("|    mastermind.exe –bul seviye     |");
                    Console.WriteLine("|    mastermind.exe –tut seviye     |");
                    Console.WriteLine("-------------------------------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata ile karşılaşıldı!.Oyun Bitti.");
                //Console.WriteLine(ex);
            }
        }

        static void Menu()
        {
            Console.WriteLine("*********************MENÜ**************************");
            Console.WriteLine("[1] Bilgisayarın oluşturduğu şifreyi kır");
            Console.WriteLine("[2] Bilgisayarın benim oluşturduğum şifreyi kırsın");
            Console.WriteLine("[3] Oyun seviyesini değiştir (Oyun Seviyesi:{0})", boyut);
            Console.WriteLine("[4] Çıkış");
        }

        //iki sayıyı karşılaştırıp ipucu değeri üretiyor
        static String SayilariKarsilastir(string sifre, string tahminSifre)
        {
            int boyut = sifre.Length;
            int ayniBasamak = 0;
            int farkliBasamak = 0;

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (i == j)
                    {
                        if (sifre[i] == tahminSifre[j])
                        {
                            ayniBasamak++;
                        }
                    }
                    else
                    {
                        if (sifre[i] == tahminSifre[j])
                        {
                            farkliBasamak--;
                        }
                    }
                }
            }
            if (ayniBasamak == 0 && farkliBasamak == 0)
            {
                return "0";
            }
            else if (ayniBasamak > 0 && farkliBasamak == 0)
            {
                return "+" + ayniBasamak.ToString();
            }
            else if (ayniBasamak == 0 && farkliBasamak < 0)
            {
                return farkliBasamak.ToString();
            }
            else if (ayniBasamak > 0 && farkliBasamak < 0)
            {
                return "+" + ayniBasamak.ToString() + " " + farkliBasamak.ToString();
            }
            else
            {
                return "sonuc dönmedi";
            }
        }
        //rakamları farklı sayı üretiyor
        static int[] SayiTuretme(int boyut)
        {
            int[] randomNumara = new int[boyut];
            int i = 0;
            while (i < boyut)
            {
                int sayi = rastgele.Next(10);
                if (randomNumara.Contains(sayi))
                    continue;
                randomNumara[i] = sayi;
                i++;
            }
            return randomNumara;
        }
        static void PcSifresiniKir() //[1] Bilgisayarın oluşturduğu şifreyi kır
        {
            List<string> Tahmin = new List<string>();
            List<string> Ipucu = new List<string>();
            string sifre = diziyiStringeDonustur(SayiTuretme(boyut));
            string tahmin = "";
            //bilgisayarın oluşturduğu şifreyi yazdıyorum
            //Console.WriteLine(sifre);
            while (sifre != tahmin)
            {
                Console.Write("Bilgisayarın şifresini tahmin et:");
                tahmin = Console.ReadLine();
                while (!SayiMi(tahmin) || tahmin.Length != boyut || !rakamlariFarkli(tahmin))
                {
                    Console.Write("Bilgisayarın şifresini tahmin et:", boyut);
                    tahmin = Console.ReadLine();
                }
                Console.WriteLine(SayilariKarsilastir(tahmin, sifre));
                Tahmin.Add(tahmin);
                Ipucu.Add(SayilariKarsilastir(tahmin, sifre));
            }
            if (tahmin == sifre)
            {
                Console.WriteLine("***Tebrikler şifreyi kırdınız :9***");
            }
            for (int i = 0; i < Tahmin.Count; i++)
            {
                Console.WriteLine("Tahmin #{0}  > {1}  >>> Sonuç: {2}", i + 1, Tahmin[i], Ipucu[i]);
            }
        }
        static void BenimSifremiPcKir() //[2] Bilgisayarın benim oluşturduğum şifreyi kırsın
        {
            /*Console.Write("{0} basamaklı şifre oluşturunuz:", boyut);
            string sifre = Console.ReadLine();
            while (!SayiMi(sifre) || sifre.Length != boyut || !rakamlariFarkli(sifre))
            {
                Console.Write("Lütfen {0} basamaklı formata uygun şifre oluşturunuz:", boyut);
                sifre = Console.ReadLine();
            }
            //oluşturduğum şifre değişkenini ekrana yazdırdım
            Console.WriteLine("\t\t\t\t\t***Oluşturduğum Şifre:{0}***", sifre);*/
            try
            {
                ipucunaGoreSifreyiBulma1();
                //ipucunaGoreSifreyiBulma2(sifre);
                //ipucunaGoreSifreyiBulma3(sifre);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hatalı ipucu değerleri girdiniz.Oyun bitti.");
            }
        }
        static void ipucunaGoreSifreyiBulma1()
        {
            //***Tahmin havuzundan sayı eleyerek şifreyi tahmin etme****
            string tahmin;
            List<string> liste = new List<string>();
            List<string> Tahmin = new List<string>();
            List<string> Ipucu = new List<string>();

            List<string> listeGecici = new List<string>();
            double sayac = Math.Pow(10.0, Convert.ToDouble(boyut));
            for (int i = 0; i < sayac; i++)
            {
                string muhtemelTahmin = i.ToString().PadLeft(boyut, '0');
                if (rakamlariFarkli(muhtemelTahmin))
                {
                    liste.Add(muhtemelTahmin);
                }
            }
            //listeYazdirma(liste);  //liste elamanları doğru oluştuğunu kontol etme
            tahmin = diziyiStringeDonustur(SayiTuretme(boyut));
            string ipucu = "";
            int artiDeger = 0;
            int eksiDeger = 0;
            while (liste.Count > 0)
            {
                Console.WriteLine("Pc Tahmini:{0}", tahmin);
                Console.Write("İpucunu giriniz(Örnek Format:'+2 -1'):");
                ipucu = Console.ReadLine();

                //bazı koşulları kontrol etme
                string[] dizim = ipucu.Split(' ');
                while (!(ipucu.Length == 2 || ipucu.Length == 5 || (ipucu.Length == 1 && ipucu[0] == '0')))
                {
                    Console.Write("İpucunu giriniz(Örnek Format:'+2 -1'):");
                    ipucu = Console.ReadLine();
                    dizim = ipucu.Split(' ');
                }

                /*
                 *  if(dizim.Length == 1)
                 {
                     if (!SayiMi(dizim[0]))
                     {
                         Console.Write("İpucunu giriniz(Örnek Format:'+2 -1'):");
                         ipucu = Console.ReadLine();
                     }
                 }
                 else if(dizim.Length == 2)
                 {
                     if (!(SayiMi(dizim[0]) || SayiMi(dizim[1])))
                     {
                         Console.Write("İpucunu giriniz(Örnek Format:'+2 -1'):");
                         ipucu = Console.ReadLine();
                     }
                 }
                 */

                Tahmin.Add(tahmin);
                Ipucu.Add(ipucu);
                if (ipucu == "+" + boyut.ToString())
                {
                    break;
                }
                int listeUzunlugu = liste.Count;
                if (listeUzunlugu <= 0)
                {
                    break;
                }
                int k = 0;
                while (k < liste.Count)
                {
                    if (ipucu != SayilariKarsilastir(tahmin, liste[k]))
                    {
                        liste.RemoveAt(k);
                    }
                    k++;
                }
                listeUzunlugu = liste.Count;
                int r = rastgele.Next(listeUzunlugu);
                tahmin = liste[r];
            }
            if (ipucu == "+" + boyut.ToString())
            {
                Console.WriteLine("Bilgisayar şifrenizi kırdı :9 ");
            }
            else
            {
                Console.WriteLine("Hatalı ipuçları verdiniz.Oyun bitti.");
            }

            for (int i = 0; i < Tahmin.Count; i++)
            {
                Console.WriteLine("Tahmin #{0}  > {1}  >>> Sonuç: {2}", i + 1, Tahmin[i], Ipucu[i]);
            }
        }
        static void listeYazdirma(List<string> liste)
        {
            int say = 0;
            foreach (var i in liste)
            {
                Console.WriteLine(i);
                say++;
            }
            Console.WriteLine("{0} tane sayı var", say);
        }

        //Benim tuttuğum şifreyi bilgisayırın tahmin etme algoritmaları
        /*
         * static void ipucunaGoreSifreyiBulma2(string sifre)
        {
               //***bilgisayar rasgele sayı üretip şifreyle eşleşme sağlama yöntemi****
            string deger;
            int sayac = 0;
            do
            {
                deger = diziyiStringeDonustur(SayiTuretme(boyut));
                 Console.WriteLine("Pc Tahmini:{0}",deger);
                 Console.Write("İpucunu giriniz(Örnek Format:'+2 -1'):");
                string ipucu = Console.ReadLine();
                if (ipucu != SayilariKarsilastir(deger, sifre))
                {
                 Console.WriteLine("Hatalı ipucu verdiniz.");
                    Console.WriteLine("Oyun bitti.");
                    break;   
                }
                sayac++;
                Console.WriteLine("{0}-Pc Tahmini:{1}   ipucu:{2}",sayac, deger, SayilariKarsilastir(deger, sifre));
            }
            while (sifre != deger);
            if (sifre == deger)
            {
                Console.WriteLine("Bilgisayar şifreyi kırdı :9 ");
            }   
        }
         */
        /*
         * static void ipucunaGoreSifreyiBulma3(string sifre)
        {
            Dictionary<string, string> ornekDegerler = new Dictionary<string, string>();
            for (int i = 0; i < boyut; i++)
            {
                string tahmin = diziyiStringeDonustur(SayiTuretme(boyut));
                Console.WriteLine("Bilgisayarın tahmini:{0}", tahmin);
                Console.Write("İpucunu giriniz(Örnek Format:'+2 -1'):");
                string ipucu = Console.ReadLine();
                if (ipucu == SayilariKarsilastir(tahmin, sifre))
                {
                    //sayıları ve ipuclarını bir arada tutma
                    ornekDegerler.Add(tahmin, ipucu);
                }
                else
                {
                    Console.WriteLine("Hatalı ipucu verdiniz.");
                    Console.WriteLine("Oyun bitti.");
                    break;
                }
            }
            if (ornekDegerler.Count == boyut)
            {
                            //***bu sayılar ve ipuçlarıyla şifreyi tahmin etme yöntemi***
                Console.WriteLine("İpucları ile şifreyi bulma:");
                foreach (var i in ornekDegerler)
                {
                    Console.WriteLine(i);
                }
            }
        }
         */
        static void OyunSeviyesi() //[3] Oyun seviyesini değiştir (Default-4)
        {
            Console.Write("Oyun seviyesini giriniz:");
            string seviye = Console.ReadLine();
            bool degisken = true;
            while (degisken)
            {
                if (SayiMi(seviye))
                {
                    if (int.Parse(seviye) > 2 && int.Parse(seviye) < 7)
                    {
                        degisken = false;
                        boyut = int.Parse(seviye);
                    }
                    else
                    {
                        Console.Write("Lütfen oyun seviyesini uygun formatta giriniz:");
                        seviye = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("Lütfen oyun seviyesini uygun formatta giriniz:");
                    seviye = Console.ReadLine();
                }
            }
        }
        //girilen string değerin sayı olup olmadığını dönüyor
        static bool SayiMi(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        //girilen stringin karakterleri farkı olup olmadığını dönüyor
        static bool rakamlariFarkli(string sayi)
        {
            for (int i = 0; i < sayi.Length; i++)
            {
                for (int j = i + 1; j < sayi.Length; j++)
                {
                    if (sayi[i] == sayi[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static string diziyiStringeDonustur(int[] dizi)
        {
            //dizi.ToString();
            string sonuc = "";
            for (int i = 0; i < dizi.Length; i++)
            {
                sonuc += dizi[i].ToString();
            }
            return sonuc;
        }
    }
}