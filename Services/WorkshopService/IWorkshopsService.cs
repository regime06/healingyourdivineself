using HealingDivineSelf.Components.Pages;
using HealingDivineSelf.Models;

namespace HealingDivineSelf.Services.WorkshopService
{
    public interface IWorkshopsService
    {
        Task CreateUserWorkshop(UserWorkshop workshops);
    }
}
