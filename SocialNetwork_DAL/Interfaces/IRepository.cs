using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork_DAL.Interfaces
{
    interface IRepository<T> where T: class
    {
        ICollection<T> GetAll();
        T Get(T item);
        void Create(T item);
        void Update(T item);
        void Delete(string item);
    }
}
