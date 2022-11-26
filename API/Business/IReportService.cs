using Core.Dto;

namespace API.Business
{
    public interface IReportService
    {
        List<DtoSehirAnaliz> SehirBazlıAnalizYap();
    }
}
