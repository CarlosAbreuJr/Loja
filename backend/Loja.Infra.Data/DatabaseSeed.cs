using Loja.Domain.Entities;
using Loja.Domain.Enuns;
using Loja.Domain.Models.User;
using Loja.Uteis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Infra.Data
{
    public class DatabaseSeed
    {
        public static void Seed(LojaDbContext context, IPasswordHasher passwordHasher)
        {
            context.Database.EnsureCreated();

            if (!context.Set<Role>().Any())// == 0
            {

                var roles = new List<Role>
                {
                new Role { Name = ApplicationRole.Common.ToString() },
                new Role { Name = ApplicationRole.Administrator.ToString() }
                };

                context.Set<Role>().AddRange(roles);
                context.SaveChanges();
            }

            if (!context.Users.Any())//.Count() == 0
            {
                var users = new List<User>
                {
                    new User { 
                        Email = "admin@admin.com", 
                        Password = passwordHasher.HashPassword("12345678"),
                        Celular = "15987854545",
                        Username ="Admin",
                        CreateIn = DateTime.Now,
                        Documento = "111111110",
                        Name = "Administrador Teste",
                        EmailIsValid = true,
                        IsChangePassword = true,

                    },
                    new User { 
                        Email = "common@common.com", 
                        Password = passwordHasher.HashPassword("12345678"),
                        Celular = "15987854545",
                        Username ="Common",
                        CreateIn = DateTime.Now,
                        Documento = "111111111",
                        Name = "Common Teste",
                        EmailIsValid = true,
                        IsChangePassword = true
                    }
                };

                users[0].UserRoles.Add(new UserRole
                {
                    RoleId = context.Set<Role>().SingleOrDefault(r => r.Name == ApplicationRole.Administrator.ToString()).Id
                });

                users[1].UserRoles.Add(new UserRole
                {
                    RoleId = context.Set<Role>().SingleOrDefault(r => r.Name == ApplicationRole.Common.ToString()).Id
                });

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }

}
