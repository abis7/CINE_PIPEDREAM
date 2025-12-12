using System.Text;
using Distribuidos.Api.Models.Pipedream;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace Distribuidos.Api.Services.Pipedream
{
    public class PipedreamService : IPipedreamService
    {
        // Método asíncrono que envía una solicitud POST a un endpoint de Pipedream
        // con los datos del usuario que le pasamos en el modelo "WelcomeModel".
        public async Task<bool> SendWelcome(WelcomeModel body)
        {
            // Guardamos la URL del endpoint proporcionado por Pipedream.
            string EndPoint = "https://eo6n71cn7kevf0.m.pipedream.net";

            // Creamos una instancia de HttpClient para hacer la solicitud HTTP.
            var client = new HttpClient();


            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new
            {
                nombre = body.UserName,
                email = body.Email
            }));


            // Creamos un contenido HTTP con los bytes del JSON.
            using (var content = new ByteArrayContent(byteData))
            {
                // Indicamos que el tipo de contenido que enviamos es JSON.
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Enviamos la solicitud POST al endpoint.
                var response = await client.PostAsync(EndPoint, content);

                // Si el servidor responde con un código 200-299
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }




        public async Task<bool> SendCode(WelcomeModel body)
        {
            // Guardamos la URL del endpoint proporcionado por Pipedream.
            string EndPoint = "https://eow0de7931nd0rp.m.pipedream.net";

            // Creamos una instancia de HttpClient para hacer la solicitud HTTP.
            var client = new HttpClient();

            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new
            {
                nombre = body.UserName,
                email = body.Email
            }));

            // Creamos un contenido HTTP con los bytes del JSON.
            using (var content = new ByteArrayContent(byteData))
            {
                // Indicamos que el tipo de contenido que enviamos es JSON.
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Enviamos la solicitud POST al endpoint.
                var response = await client.PostAsync(EndPoint, content);

                // Si el servidor responde con un código 200-299
                return response.IsSuccessStatusCode;
            }
        }


        public async Task<bool> SendCheckout(CheckoutModel body)
        {
            string EndPoint = "https://eo9vb3if5pp7rms.m.pipedream.net";
            var client = new HttpClient();

            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new
            {
                value = body.Value,
                key = body.Key
            }));
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(EndPoint, content);
                return response.IsSuccessStatusCode;
            }
        }


    }
}
