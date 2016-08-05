using System.Text;

namespace DDD.Domain.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string NickName
        {
            get
            {
                StringBuilder sb = new StringBuilder(FirstName[0] + ".");
                sb.Append(LastName);
                return sb.ToString();
            }
        }

        public long ExternalId { get; set; }
    }
}
