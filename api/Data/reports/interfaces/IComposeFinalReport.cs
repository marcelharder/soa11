using System.Threading.Tasks;


namespace api.Data.reports.interfaces
{
    public interface IComposeFinalReport
    {
        Task composeAsync(int procedure_id);
        int deletePDF(int id);
    }
}