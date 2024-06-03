using ExamenMvcConciertosAWSMauricio.Models;
using System.Net.Http.Headers;

namespace ExamenMvcConciertosAWSMauricio.Services
{
    public class ServiceConciertos
    {
        private MediaTypeWithQualityHeaderValue Header;
        private string UrlApi;

        public ServiceConciertos(KeysModel keysModel)
        {
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = keysModel.UrlApi;
        }


        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/Conciertos/Eventos";
            return await this.CallApiAsync<List<Evento>>(request);
        }

        public async Task<List<Evento>> FindEventosByCategoriaAsync(int idcategoria)
        {
            string request = "api/Conciertos/EventosByIdCategoria/" + idcategoria;
            return await this.CallApiAsync<List<Evento>>(request);
        }

        public async Task<List<CategoriaEvento>> GetCategoriaEventoAsync()
        {
            string request = "api/Conciertos/CategoriasEvento";
            return await this.CallApiAsync<List<CategoriaEvento>>(request);
        }
    }
}
