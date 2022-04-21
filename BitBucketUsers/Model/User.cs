namespace BitBucketUsers.Model
{
    public class User
    {
        public string display_name { get; set; }
        public string nickname { get; set; }
        public DateTime created_on { get; set; }
        public string type { get; set; }
        public string uuid { get; set; }
        public bool is_staff { get; set; }
        public string location { get; set; }
        public string account_status { get; set; }
        public string account_id { get; set; }
    }
}
