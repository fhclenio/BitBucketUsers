using System.Text;

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
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("display_name: " + display_name).Append("|");
            stringBuilder.Append("nickname: " + nickname).Append("|");
            stringBuilder.Append("type: " + type).Append("|");
            stringBuilder.Append("created_on: " + created_on.ToString()).Append("|");
            stringBuilder.Append("location: " + location).Append("|");
            stringBuilder.Append("account_status: " + account_status).Append("|");
            stringBuilder.Append("is_staff: " + is_staff.ToString()).Append("|");
            stringBuilder.Append("account_id: " + account_id).Append("|");
            stringBuilder.Append("uuid: " + uuid);
            return stringBuilder.ToString();
        }
    }
}
