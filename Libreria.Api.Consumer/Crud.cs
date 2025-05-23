using Libreria.Api.Consumer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Api.Consumer
{
    public static class Crud<T>
    {
        private static readonly HttpClient client = new HttpClient();

        public static string EndPoint { get; set; }

        public static async Task<List<T>> GetAll()
        {
            try
            {
                var response = await client.GetAsync(EndPoint);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                throw;
            }
        }

        public static async Task<T> GetById(int id)
        {
            try
            {
                var response = await client.GetAsync($"{EndPoint}/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el dato con ID {id}: {ex.Message}");
                throw;
            }
        }

        public static async Task<T> Create(T item)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(item);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Realizamos la solicitud POST
                var response = await client.PostAsync(EndPoint, content);

                // Validamos la respuesta
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"Error al crear el objeto. Código de estado: {response.StatusCode}");
                    Console.WriteLine($"Respuesta: {jsonResponse}");
                    throw new Exception("Error al crear el objeto.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el objeto: {ex.Message}");
                throw;
            }
        }

        public static async Task<bool> Update(int id, T item)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(item);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Realizamos la solicitud PUT
                var response = await client.PutAsync($"{EndPoint}/{id}", content);

                // Validamos la respuesta
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al actualizar el objeto con ID {id}. Código de estado: {response.StatusCode}");
                    Console.WriteLine($"Respuesta: {jsonResponse}");
                    throw new Exception("Error al actualizar el objeto.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el objeto con ID {id}: {ex.Message}");
                throw;
            }
        }

        public static async Task<bool> Delete(int id)
        {
            try
            {
                // Realizamos la solicitud DELETE
                var response = await client.DeleteAsync($"{EndPoint}/{id}");

                // Validamos la respuesta
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al eliminar el objeto con ID {id}. Código de estado: {response.StatusCode}");
                    Console.WriteLine($"Respuesta: {jsonResponse}");
                    throw new Exception("Error al eliminar el objeto.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el objeto con ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
