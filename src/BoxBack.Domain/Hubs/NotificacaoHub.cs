using BoxBack.Domain.HubsInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace BoxBack.Domain.Hubs
{
     public class NotificacaoHub : Hub<INotificacaoHub> {}
}