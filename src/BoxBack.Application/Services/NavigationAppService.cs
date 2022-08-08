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
            var navigationSection = new VerticalNavItemViewModel();
            var navigationB = new VerticalNavItemViewModel();

            navigationA.Children = new List<Son>();
            navigationB.Children = new List<Son>();
            var oldestSonA = new Son();
            var oldestSonB = new Son();

            navigationA = new VerticalNavItemViewModel
            {
                Title = "Dashboards",
                Icon = "HomeOutline",
                BadgeContent = "novo",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            oldestSonA = new Son
            {
                Title = "Client",
                Path = "/dashboards/client",
                Action = "read",
                Subject = "dashboard-client-page"
            };
            navigationA.Children.Add(oldestSonA);

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
                Title = "User",
                Path = "/system/user/list",
                Action = "read",
                Subject = "ac-user-page"
            };
            navigationB.Children.Add(oldestSonB);

            await Task.Run(() => navigation.Add(navigationA));
            navigationSection.SectionTitle = "SYSTEM";
            await Task.Run(() => navigation.Add(navigationSection));
            await Task.Run(() => navigation.Add(navigationB));
            #endregion
            
            return navigation.ToList();
        }
    }
}