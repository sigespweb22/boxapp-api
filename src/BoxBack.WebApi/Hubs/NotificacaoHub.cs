using BoxBack.WebApi.HubsInterfaces;
using Microsoft.AspNetCore.SignalR;

namespace BoxBack.WebApi.Hubs
{
     public class NotificacaoHub : Hub<INotificacaoHub> {}
}