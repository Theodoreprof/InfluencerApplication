using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluencerApp.API.Helpers;
using InfluencerApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InfluencerApp.API.Data
{
    public class CollabRepository : ICollabRepository
    {
        private readonly DataContext _context;
        public CollabRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Like> GetLike(int userId, int recipientId)
        {
            return await _context.Likes.FirstOrDefaultAsync(u => u.LikerId == userId && u.LikeeId == recipientId);

        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.MainPhoto);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.Include(p => p.Photos).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);

            users = users.Where(u => u.InfluencerOrBrand == userParams.InfluencerOrBrand);

            if (userParams.Likers) {
                var userLikers = await GetUserLikes(userParams.UserId, userParams.Likers);
                users = users.Where(u => userLikers.Contains(u.Id));
            }

            if (userParams.Likees) {
                var userLikees = await GetUserLikes(userParams.UserId, userParams.Likers);
                users = users.Where(u => userLikees.Contains(u.Id));
            }

            return await PagedList<User>.CreateASync(users, userParams.PageNumber, userParams.PageSize);
        }

        private async Task<IEnumerable<int>> GetUserLikes(int id, bool likers) {

            var user = await _context.Users.Include(x => x.Likers).Include(x => x.Likees).FirstOrDefaultAsync(u => u.Id == id);

            if (likers) {
                return user.Likers.Where(u => u.LikeeId == id).Select(i => i.LikerId);
            }
            else
            {
                return user.Likees.Where(u => u.LikerId == id).Select(i => i.LikeeId);
            }
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages.Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .AsQueryable();

            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId);
                    break;
                    case "Outbox":
                    messages = messages.Where(u => u.Senderid == messageParams.UserId);
                    break;
                    default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.IsRead == false);
                    break;
            }

            messages = messages.OrderByDescending(d => d.MessageSent);
            return await PagedList<Message>.CreateASync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages.Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .Where(m => m.RecipientId == userId && m.Senderid == recipientId 
                    || m.RecipientId == recipientId && m.Senderid == userId)
                .OrderByDescending(m => m.MessageSent)
                .ToListAsync();

                return messages;
        }
    }
}