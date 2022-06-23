using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWorld.Services.Contracts
{
    public interface ICategoriesService
    {
        Task<List<SelectListItem>> GetExistingCategoriesAsSelectListItemAsync();
    }
}
