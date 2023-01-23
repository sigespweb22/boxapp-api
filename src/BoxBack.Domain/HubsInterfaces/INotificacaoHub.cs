using System.Threading.Tasks;

namespace BoxBack.Domain.HubsInterfaces
{
    public interface INotificacaoHub
    {
        Task ReceiveMessage(string message);
    }
}