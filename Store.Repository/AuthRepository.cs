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
        private readonly Application_ContextDB _contextDB;

        public AuthRepository(IMapper mapper, Application_ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
            this.mapper = mapper;
        }

        public async Task<List<MAuth>> GetAllUsers()
        {
            var query = await _contextDB.Auth.ToListAsync();

            return query != null ? query : null;
        }

        public async Task<MAuth> GetUserById(int id)
        {
            var query = await _contextDB.Auth
                .Where(user => user.IdAuth == id)
                .FirstOrDefaultAsync();

            return query != null ? query : null;
        }

        public async Task<MAuth> Login(MAuthDTO authDTO)
        {
            var query = await _contextDB.Auth
                .Where(user => user.UserName == authDTO.UserName.ToUpper())
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
            var query = await _contextDB.Auth
                .Where(user => user.Email == auth.Email)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var user = new MAuth
                {
                    User = auth.User.ToUpper(),
                    UserName = auth.UserName.ToUpper(),
                    Email = auth.Email,
                    Password = ApplicationCrypt.Encriptar(auth.Password),
                    Phone = auth.Phone,
                    Direction = auth.Direction.ToUpper(),
                    Role = auth.Role.ToUpper(),
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
                    query.User = auth.User.ToUpper();
                    query.UserName = auth.UserName.ToUpper();
                    query.Email = auth.Email;
                    query.Password = ApplicationCrypt.Encriptar(auth.Password);
                    query.Phone = auth.Phone;
                    query.Direction = auth.Direction.ToUpper();
                    query.Role = auth.Role.ToUpper();
                    query.Status = auth.Status;

                    await _contextDB.SaveChangesAsync();
                    return auth;
                }
            }
            return null;
        }

        public async Task<MAuth> DeleteUser(int id)
        {
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

        public async Task<List<MAuth>> SearchUserName(string name)
        {
            var query = await _contextDB.Auth
                .Where(user => user.User.Contains(name.ToUpper()))
                .ToListAsync();

            if (query != null)
            {
                return query;
            }
            else
            {
                return null;
            }
        }
    }
}
