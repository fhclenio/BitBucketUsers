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
            Console.WriteLine("URL: " + urlAtual);
            Console.WriteLine("Usuário sendo recuperado: " + line);

            HttpResponseMessage response = await client.GetAsync($"users/{ line }?access_token={ setup.AccessToken }");
            if (response.IsSuccessStatusCode)
            {
                User user = await response.Content.ReadAsAsync<User>();
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
                if (!File.Exists(logPath))
                    await File.WriteAllTextAsync(logPath, user.ToString());
                else
                {
                    using (StreamWriter file = new(logPath, append: true))
                    {
                        await file.WriteLineAsync("\n" + user.ToString());
                    }
                }
            }
            Console.WriteLine("Status code: " + response.StatusCode.ToString());
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

        Console.WriteLine("End of execution.");
    }
}