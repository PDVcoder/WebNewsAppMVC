using System.Collections.Generic;
using NewsWebApp.BLL.DTO;
using NewsWebApp.BLL.Interfaces;
using NewsWebApp.DAL.Entities;
using NewsWebApp.DAL.Interfaces;
using NewsWebApp.BLL.Infrastructure;
using AutoMapper;

namespace NewsWebApp.BLL.Services
{
    public class AutoreisationService : IAutoresationService
    {
        private IUnitOfWork Database { get; set; }

        public AutoreisationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public AuthorDTO GetAuthor(int? id)
        {
            if (id == null) throw new ValidationException("Id is null", "");
            var author = Database.Author.Get(id.Value);
            if (author == null) throw new ValidationException("User not found", "");

            return new AuthorDTO
            {
                Id = author.Id,
                Username = author.Username,
                Firstname = author.Firstname,
                Lastname = author.Lastname,
                Email = author.Email,
                RegistrationDate = author.RegistrationDate,
                Password = author.Password
            };
        }

        public IEnumerable<AuthorDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Author, AuthorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Author>, List<AuthorDTO>>(Database.Author.GetAll());
        }

        public AuthorDTO LogIn(string username, string passhash)
        {
           // Author author = Database.Author.Get(authorDTO.Id);

            var mapper = new MapperConfiguration(config => config.CreateMap<Author, AuthorDTO>()).CreateMapper();
            var users = mapper.Map<IEnumerable<Author>, List<AuthorDTO>>(Database.Author.Find(ex => ex.Username.Equals(username)));
            
            //if (users.Count == 1) throw new ValidationException("User already exist", "");
            if (users.Count == 0) throw new ValidationException("User doesn't exist", "");
            if (users.Count > 1) throw new ValidationException("Colision in database", "");

            AuthorDTO authorDTO = users[0];

            if (authorDTO.Password.Equals(passhash))
            {
                return authorDTO;
            }
            else
            {
                throw new ValidationException("Password don't match", "");
            }
        }

        public void RegistrateUser(AuthorDTO authorDTO)
        {
            // Author author = Database.Author.Get(authorDTO.Id);

            var mapper = new MapperConfiguration(config => config.CreateMap<Author, AuthorDTO>()).CreateMapper();
            var users = mapper.Map<IEnumerable<Author>, List<AuthorDTO>>(Database.Author.Find(ex => ex.Username.Equals(authorDTO.Username)));

            if (users.Count != 0) throw new ValidationException("User already exist", "");

            Author author = new Author
            {
                Id = authorDTO.Id,
                Email = authorDTO.Email,
                Username = authorDTO.Username,
                Firstname = authorDTO.Firstname,
                Lastname = authorDTO.Lastname,
                Password = authorDTO.Password

            };

            Database.Author.Create(author);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
