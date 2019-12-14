using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork_DAL.Repositiories;

namespace SocialNetwork_DAL.Interfaces
{
    interface IUnitOfWork
    {
        PersonRepository Persons { get; }

        void Save();

    }
}
