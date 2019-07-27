using System.Collections.Generic;
using System.Threading.Tasks;
using InfluencerApp.API.Models;

namespace InfluencerApp.API.Data
{
    public interface ICollabRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
    }
}