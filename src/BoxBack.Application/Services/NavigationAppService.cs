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
            navigationA.Children = new List<Son>();
            var oldestSonA = new Son();
            var oldestSonB = new Son();
            var oldestSonC = new Son();
            var oldestSonD = new Son();
            var oldestSonE = new Son();
            var youngestChildA = new Son();

            navigationA = new VerticalNavItemViewModel
            {
                Title = "Dashboards",
                Icon = "HomeOutline",
                BadgeContent = "novo",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            // oldestSonA = new Son
            // {
            //     Title = "CRM",
            //     Path = "/dashboards/crm"
            // };
            // oldestSonB = new Son
            // {
            //     Title = "Analytics",
            //     Path = "/dashboards/analytics"
            // };
            // oldestSonC = new Son
            // {
            //     Title = "eCommerce",
            //     Path = "/dashboards/ecommerce"
            // };
    
            oldestSonD = new Son
            {
                Title = "Client",
                Path = "/dashboards/client",
                Action = "read",
                Subject = "dashboard-client-page"
            };

            oldestSonE = new Son
            {
                Title = "Access Control",
                Path = "/acl",
                Action = "read",
                Subject = "dashboard-acl-page",
            };

            // oldestSonD.Children = new List<Son>();
            // youngestChildA = new Son
            // {
            //     Title = "Documentation",
            //     Path = "/dashboards/client/documentation"
            // };
            // oldestSonD.Children.Add(youngestChildA);

            // navigationA.Children.Add(oldestSonA);
            // navigationA.Children.Add(oldestSonB);
            // navigationA.Children.Add(oldestSonC);
            navigationA.Children.Add(oldestSonD);
            navigationA.Children.Add(oldestSonE);

            await Task.Run(() => navigation.Add(navigationA));
            #endregion
            
            return navigation.ToList();
        }
    }
}