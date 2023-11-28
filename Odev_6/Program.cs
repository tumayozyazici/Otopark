using System;

namespace Odev_6
{
    internal class Program
    {

        static double saat, ekGun, ucret;
        static int arac;
        static int[] otomobil = { 5, 10, 20, 35, 20 };
        static int[] motosiklet = { 0, 3, 6, 12, 10 };
        static int[] minibus = { 8, 16, 32, 45, 25 };
        static int[] kamyon = { 15, 30, 60, 100, 55 };
        static void Main(string[] args)
        {
            AracTipiGirisi();
            SaatGirisi();
            AracYonlendirmesi();
            Console.WriteLine($"Ücretiniz {ucret} TL'dir");
            Console.ReadLine();
        }
        /// <summary>
        /// Araç tipi girişi yapar.
        /// </summary>
        static void AracTipiGirisi()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Otomobil için 1 e basın.");
            Console.WriteLine("Motosiklet için 2 e basın.");
            Console.WriteLine("Minibüs için 3 e basın.");
            Console.WriteLine("Kamyon ve Ticari Araç için 4 e basın.");

            try
            {
                arac = int.Parse(Console.ReadLine());
                if (arac < 1 || arac > 4)
                {
                    Console.WriteLine("Gösterilen rakamlardan birini girmediniz. Gösterilen değerlerden birini giriniz.");
                    Console.WriteLine("");
                    AracTipiGirisi();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Sayı değeri girmediniz. Gösterilen sayı değerlerinden birini giriniz.");
                Console.WriteLine("");
                AracTipiGirisi();
            }
        }
        /// <summary>
        /// Parkta bırakılan aracın park süresinin girişini yapar.
        /// </summary>
        static void SaatGirisi()
        {
            Console.WriteLine("Araç kaç saat park alanında kaldı: ");

            try
            {
                saat = double.Parse(Console.ReadLine());
                if (saat < 0)
                {
                    Console.WriteLine("Negatif bir sayı girdiniz. Lütfen geçerli bir zaman miktarı giriniz.");
                    SaatGirisi();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Sayıdan farklı karakter girdiniz. Lütfen geçerli bir zaman miktarı giriniz.");
                SaatGirisi();
            }
        }
        /// <summary>
        /// Girilen araç tipine göre göre hesap yönlendirmesi.
        /// </summary>
        static void AracYonlendirmesi()
        {
            switch (arac)
            {
                case 1:
                    Hesaplama(otomobil);
                    break;
                case 2:
                    Hesaplama(motosiklet);
                    break;
                case 3:
                    Hesaplama(minibus);
                    break;
                case 4:
                    Hesaplama(kamyon);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Saat aralığındaki ücretlendirmeleri yapar.
        /// </summary>
        /// <param name="dizi">Tipi seçilen aracın dizisi</param>
        /// <returns>Girilen saate göre hesaplanan ücret</returns>
        private static double Hesaplama(int[] dizi)
        {
            if (saat > 0 && saat <= 2)
            {
                ucret = dizi[0];
            }
            else if (saat > 2 && saat <= 6)
            {
                ucret = dizi[1];
            }
            else if (saat > 6 && saat <= 12)
            {
                ucret = dizi[2];
            }
            else if (saat > 12 && saat <= 24)
            {
                ucret = dizi[3];
            }
            else
            {
                ekGun = (int)(saat / 24);
                ucret = dizi[3] + ((ekGun - 1) * dizi[4]);
            }
            return ucret;
        }
    }
}
