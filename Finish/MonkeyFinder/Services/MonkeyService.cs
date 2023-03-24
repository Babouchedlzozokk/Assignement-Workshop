using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    HttpClient httpClient;
    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }

    List<Comment> commentList;
    public async Task<List<Comment>> GetComment()
    {
        if (commentList?.Count > 0)
            return commentList;

        // Online
        var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments");
        if (response.IsSuccessStatusCode)
        {
            commentList = await response.Content.ReadFromJsonAsync<List<Comment>>();
        }
        // Offline
        /*using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
        */
        return commentList;
    }
}
