using HealingDivineSelf.Components.Pages;
using HealingDivineSelf.Models;
using static HealingDivineSelf.Services.WorkshopService.WorkshopsService;

namespace HealingDivineSelf.Services.WorkshopService
{
    public interface IWorkshopsService
    {
        Task<ApiResponse<UserWorkshop>> CreateUserWorkshop(UserWorkshop workshops);
    }
}
