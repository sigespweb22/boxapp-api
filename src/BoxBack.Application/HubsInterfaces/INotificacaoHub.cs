using System.Threading.Tasks;

namespace BoxBack.Application.HubsInterfaces
{
    public interface INotificacaoHub
    {
        Task ReceiveMessage(string message);
    }
}