using Store.DTO;
using Store.Models;

namespace Store.Service
{
    public interface IClientRepository
    {
        Task<List<MClients>> GetAllClients();

        Task<MClients> GetClientById(int id);

        Task<MClients> CreateClient(MClientsDTO client);

        Task<MClients> UpdateClient(MClientsDTO client);

        Task<MClients> DeleteClient(int id);
    }
}