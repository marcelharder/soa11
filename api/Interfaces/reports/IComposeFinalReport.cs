using System.Threading.Tasks;


namespace api.interfaces.reports
{
    public interface IComposeFinalReport
    {
        Task composeAsync(int procedure_id);
        int deletePDF(int id);
    }
}