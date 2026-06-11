using HealingDivineSelf.Components.Pages;
using HealingDivineSelf.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace HealingDivineSelf.Services.WorkshopService
{
    public class WorkshopsService : IWorkshopsService
    {
        private readonly IConfiguration configuration;
        private static string _api = "https://dev-rel-api-a9eyasaghnedgxb0.southeastasia-01.azurewebsites.net/";
        public WorkshopsService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task CreateUserWorkshop(UserWorkshop workshops)
        {
            try
            {
                using var httpClient = new HttpClient();
                var uri = $"{_api}FreeWorkShops";
                var response = await httpClient.PostAsJsonAsync(uri,workshops);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return;
                }

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                // If you need to deserialize:
                // var dentistData = JsonSerializer.Deserialize<YourDto>(result, new JsonSerializerOptions
                // {
                //     PropertyNameCaseInsensitive = true
                // });
            }
            catch
            {
                throw;
            }
        }

    }
}
