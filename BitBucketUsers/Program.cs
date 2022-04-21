using BitBucketUsers;
using BitBucketUsers.Model;
using System.Net.Http.Headers;

RunAsync().Wait();

static async Task RunAsync()
{
    Setup setup = new Setup();
    setup.Init();
    if (!File.Exists(setup.Path))
    {
        Console.WriteLine($"File at path '{setup.Path}' doesn't exists.");
        return;
    }
    List<string> lines = new List<string>();
    using (StreamReader reader = new StreamReader(setup.Path))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            lines.Add(line);
        }
    }
    using (var client = new HttpClient())
    {
        client.BaseAddress = new System.Uri("https://api.bitbucket.org/2.0/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        foreach (string line in lines)
        {
            string urlAtual = client.BaseAddress.ToString() + $"users/{ line }";
            Console.WriteLine("Url atual: " + urlAtual);
            Console.WriteLine("Usuario sendo recuperado: " + line);

            HttpResponseMessage response = await client.GetAsync($"users/{ line }?access_token={ setup.AccessToken }");
            if (response.IsSuccessStatusCode)
            {
                User user = await response.Content.ReadAsAsync<User>();
            }
            Console.WriteLine("Status code: " + response.StatusCode.ToString());
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

    }
}