namespace BitBucketUsers
{
    public class Setup
    {
        public string AccessToken { get; set; }
        public string Path { get; set; }
        public void Init()
        {
            AccessToken = @"DmuUtW5CYYUzuk6YSLGiVzvoVTUT1x_vFvaifAQUO0XXw12Jr2gifXIaWqggKGKDLhY1I-rohdNrIkYFigRqmGvR0GFxrJjYs7uukF_9qMY--3_lbUK1_4g7";
            Path = @"C:\dev\users.txt";
            //GetAuthorization();
            //GetPath();
        }
        private void GetAuthorization()
        {
            while (AccessToken == null)
            {
                Console.Write("Type Access Token: ");

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
                Console.Write("Type path: ");

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
