using Grinder.DAL.Entities;
using Grinder.DAL.Interfaces;
using Grinder.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.DB
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GrinderContext db;
        private Repository<Image> imageRepository;
        private Repository<User> userRepository;
        private Repository<Message> messageRepository;
        private Repository<Friends> friendsRepository;
        private Repository<ProfileView> viewRepository;
        private Repository<Thumbnail> thumbnailRepository;
        public UnitOfWork(GrinderContext context)
        {
            db = context;
        }
        public IRepository<Image> Images 
        {
            get
            {
                if (imageRepository == null)
                {
                    imageRepository = new Repository<Image>(db);
                }
                return imageRepository;
            }
        }
        public IRepository<User> Users 
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(db);
                }
                return userRepository;
            }
        }
        public IRepository<Friends> Friends
        {
            get
            {
                if (friendsRepository == null)
                {
                    friendsRepository = new Repository<Friends>(db);
                }
                return friendsRepository;
            }
        }
        public IRepository<Message> Messages
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new Repository<Message>(db);
                }
                return messageRepository;
            }
        }
        public IRepository<ProfileView> ProfileViews
        {
            get
            {
                if (viewRepository==null)
                {
                    viewRepository = new Repository<ProfileView>(db);
                }
                return viewRepository;
            }
        }

        public IRepository<Thumbnail> Thumbnails
        {
            get
            {
                if (thumbnailRepository == null)
                {
                    thumbnailRepository = new Repository<Thumbnail>(db);
                }
                return thumbnailRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false; 
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposed)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
