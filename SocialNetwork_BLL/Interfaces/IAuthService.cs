using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork_BLL.DTO;

namespace SocialNetwork_BLL.Interfaces
{
    interface IAuthService
    {
        PersonDTO GetPerson(string? username, string? password);
        IEnumerable<PersonDTO> GetPersons();
    }
}
