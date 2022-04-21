using BitBucketUsers.Model;
using System.Net.Http.Headers;

namespace BitBucketUsers
{
    public static class ApiRequest
    {
        public static async Task RunAsync(Setup setup)
        {
            try
            {
                if (!File.Exists(setup.LogPath))
                {
                    File.Create(setup.LogPath);
                }
                else
                {
                    TimeSpan diff = DateTime.Now.Subtract(File.GetLastAccessTime(setup.LogPath));

                    if (diff.TotalSeconds <= 60)
                        throw new Exception("Application cannot run again because it was ran the last time less than 60 seconds ago.");
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
                            using (StreamWriter file = new(setup.LogPath, append: true))
                            {
                                await file.WriteLineAsync("\n" + user.ToString());
                            }
                        }
                        else
                        {
                            File.SetLastAccessTime(setup.LogPath, DateTime.Now);
                        }
                        Console.WriteLine("Status code: " + response.StatusCode.ToString());
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nEnd of execution.");
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
