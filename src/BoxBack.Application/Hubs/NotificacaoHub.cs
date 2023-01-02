using BoxBack.Application.HubsInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace BoxBack.Application.Hubs
{
     public class NotificacaoHub : Hub<INotificacaoHub> {}
}