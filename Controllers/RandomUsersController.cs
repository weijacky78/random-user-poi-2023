

using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using places_webapi.Models.RandomUsers;

namespace places_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RandomUsersController : ControllerBase
{

    private readonly ILogger<RandomUsersController> _logger;
    public RandomUsersController(ILogger<RandomUsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetRandomUsers()
    {
        var users = await GetUsers(10);
        return users;
    }

    [HttpGet("{count}")]
    public async Task<ActionResult<IEnumerable<User>>> GetRandomUsersCount(uint count)
    {
        var users = await GetUsers(count);
        return users;
    }

    public static async Task<List<User>> GetUsers(uint count)
    {
        var client = new HttpClient();
        RandomUsers? users = null;
        var httpResponse = await client.GetAsync("https://randomuser.me/api/?results=" + count);
        httpResponse.EnsureSuccessStatusCode();

        var contentString = await httpResponse.Content.ReadAsStringAsync();
        users = JsonSerializer.Deserialize<RandomUsers>(
            contentString,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (users?.Results != null)
        {
            foreach (var user in users.Results)
            {
                user.Name.FullName = user.Name.First + " " + user.Name.Last;
                user.FullName = user.Name.FullName;
            }
        }

        return users?.Results ?? new List<User>();
    }


}
