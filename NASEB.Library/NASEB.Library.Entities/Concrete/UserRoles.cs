namespace NASEB.Library.Entities.Concrete
{
    public class UserRoles
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
