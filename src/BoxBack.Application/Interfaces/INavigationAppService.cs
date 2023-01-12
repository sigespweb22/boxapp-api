using System.Collections.Generic;
using System.Threading.Tasks;
using BoxBack.Application.ViewModels.Navigation;

namespace BoxBack.Application.Interfaces
{
    public interface INavigationAppService
    {
        Task<IEnumerable<VerticalNavItemViewModel>> MyMenuAsync(string userId);
    }
}