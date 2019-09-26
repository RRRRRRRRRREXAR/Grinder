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
        private GrinderContext db;
        private Repository<Image> imageRepository;
        private Repository<User> userRepository;
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
