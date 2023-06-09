﻿using Bussiness.Abstract;
using Bussiness.DTOs;
using DataAccess.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Concrete
{
    public class UserService : IUserService
    {
        //Microsoft Identity kullanılırsa best practice olabilir.
        //generic repository kullanılmalı.
        private readonly DotNetCoreExampleDB _context;

        public UserService(DotNetCoreExampleDB context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(CreateUserDTO createUser)
        {
            //happy path yazıyorum. Bu sebeple validation eksik. 
            //try catch kullanılmamalı. Ayrıca bir middleware ile exception handling yapılmalı.

            try
            {
                await _context.Users.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Name = createUser.Name,
                    Surname = createUser.Surname,
                    Email = createUser.Email,
                    Password = createUser.Password, //parola hashlenmesi gerek. Fakat burada kullanmayacağım.
                    ProfilPhoto = createUser.ProfilPhoto,//upload base64 olarak saklanabilir. Fakat burada kullanmayacağım. 
                    PhoneNumber = createUser.PhoneNumber
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }

            //burada hoşgeldiniz maili atılabilir.
            return true;
        }

        public async Task<bool> LoginUserAsync(string email, string password)
        {
            User user = await _context.Users
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            if (user is null)
            {
                return false;
            }

            return true;
        }
    }
}
