using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;

namespace api.Data.reports.interfaces
{
    public interface ISuggestion
    {
        Task<List<Class_Item>> GetAllIndividualSuggestions();

        Task<Class_Suggestion> GetIndividualSuggestion(int id);

        Task<int> updateSuggestion(Class_Suggestion c);

        Task<int> AddIndividualSuggestion(Class_Suggestion c);

        Task<bool> SaveAll();
    }
}
