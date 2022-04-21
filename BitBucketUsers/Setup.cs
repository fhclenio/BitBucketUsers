namespace BitBucketUsers
{
    public class Setup
    {
        public string AccessToken { get; set; }
        public string Path { get; set; }
        public string LogPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
        public void Init()
        {
            //GetAuthorization();
            GetPath();
        }
        private void GetAuthorization()
        {
            while (string.IsNullOrEmpty(AccessToken))
            {
                Console.Write("Type Access Token: ");

                try
                {
                    AccessToken = Console.ReadLine();
                    if (string.IsNullOrEmpty(AccessToken))
                    {
                        throw new Exception("Access Token can't be empty.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void GetPath()
        {
            while (string.IsNullOrEmpty(Path))
            {
                Console.Write("Type path: ");

                try
                {
                    Path = Console.ReadLine();
                    if (string.IsNullOrEmpty(Path))
                    {
                        throw new Exception("Path can't be empty.");
                    }
                    if (!File.Exists(Path))
                    {
                        throw new Exception($"File at path '{Path}' doesn't exists.");
                    }
                }
                catch (Exception ex)
                {
                    Path = string.Empty;
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
