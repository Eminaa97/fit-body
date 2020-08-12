using FitBody.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Services
{
    public interface INotificationService
    {
        IList<int> GetFollowers(int userId);
    }

    public class NotificationService : INotificationService
    {
        private readonly FitBodyContext _context;

        public NotificationService(FitBodyContext context)
        {
            _context = context;
        }

        public IList<int> GetFollowers(int userId)
        {
            return _context.UsersFollows.Where(x => x.UserFollowedId == userId).Select(x => x.UserFollowingId).ToList();
        }
    }
}
