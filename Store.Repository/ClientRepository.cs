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

        public ClientRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<MClients> CreateClient(MClientsDTO client)
        {
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Client
                .Where(cli => cli.DNI == client.DNI)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newClient = mapper.Map<MClients>(client);
                _contextDB.Add(newClient);
                await _contextDB.SaveChangesAsync();
                return newClient;
            }
            return null;
        }

        public async Task<MClients> DeleteClient(int id)
        {
            var _contextDB = new Application_ContextDB();

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
            var _contextDB = new Application_ContextDB();

            var query = await _contextDB.Client.ToListAsync();

            return query;
        }

        public async Task<MClients> GetClientById(int id)
        {
            var _contextDB = new Application_ContextDB();
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
            var _contextDB = new Application_ContextDB();

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
                    query.FisrtName = client.FisrtName;
                    query.LastName = client.LastName;
                    query.Direction = client.Direction;
                    query.Phone = client.Phone;
                    query.Email = client.Email;
                    query.City = client.City;
                    query.Status = client.Status;

                    await _contextDB.SaveChangesAsync();
                    return query;
                }
            }
            return null;
        }
    }
}
