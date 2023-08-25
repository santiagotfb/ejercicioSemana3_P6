using Microsoft.AspNetCore.Mvc;
using ejercicioSemana3.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ejercicioSemana3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MTMB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        List<ordersHistory> lista1 = new List<ordersHistory>();
        
        [HttpGet]
        [Route("lista")]

        public dynamic lista() {
            SqlConnection connection = new SqlConnection(connectionString);
            //abre la coencta
            connection.Open();
            // guarda en un string el codigo sql a ejecutar
            //string queryString = "Select * from Carrera";
            string queryString = "Select * from ORDERS_HISTORY";
            //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
            // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
            SqlCommand command = new SqlCommand(queryString, connection);
            //  command.ExecuteReader(queryString);
            //command.Parameters.AddWithValue("@Id", id);
            //ejecuta el codigo sql y guarda en reader
            SqlDataReader reader = command.ExecuteReader();
           
            List<ordersHistory> lista = new List<ordersHistory>();
            //repite las filas obtenidas
            while (reader.Read())
            {
                //String nameimagen = reader[3].ToString();

                // nameimagen = nameimagen.Replace("https://drive.google.com/file/d/", "/view?usp=sharing");
                //  nameimagen = "https://drive.google.com/uc?export=view&id=" + nameimagen;

                ordersHistory PregADOs = new ordersHistory();
                //guarda por elemento del modelo carrera
                PregADOs.id = int.Parse(reader[0].ToString());
                PregADOs.OrderDate = DateTime.Parse(reader[1].ToString());

                //
                //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                PregADOs.Action = reader[2].ToString();
                PregADOs.Status = reader[3].ToString();
                PregADOs.Symbol = reader[4].ToString();
                PregADOs.Quantity = int.Parse(reader[5].ToString());
                PregADOs.Price = decimal.Parse(reader[6].ToString());

                /*
                 *  ordersHistory PregADOs = new ordersHistory() { 
                //guarda por elemento del modelo carrera
                id = int.Parse(reader[0].ToString()),
                OrderDate = DateTime.Parse(reader[1].ToString()),

                //
                //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                Action = reader[2].ToString(),
                Status = reader[3].ToString(),
                Symbol = reader[4].ToString(),
                Quantity = int.Parse(reader[5].ToString()),
                Price = decimal.Parse(reader[6].ToString()),
                };
                 */


                lista.Add(PregADOs);
            }


            //cierrra la conexion
            connection.Close();
            //muestra la lista de resutltado
            return (lista);
            
        }

        [HttpGet]
        [Route("ejercicio1")]

        public dynamic Ejercicio1()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //abre la coencta
            connection.Open();
            // guarda en un string el codigo sql a ejecutar
            //string queryString = "Select * from Carrera";
            string queryString = "Select * from ORDERS_HISTORY  where Status='EXECUTED'\r\n";
            //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
            // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
            SqlCommand command = new SqlCommand(queryString, connection);
            //  command.ExecuteReader(queryString);
            //command.Parameters.AddWithValue("@Id", id);
            //ejecuta el codigo sql y guarda en reader
            SqlDataReader reader = command.ExecuteReader();

            List<Ejercicio2> lista = new List<Ejercicio2>();
            //repite las filas obtenidas
            while (reader.Read())
            {
                //String nameimagen = reader[3].ToString();

                // nameimagen = nameimagen.Replace("https://drive.google.com/file/d/", "/view?usp=sharing");
                //  nameimagen = "https://drive.google.com/uc?export=view&id=" + nameimagen;

                Ejercicio2 PregADOs = new Ejercicio2();
                //guarda por elemento del modelo carrera
                PregADOs.id = int.Parse(reader[0].ToString());
                PregADOs.OrderDate = DateTime.Parse(reader[1].ToString());

                //
                //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                PregADOs.Action = reader[2].ToString();
                PregADOs.Status = reader[3].ToString();
                PregADOs.Symbol = reader[4].ToString();
                PregADOs.Quantity = int.Parse(reader[5].ToString());
                PregADOs.Price = decimal.Parse(reader[6].ToString());

                /*
                 *  ordersHistory PregADOs = new ordersHistory() { 
                //guarda por elemento del modelo carrera
                id = int.Parse(reader[0].ToString()),
                OrderDate = DateTime.Parse(reader[1].ToString()),

                //
                //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                Action = reader[2].ToString(),
                Status = reader[3].ToString(),
                Symbol = reader[4].ToString(),
                Quantity = int.Parse(reader[5].ToString()),
                Price = decimal.Parse(reader[6].ToString()),
                };
                 */

                PregADOs.neto = PregADOs.Price*PregADOs.Quantity;
             //   string lisass = PregADOs + decimal.Parse(ahola.ToString());
                lista.Add(PregADOs);
            }


            //cierrra la conexion
            connection.Close();
            //muestra la lista de resutltado
            return (lista);

        }

        [HttpPost]
        [Route("año")]

        public dynamic año(int alo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //abre la coencta
            connection.Open();
            // guarda en un string el codigo sql a ejecutar
            //string queryString = "Select * from Carrera";
            string queryString = "Select * from ORDERS_HISTORY where ORDER_DATE like @alo;";
            //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
            // no me acurdo, creoq ue guarda en un comadno sql lo que debe ejecutar y en que conexion hacerlo
            SqlCommand command = new SqlCommand(queryString, connection);
            //  command.ExecuteReader(queryString);
            command.Parameters.AddWithValue("@alo", "%"+alo+"%");
            //ejecuta el codigo sql y guarda en reader

            SqlDataReader reader = command.ExecuteReader();

            List<ordersHistory> lista = new List<ordersHistory>();
            //repite las filas obtenidas
            while (reader.Read())
            {
                //String nameimagen = reader[3].ToString();

                // nameimagen = nameimagen.Replace("https://drive.google.com/file/d/", "/view?usp=sharing");
                //  nameimagen = "https://drive.google.com/uc?export=view&id=" + nameimagen;

                ordersHistory PregADOs = new ordersHistory();
                //guarda por elemento del modelo carrera
                PregADOs.id = int.Parse(reader[0].ToString());
                PregADOs.OrderDate = DateTime.Parse(reader[1].ToString());

                //
                //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                PregADOs.Action = reader[2].ToString();
                PregADOs.Status = reader[3].ToString();
                PregADOs.Symbol = reader[4].ToString();
                PregADOs.Quantity = int.Parse(reader[5].ToString());
                PregADOs.Price = decimal.Parse(reader[6].ToString());

                /*
                 *  ordersHistory PregADOs = new ordersHistory() { 
                //guarda por elemento del modelo carrera
                id = int.Parse(reader[0].ToString()),
                OrderDate = DateTime.Parse(reader[1].ToString()),

                //
                //ReleaseDate = DateTime.Parse(reader[2].ToString()),
                Action = reader[2].ToString(),
                Status = reader[3].ToString(),
                Symbol = reader[4].ToString(),
                Quantity = int.Parse(reader[5].ToString()),
                Price = decimal.Parse(reader[6].ToString()),
                };
                 */


                lista.Add(PregADOs);
            }


            //cierrra la conexion
            connection.Close();
            //muestra la lista de resutltado
            return (lista);

        }
    }
}