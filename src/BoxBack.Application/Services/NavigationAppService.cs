using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels.Navigation;

namespace BoxBack.Application.Services
{
    public class NavigationAppService : INavigationAppService
    {
        public NavigationAppService() {  }

        public async Task<IEnumerable<VerticalNavItemViewModel>> MyMenuAsync(string userId)
        {
            #region Required validations
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("Id usuário requerido.");
            #endregion

            #region Get and mapper object
            var navigation = new List<VerticalNavItemViewModel>();
            var navigationA = new VerticalNavItemViewModel();
            var navigationSectionA = new VerticalNavItemViewModel();
            var navigationSectionB = new VerticalNavItemViewModel();
            var navigationB = new VerticalNavItemViewModel();

            navigationA.Children = new List<Son>();
            navigationB.Children = new List<Son>();
            var oldestDashboardSonA = new Son();
            var oldestDashboardSonB = new Son();
            var oldestSonB = new Son();
            var oldestSonC = new Son();
            var oldestSonD = new Son();

            navigationA = new VerticalNavItemViewModel
            {
                Title = "Dashboards",
                Icon = "HomeOutline",
                BadgeContent = "novo",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            oldestDashboardSonA = new Son
            {
                Title = "Access Control",
                Path = "/dashboards/access-control",
                Action = "list",
                Subject = "ac-dashboard-access-control-page"
            };
            navigationA.Children.Add(oldestDashboardSonA);

            oldestDashboardSonB = new Son
            {
                Title = "Client",
                Path = "/dashboards/client",
                Action = "list",
                Subject = "ac-dashboard-client-page"
            };
            navigationA.Children.Add(oldestDashboardSonB);

            navigationB = new VerticalNavItemViewModel
            {
                Title = "Access Control",
                Icon = "TrackpadLock",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            oldestSonB = new Son
            {
                Title = "Users",
                Path = "/system/control-access/user/list",
                Action = "list",
                Subject = "ac-user-page"
            };
            navigationB.Children.Add(oldestSonB);

            oldestSonC = new Son
            {
                Title = "Permissions",
                Path = "/system/control-access/role/list",
                Action = "list",
                Subject = "ac-role-page"
            };
            navigationB.Children.Add(oldestSonC);

            oldestSonD = new Son
            {
                Title = "Groups",
                Path = "/system/control-access/group/list",
                Action = "list",
                Subject = "ac-group-page"
            };
            navigationB.Children.Add(oldestSonD);

            var navigationC = new VerticalNavItemViewModel
            {
                Title = "Commercial",
                Icon = "HandshakeOutline",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            var oldestSonNB1 = new Son
            {
                Title = "Client",
                Path = "/bussiness/commercial/client/list",
                Action = "list",
                Subject = "ac-client-page"
            };
            navigationC.Children.Add(oldestSonNB1);

            await Task.Run(() => navigation.Add(navigationA));
            navigationSectionA.SectionTitle = "SYSTEM";
            await Task.Run(() => navigation.Add(navigationSectionA));
            await Task.Run(() => navigation.Add(navigationB));
            navigationSectionB.SectionTitle = "BUSSINESS";
            await Task.Run(() => navigation.Add(navigationSectionB));
            await Task.Run(() => navigation.Add(navigationC));
            #endregion
            
            return navigation.ToList();
        }
    }
}