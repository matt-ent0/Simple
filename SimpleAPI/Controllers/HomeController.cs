using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var data = GetData();
        return new JsonResult(new {value = data});
    }

    private string GetData()
    {
        using (SqlConnection connection = new SqlConnection("server=sql; Database=Simple; User ID=sa; Password=YourStrong@Passw0rd"))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(
                "SELECT TOP 1 [Data] FROM SimpleData",
                connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                }
            }
        }
        return string.Empty;
    }
}
