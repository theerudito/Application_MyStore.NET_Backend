using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.DTO;
using Store.Models;
using Store.Service;

namespace Store.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMapper mapper;
        private readonly Application_ContextDB _contextDB;

        public ClientRepository(IMapper mapper, Application_ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
            this.mapper = mapper;
        }

        public async Task<MClients> CreateClient(MClientsDTO client)
        {
            var query = await _contextDB.Client
                .Where(cli => cli.DNI == client.DNI)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newClient = new MClients
                {
                    DNI = client.DNI,
                    FirstName = client.FirstName.ToUpper(),
                    LastName = client.LastName.ToUpper(),
                    Direction = client.Direction.ToUpper(),
                    Phone = client.Phone,
                    Email = client.Email,
                    City = client.City.ToUpper(),
                    Status = client.Status,
                };

                var mapperClient = mapper.Map<MClients>(newClient);
                _contextDB.Add(mapperClient);
                await _contextDB.SaveChangesAsync();
                return newClient;
            }
            return null;
        }

        public async Task<MClients> DeleteClient(int id)
        {
            var query = await _contextDB.Client
                .Where(cli => cli.IdClient == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdClient == 1)
                {
                    return new MClients { IdClient = query.IdClient };
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
            return null;
        }

        public async Task<List<MClients>> GetAllClients()
        {
            var query = await _contextDB.Client.ToListAsync();

            return query;
        }

        public async Task<MClients> GetClientById(int id)
        {
            var query = await _contextDB.Client
                .Where(cli => cli.IdClient == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                return query;
            }
            return null;
        }

        public async Task<MClients> UpdateClient(MClientsDTO client)
        {
            var query = await _contextDB.Client
                .Where(cli => cli.IdClient == client.IdClient)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                if (query.IdClient == 1)
                {
                    return new MClients { IdClient = query.IdClient };
                }
                else
                {
                    query.DNI = client.DNI;
                    query.FirstName = client.FirstName.ToUpper();
                    query.LastName = client.LastName.ToUpper();
                    query.Direction = client.Direction.ToUpper();
                    query.Phone = client.Phone;
                    query.Email = client.Email;
                    query.City = client.City.ToUpper();
                    query.Status = client.Status;

                    await _contextDB.SaveChangesAsync();
                    return query;
                }
            }
            return null;
        }

        public async Task<List<MClients>> SeachClient(string input)
        {
            var listClients = await _contextDB.Client.ToListAsync();

            var query = await _contextDB.Client
                .Where(
                    cli =>
                        cli.FirstName.Contains(input.ToUpper())
                        || cli.LastName.Contains(input.ToUpper())
                        || cli.DNI.Contains(input.ToUpper())
                )
                .ToListAsync();

            if (query.Count > 0)
            {
                return query;
            }
            else
            {
                return await GetAllClients();
            }
        }
    }
}
