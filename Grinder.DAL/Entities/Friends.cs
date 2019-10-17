namespace Grinder.DAL.Entities
{
    public class Friends : BaseEntity
    {
        public User Sender { get; set; }
        public User Recivier { get; set; }
        public string Status { get; set; }
    }
}
