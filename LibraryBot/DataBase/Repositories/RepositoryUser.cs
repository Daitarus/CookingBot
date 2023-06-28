﻿using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class RepositoryUser : Repository<User>
    {
        private LibraryBotDB libraryBotDB;
        public RepositoryUser(DB db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }

        public User? GetForTelegramId(long IdTelegram)
        {
            IQueryable<User> users = libraryBotDB.Users.Where(user => user.IdTelegram.Equals(IdTelegram));
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }

        public User UpdateOrAddUser(User newUser)
        {
            var oldUser = GetForTelegramId(newUser.IdTelegram);
            if (oldUser == null)
            {
                Add(newUser);
                SaveChange();
                return newUser;
            }
            else
            {
                if (!oldUser.EqualsForMainArgs(newUser))
                {
                    oldUser.UpdateMainArgs(newUser);
                    SaveChange();
                }
                return oldUser;
            }
        }
    }
}