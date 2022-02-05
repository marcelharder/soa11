using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Implementations
{
    public class UserRepository : IUserRepository
    {
       private RoleManager<IdentityRole> _roleManager;
       private UserManager<AppUser> _userManager;

       private DataContext _context;

       public string Role {get; set;}
       

        public UserRepository(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, DataContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUser> GetUser(int id)
        {
            if (id != 0) {
            var result = await _userManager.Users.Include(x => x.Courses).Include(y => y.Epa).FirstOrDefaultAsync(u => u.Id == id);
            return result;
            }
            return null;
        }
        
        public async Task<PagedList<AppUser>> GetUsers(UserParams userParams)
        {
           
            var users = _userManager.Users.OrderByDescending(u => u.Id).AsQueryable();
            return await PagedList<AppUser>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }
        public void Update(AppUser p)
        {
           _context.Users.Update(p);
           
        }
        public void AddUser(AppUser p)
        {
            _context.Users.Add(p);
        }

        public async Task<PagedList<AppUser>> GetUsersByHospital(UserParams userParams)
        {   var centerId = Convert.ToInt32(userParams.center_id);
            var users = _userManager.Users.OrderByDescending(u => u.UserName).AsQueryable();
            users = users.Where(x => x.hospital_id == centerId);
            return await PagedList<AppUser>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
      
        }
         public async Task<PagedList<AppUser>> GetAiosByHospital(UserParams userParams)
        {   
            var centerId = Convert.ToInt32(userParams.center_id);
            var users = _userManager.Users.OrderByDescending(u => u.UserName).AsQueryable();
            users = users.Where(x => x.hospital_id == centerId);
            users = users.Where(x => x.active == true);
            users = users.Where(x => x.ltk == false);
            return await PagedList<AppUser>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
      
        }

        public async Task<bool> GetUserLtk(int id)
        {
            var user = await GetUser(id);
           return user.ltk;
        }

        public async Task<PagedList<AppUser>> GetSurgeonsByHospital(UserParams userParams)
        {
            var centerId = Convert.ToInt32(userParams.center_id);
            var users = _userManager.Users.OrderByDescending(u => u.UserName).AsQueryable();
            users = users.Where(x => x.hospital_id == centerId);
            users = users.Where(x => x.active == true);
            users = users.Where(x => x.ltk == true);
            return await PagedList<AppUser>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<AppUser>> GetChefsByHospital(UserParams userParams)
        {
            Role = "5";
            List<AppUser> t = new List<AppUser>();
            var centerId = Convert.ToInt32(userParams.center_id);
            IdentityRole role = await _roleManager.FindByIdAsync(Role);
            
            if (role != null) {
            var userlist = _userManager.Users.Where(x => x.hospital_id == centerId).Where(x => x.active == true);
            foreach (AppUser user in userlist){
                if(user != null && await _userManager.IsInRoleAsync(user, role.Name)){
                   t.Add(user);
                }
            }
            }
            return await PagedList<AppUser>.CreateAsync(t.AsQueryable(), userParams.PageNumber, userParams.PageSize);
        }

        public async Task<List<Class_Course>> GetCourses(int id)
        {
            var selectedUser = await _userManager.Users
            .Include(a => a.Courses)
            .FirstOrDefaultAsync(x => x.Id == id);
            return selectedUser.Courses.ToList();
        }

        public async Task<List<Class_Epa>> GetEpaas(int id)
        {
             var selectedUser = await _userManager.Users
            .Include(a => a.Epa)
            .FirstOrDefaultAsync(x => x.Id == id);
            return selectedUser.Epa.ToList();
        }
    }
}