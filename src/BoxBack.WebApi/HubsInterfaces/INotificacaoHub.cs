using System.Threading.Tasks;

namespace BoxBack.WebApi.HubsInterfaces
{
    public interface INotificacaoHub
    {
        Task ReceiveMessage(string message);
    }
}