using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Helpers;

namespace api.Interfaces
{

    public interface IUserRepository
    {
        Task<PagedList<AppUser>> GetUsers(UserParams userParams);
        Task<List<Class_Course>> GetCourses(int id);
        Task<List<Class_Epa>> GetEpaas(int id);
        Task<PagedList<AppUser>> GetUsersByHospital(UserParams userParams);
        Task<PagedList<AppUser>> GetAiosByHospital(UserParams userParams);
        Task<PagedList<AppUser>> GetSurgeonsByHospital(UserParams userParams);
        Task<PagedList<AppUser>> GetChefsByHospital(UserParams userParams);
        Task<AppUser> GetUser(int id);
        Task<bool> GetUserLtk(int id);

        void AddUser(AppUser p);
        Task<bool> SaveAll();
        void Update(AppUser p);
        void Delete<T>(T entity) where T : class;
    }
}