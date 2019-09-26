using Grinder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grinder.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Image> Images { get;  }
        IRepository<User> Users { get;  }
        IRepository<Friends> Friends { get; }
        IRepository<Message> Messages { get; }
        void Save();
    }
}
