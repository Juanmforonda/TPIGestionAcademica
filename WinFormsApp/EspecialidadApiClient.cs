using GestionAcademica.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace WinFormsApp
{
    public class EspecialidadApiClient
    {
        private static HttpClient client = new HttpClient();
        private const string baseURL = "http://localhost:5113/"; 

        static EspecialidadApiClient()
        {
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<EspecialidadDto>> GetAllAsync()
        {
            IEnumerable<EspecialidadDto> especialidades = null;
            HttpResponseMessage response = await client.GetAsync("especialidad");
            if (response.IsSuccessStatusCode)
            {
                especialidades = await response.Content.ReadFromJsonAsync<IEnumerable<EspecialidadDto>>();
            }
            return especialidades;
        }

        public static async Task<EspecialidadDto> GetAsync(int id)
        {
            EspecialidadDto especialidad = null;
            HttpResponseMessage response = await client.GetAsync("especialidad/" + id);

            if (response.IsSuccessStatusCode)
            {
                especialidad = await response.Content.ReadFromJsonAsync<EspecialidadDto>();
            }
            return especialidad;
        }

        public static async Task AddAsync(EspecialidadDto especialidad)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("especialidad", especialidad);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(EspecialidadDto especialidad)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("especialidad", especialidad);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("especialidad/" + id);
            response.EnsureSuccessStatusCode();
        }
    }
}
