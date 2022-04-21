namespace BitBucketUsers
{
    public class Setup
    {
        public string AccessToken { get; set; }
        public string Path { get; set; }
        public void Init()
        {
            AccessToken = @"L5MyV63zJWj-9ZktcLbpJKueUhN6AM3q2lGPocYbfCV06kfDN0-U_qTzOxgdqQ6RJ2aVjqE52rMshArNU4OPX1Ef6hHONxhu8e8jKcYav0SsbhgxJl_SE-_k";
            Path = @"C:\dev\users.txt";
            //GetAuthorization();
            //GetPath();
        }
        private void GetAuthorization()
        {
            while (AccessToken == null)
            {
                Console.WriteLine("Type Access Token: ");

                try
                {
                    AccessToken = Console.ReadLine();
                    if (AccessToken == null)
                    {
                        throw new Exception("Access Token can't be null.");
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
            while (Path == null)
            {
                Console.WriteLine("Type Path: ");

                try
                {
                    Path = Console.ReadLine();
                    if (Path == null)
                    {
                        throw new Exception("Path can't be null.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
