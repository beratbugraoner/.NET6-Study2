using Core.Data;
using Core.Entities;
using System;

namespace API.Business
{
    public class TestService : ITestService
    {
        private readonly AdaYazilimDbContext _adaYazilimDbContext;
        private static Random _random = new Random();
        public TestService(AdaYazilimDbContext adaYazilimDbContext)
        {
            _adaYazilimDbContext = adaYazilimDbContext;
        }

        public void TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {
            string[] cityNames = new string[10] { "Ankara", "Istanbul", "Izmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakir", "Van", "Rize" };
            List<int> idList = new List<int>();
            List<int> cartIdList = new List<int>();

            for (int i = 0; i < musteriAdet; i++)
            {
                Musteri musteri = new Musteri();
                musteri.Ad = RandomString(5);
                musteri.Soyad = RandomString(5);
                musteri.Sehir = cityNames[_random.Next(0,10)];
                _adaYazilimDbContext.Musteriler.Add(musteri);
                _adaYazilimDbContext.SaveChanges();
                idList.Add(musteri.Id);
            }

            for (int i = 0; i < sepetAdet; i++)
            {
                Sepet sepet = new Sepet();
                sepet.MusteriId = idList[_random.Next(0, idList.Count)];
                _adaYazilimDbContext.Sepetler.Add(sepet);
                _adaYazilimDbContext.SaveChanges();
                cartIdList.Add(sepet.Id);
                int randomCartCount = _random.Next(1, 6);
                for (int k = 0; k < randomCartCount; k++)
                {
                    SepetUrun sepetUrun = new SepetUrun();
                    sepetUrun.SepetId = sepet.Id;
                    sepetUrun.Tutar = _random.Next(100, 1001);
                    sepetUrun.Aciklama = RandomString(5);
                    _adaYazilimDbContext.SepetUrunler.Add(sepetUrun);
                    _adaYazilimDbContext.SaveChanges();
                }


            }

        }


        private static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}

