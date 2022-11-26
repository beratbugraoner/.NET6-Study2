using Core.Data;
using Core.Dto;

namespace API.Business
{
    public class ReportService : IReportService
    {
        private readonly AdaYazilimDbContext _adaYazilimDbContext;
        public ReportService(AdaYazilimDbContext adaYazilimDbContext)
        {
            _adaYazilimDbContext = adaYazilimDbContext;
        }
        public List<DtoSehirAnaliz> SehirBazlıAnalizYap()
        {
            var musteriler = _adaYazilimDbContext.Musteriler.ToList();
            var sepetler = _adaYazilimDbContext.Sepetler.ToList();
            var sepetUrunleri = _adaYazilimDbContext.SepetUrunler.ToList();
            List<DtoSehirAnaliz> sehirAnalizleri = new List<DtoSehirAnaliz>();
            musteriler.OrderBy(x => x.Sehir).ToList();
            for (int i = 0; i < musteriler.Count; i++)
            {
                var musteriTemp = musteriler[i];
                if (!sehirAnalizleri.Any(x=>x.SehirAdi == musteriTemp.Sehir))
                {
                    sehirAnalizleri.Add(new DtoSehirAnaliz(){
                        SehirAdi = musteriTemp.Sehir,
                        SepetAdet = 0,
                        ToplamTutar =0

                    }); 
                }
                DtoSehirAnaliz dtoSehirAnaliz = sehirAnalizleri.First(x => x.SehirAdi == musteriTemp.Sehir);
                var musteriSepetleri = sepetler.Where(x => x.MusteriId == musteriTemp.Id).ToList();
                dtoSehirAnaliz.SepetAdet += musteriSepetleri.Count;

                for (int k = 0; k < musteriSepetleri.Count; k++)
                {
                    var sepetItem = musteriSepetleri[k];
                    var sepetUrun = sepetUrunleri.Where(x=>x.SepetId == sepetItem.Id).ToList();
                    dtoSehirAnaliz.ToplamTutar += (int)sepetUrun.Sum(x => x.Tutar);
                }
            }

            return sehirAnalizleri.OrderByDescending(x=>x.SepetAdet).ToList();
        }
    }
}
