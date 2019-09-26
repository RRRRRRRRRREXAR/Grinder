namespace Grinder.DAL.Entities
{
    public class Friends : BaseEntity
    {
        public User User1 { get; set; }
        public User User2 { get; set; }
        public bool IsBlocked { get; set; }
    }
}
