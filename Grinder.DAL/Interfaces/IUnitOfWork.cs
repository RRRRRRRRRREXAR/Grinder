using Grinder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Image> Images { get; set; }
        IRepository<User> Users { get; set; }
        void Save();
    }
}
