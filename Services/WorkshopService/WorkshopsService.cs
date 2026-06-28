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
        public async Task<ApiResponse<UserWorkshop>> CreateUserWorkshop(UserWorkshop workshops)
        {
            using var httpClient = new HttpClient();

            _api = "https://localhost:7201/";
            var uri = $"{_api}FreeWorkShops";

            var response = await httpClient.PostAsJsonAsync(uri,workshops);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse<UserWorkshop>
                {
                    Success = false,
                    Message = "Something went wrong while sending your request.",
                    Errors = new List<string> { result }
                };
            }

            var data = JsonSerializer.Deserialize<ApiResponse<UserWorkshop>>(result,new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return data ?? new ApiResponse<UserWorkshop>
            {
                Success = false,
                Message = "No response received from server."
            };
        }

        public class ApiResponse<T>
        {
            public string Message { get; set; } = string.Empty;
            public T? Data { get; set; }
            public List<string> Errors { get; set; } = new();
            public bool Success { get; set; }
        }
    }


}
