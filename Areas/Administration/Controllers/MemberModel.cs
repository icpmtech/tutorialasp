namespace WebApplication5.Areas.Administration.Controllers
{
    public class MemberModel
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public UserModel User { get;  set; }
    }
}