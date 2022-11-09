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
            
            var navigationSectionC = new VerticalNavItemViewModel();

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
                Title = "Controle Acesso",
                Path = "/dashboards/controle-acesso",
                Action = "list",
                Subject = "ac-dashboard-controle_acesso-page"
            };
            navigationA.Children.Add(oldestDashboardSonA);

            oldestDashboardSonB = new Son
            {
                Title = "Clientes",
                Path = "/dashboards/cliente",
                Action = "list",
                Subject = "ac-dashboard-cliente-page"
            };
            navigationA.Children.Add(oldestDashboardSonB);

            navigationB = new VerticalNavItemViewModel
            {
                Title = "Controle Acesso",
                Icon = "TrackpadLock",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            oldestSonB = new Son
            {
                Title = "Usuários",
                Path = "/sistema/controle-acesso/usuario/list",
                Action = "list",
                Subject = "ac-user-page"
            };
            navigationB.Children.Add(oldestSonB);

            oldestSonC = new Son
            {
                Title = "Permissões",
                Path = "/sistema/controle-acesso/role/list",
                Action = "list",
                Subject = "ac-role-page"
            };
            navigationB.Children.Add(oldestSonC);

            oldestSonD = new Son
            {
                Title = "Grupos",
                Path = "/sistema/controle-acesso/grupo/list",
                Action = "list",
                Subject = "ac-grupo-page"
            };
            navigationB.Children.Add(oldestSonD);

            var navigationC = new VerticalNavItemViewModel
            {
                BadgeContent = "",
                Title = "Comercial",
                Icon = "Domain",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            var oldestSonNB1 = new Son
            {
                Title = "Clientes",
                Path = "/negocios/comercial/cliente/list",
                Action = "list",
                Subject = "ac-cliente-page"
            };
            navigationC.Children.Add(oldestSonNB1);

            var oldestSonNB2 = new Son
            {
                Title = "Serviços",
                Path = "/negocios/comercial/servico/list",
                Action = "list",
                Subject = "ac-servico-page"
            };
            navigationC.Children.Add(oldestSonNB2);

            var navigationD = new VerticalNavItemViewModel
            {
                Title = "Processos",
                Icon = "LanguageRubyOnRails",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            var oldestSonNB3 = new Son
            {
                Title = "Pipelines",
                Path = "/negocios/processos/pipeline/list",
                Action = "list",
                Subject = "ac-pipeline-page"
            };
            
            navigationD.Children.Add(oldestSonNB3);

            var navigationE = new VerticalNavItemViewModel
            {
                Title = "Parceiros",
                Icon = "HandshakeOutline",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };
            var oldestSonNB4 = new Son
            {
                Title = "Fornecedores",
                Path = "/negocios/parceiros/fornecedor/list",
                Action = "list",
                Subject = "ac-fornecedor-page"
            };
            navigationE.Children.Add(oldestSonNB4);


            await Task.Run(() => navigation.Add(navigationA));
            
            navigationSectionA.SectionTitle = "SYSTEM";
            await Task.Run(() => navigation.Add(navigationSectionA));
            await Task.Run(() => navigation.Add(navigationB));
            
            navigationSectionB.SectionTitle = "BUSSINESS";
            await Task.Run(() => navigation.Add(navigationSectionB));
            await Task.Run(() => navigation.Add(navigationC));

            await Task.Run(() => navigation.Add(navigationD));
            await Task.Run(() => navigation.Add(navigationE));
            #endregion
            
            return navigation.ToList();
        }
    }
}