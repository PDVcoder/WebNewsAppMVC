using System;
using System.Collections.Generic;
using System.Linq;
using NewsWebApp.BLL.DTO;

namespace NewsWebApp.BLL.Interfaces
{
    public interface IAutoresationService
    {
        void RegistrateUser(AuthorDTO authorDTO);
        AuthorDTO GetAuthor(int? id);
        AuthorDTO LogIn(string username, string passhash);
        IEnumerable<AuthorDTO> GetUsers();
        void Dispose();
    }
}
