using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.DTO;
using Store.Models;
using Store.Service;
using Store.Utils;

namespace Store.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper mapper;

        public AuthRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<MAuth>> GetAllUsers()
        {
            var _contextDB = new Application_ContextDB();
            var query = await _contextDB.Auth.ToListAsync();

            return query != null ? query : null;
        }

        public async Task<MAuth> GetUserById(int id)
        {
            var _contextDB = new Application_ContextDB();
            var query = await _contextDB.Auth
                .Where(user => user.IdAuth == id)
                .FirstOrDefaultAsync();

            return query != null ? query : null;
        }

        public async Task<MAuth> Login(MAuthDTO authDTO)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Auth
                .Where(user => user.UserName == authDTO.UserName)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (ApplicationCrypt.Desencriptar(authDTO.Password, query.Password) == true)
                {
                    return query;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public async Task<MAuth> Register(MAuth auth)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Auth
                .Where(user => user.Email == auth.Email)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var user = new MAuth
                {
                    User = auth.User,
                    UserName = auth.UserName,
                    Email = auth.Email,
                    Password = ApplicationCrypt.Encriptar(auth.Password),
                    Phone = auth.Phone,
                    Direction = auth.Direction,
                    Role = auth.Role,
                    Status = auth.Status
                };

                _contextDB.Auth.Add(user);
                await _contextDB.SaveChangesAsync();
                return auth;
            }
            else
            {
                return null;
            }
        }

        public async Task<MAuth> UpdateUser(MAuth auth)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Auth
                .Where(user => user.IdAuth == auth.IdAuth)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdAuth == 1)
                {
                    return new MAuth { IdAuth = query.IdAuth };
                }
                else
                {
                    query.User = auth.User;
                    query.UserName = auth.UserName;
                    query.Email = auth.Email;
                    query.Password = ApplicationCrypt.Encriptar(auth.Password);
                    query.Phone = auth.Phone;
                    query.Direction = auth.Direction;
                    query.Role = auth.Role;
                    query.Status = auth.Status;

                    await _contextDB.SaveChangesAsync();
                    return auth;
                }
            }
            return null;
        }

        public async Task<MAuth> DeleteUser(int id)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Auth
                .Where(user => user.IdAuth == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdAuth == 1)
                {
                    return new MAuth { IdAuth = query.IdAuth };
                }
                else
                {
                    if (query.Status == true)
                    {
                        query.Status = false;
                        await _contextDB.SaveChangesAsync();
                        return query;
                    }
                    else
                    {
                        query.Status = true;
                        await _contextDB.SaveChangesAsync();
                        return query;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
