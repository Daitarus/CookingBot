using CookingBotDB.Contexts;
using CookingBotDB.Entities;

namespace CookingBotDB.Repositories
{
    public class CookingBotRepository
    {
        private DbContextFactory _contextFactory;

        public CookingBotRepository(DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool TryCreateOrUpdateUser(User user)
        {
            using (var context = _contextFactory.Create())
            {
                var userFromDB = context.Users.FirstOrDefault(u => u.Id == user.Id);

                if (userFromDB == default)
                {
                    context.Users.Add(user);
                }
                else
                {
                    userFromDB = user;
                }

                var updatedQuantity = context.SaveChanges();

                return updatedQuantity > 0;
            }
        }

        public bool TryCreateOrUpdateArgumentMessage(ArgumentMessage argumentMessage)
        {
            using(var context = _contextFactory.Create())
            {
                var argumentMessageFromDB = context.ArgumentMessage.FirstOrDefault(a => a.Name == argumentMessage.Name && a.User == argumentMessage.User);

                if(argumentMessageFromDB == default)
                {
                    context.Add(argumentMessage);
                }
                else
                {
                    argumentMessageFromDB = argumentMessage;
                }

                var updatedQuantity = context.SaveChanges();

                return updatedQuantity > 0;
            }
        }

        public bool TryUpdateUserState(int userId, UserState userState)
        {
            using (var context = _contextFactory.Create())
            {
                var user = context.Users.First(u => u.Id == userId);
                user.State = userState;
                var updatedQuantity = context.SaveChanges();

                return updatedQuantity > 0;
            }
        }
    }
}
