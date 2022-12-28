using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BoxBack.Application.Interfaces;
using BoxBack.Application.ViewModels.Navigation;

namespace BoxBack.Application.AppServices
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
            var navigationF = new VerticalNavItemViewModel();
            var navigationG = new VerticalNavItemViewModel();
            
            navigationA.Children = new List<Son>();
            navigationB.Children = new List<Son>();
            navigationF.Children = new List<Son>();
            navigationG.Children = new List<Son>();

            var oldestDashboardSonA = new Son();
            var oldestDashboardSonB = new Son();
            var oldestSonB = new Son();
            var oldestSonC = new Son();
            var oldestSonD = new Son();

            navigationA = new VerticalNavItemViewModel
            {
                Title = "Dashboards",
                Icon = "HomeAnalytics",
                BadgeContent = "novo",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            var comercial = new Son
            {
                Title = "Comercial",
                Path = "/dashboards/comercial",
                Action = "list",
                Subject = "ac-dashboardComercial-page"
            };
            navigationA.Children.Add(comercial);

            var publica = new Son
            {
                Title = "Pública",
                Path = "/dashboards/publica",
                Action = "list",
                Subject = "ac-dashboard-publica-page"
            };
            navigationA.Children.Add(publica);

            navigationG = new VerticalNavItemViewModel
            {
                Title = "Relatórios",
                Icon = "ChartBox",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            var comercialRelatorio = new Son
            {
                Title = "Comercial",
                Path = "/relatorios/comercial",
                Action = "list",
                Subject = "ac-relatorioComercial-page"
            };
            navigationG.Children.Add(comercialRelatorio);

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
                Subject = "ac-group-page"
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
                Title = "Vendedores",
                Path = "/negocios/comercial/vendedor/list",
                Action = "list",
                Subject = "ac-vendedor-page"
            };
            navigationC.Children.Add(oldestSonNB2);

            // var oldestSonNB2 = new Son
            // {
            //     Title = "Serviços",
            //     Path = "/negocios/comercial/servico/list",
            //     Action = "list",
            //     Subject = "ac-servico-page"
            // };
            // navigationC.Children.Add(oldestSonNB2);

            // var oldestSonNB5 = new Son
            // {
            //     Title = "Produtos",
            //     Path = "/negocios/comercial/produto/list",
            //     Action = "list",
            //     Subject = "ac-produto-page"
            // };
            // navigationC.Children.Add(oldestSonNB5);

            // var navigationD = new VerticalNavItemViewModel
            // {
            //     Title = "Processos",
            //     Icon = "LanguageRubyOnRails",
            //     BadgeContent = "",
            //     BadgeColor = "primary",
            //     Children = new List<Son>()
            // };

            // var oldestSonNB3 = new Son
            // {
            //     Title = "Pipelines",
            //     Path = "/negocios/processos/pipeline/list",
            //     Action = "list",
            //     Subject = "ac-pipeline-page"
            // };
            
            // navigationD.Children.Add(oldestSonNB3);

            // var navigationE = new VerticalNavItemViewModel
            // {
            //     Title = "Parceiros",
            //     Icon = "HandshakeOutline",
            //     BadgeContent = "",
            //     BadgeColor = "primary",
            //     Children = new List<Son>()
            // };
            // var oldestSonNB4 = new Son
            // {
            //     Title = "Fornecedores",
            //     Path = "/negocios/parceiros/fornecedor/list",
            //     Action = "list",
            //     Subject = "ac-fornecedor-page"
            // };
            // navigationE.Children.Add(oldestSonNB4);

            navigationF = new VerticalNavItemViewModel
            {
                Title = "Configurações",
                Icon = "CogOutline",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            var token = new Son
            {
                Title = "Chaves Apis",
                Path = "/sistema/configuracoes/chave-api/list",
                Action = "list",
                Subject = "ac-chaveApiTerceiro-page"
            };
            navigationF.Children.Add(token);

            var rotinas = new VerticalNavItemViewModel
            {
                Title = "Rotinas",
                Icon = "TimerCogOutline",
                BadgeContent = "",
                BadgeColor = "primary",
                Children = new List<Son>()
            };

            var rotinasTodas = new Son
            {
                Title = "Todas",
                Path = "/sistema/rotinas/list",
                Action = "list",
                Subject = "ac-rotina-page"
            };
            rotinas.Children.Add(rotinasTodas);

            await Task.Run(() => navigation.Add(navigationA));
            await Task.Run(() => navigation.Add(navigationG));
            
            navigationSectionA = new VerticalNavItemViewModel
            {
                SectionTitle = "SYSTEM",
                Action = "list",
                Subject = "section-title-system"
            };

            navigationSectionB = new VerticalNavItemViewModel
            {
                SectionTitle = "BUSSINESS",
                Action = "list",
                Subject = "section-title-bussiness"
            };

            await Task.Run(() => navigation.Add(navigationSectionA));
            await Task.Run(() => navigation.Add(navigationB));
            await Task.Run(() => navigation.Add(navigationF));
            await Task.Run(() => navigation.Add(rotinas));
            
            await Task.Run(() => navigation.Add(navigationSectionB));
            await Task.Run(() => navigation.Add(navigationC));

            // await Task.Run(() => navigation.Add(navigationD));
            // await Task.Run(() => navigation.Add(navigationE));
            #endregion
            
            return navigation.ToList();
        }
    }
}