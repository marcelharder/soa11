using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using api.Interfaces.signalR;
using Microsoft.EntityFrameworkCore;

namespace api.Implementations.signalR
{
    public class UserOnline : IUserOnline
    {
        private DataContext _context;
        public UserOnline(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Class_User_Online cuo) 
        {
            _context.onlineUsers.Add(cuo);
            if (await SaveAll()) { return 1; }
            return 0;
        }

        public async Task<int> DeleteAsync(Class_User_Online cuo) 
        {
             _context.onlineUsers.Remove(cuo);
            if (await SaveAll()) { return 1; }
            return 0;
        }

        public async Task<Class_User_Online> findUser(string name)
        {
            return await _context.onlineUsers.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<List<string>> getOnlineUsers()
        {
            var list_of_names = new List<string>();
            var all_online_users = await _context.onlineUsers.ToListAsync();
            
            foreach(Class_User_Online cuo in all_online_users){
                list_of_names.Add(cuo.Name);
            }
            return list_of_names;
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Class_User_Online cuo) 
        {
            _context.onlineUsers.Update(cuo);
            if (await SaveAll()) { return 1; }
            return 0;
        }
    }
}