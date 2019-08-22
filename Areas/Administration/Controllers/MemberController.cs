using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication5.Areas.Administration.Controllers
{
    public class MemberController : ApiController
    {
       static  List<MemberModel> Members;
        public MemberController()
        {
            Members = new List<MemberModel>() { new MemberModel { Id = 1, Name = "Pedro", User = new UserModel { Id = 1, Name = "B" } },
                new MemberModel { Id = 2, Name = "Pedro", User = new UserModel { Id = 1, Name = "B" } } };
         
        }
        // GET: api/Member
        public IEnumerable<MemberModel> Get()
        {
            return Members;
        }

        // GET: api/Member/5
        public MemberModel Get(int id)
        {
            return Members.SingleOrDefault(x => x.Id == id);
        }

        // POST: api/Member
        public void Post(MemberModel memberModel)
        {
            Members.Add(memberModel);
        }

        // PUT: api/Member/5
        public void Put(int id, MemberModel memberModel)
        {
            var member = Members.SingleOrDefault(x => x.Id == id);
            member.Name = memberModel.Name;
            //save to the database
            //users.Update(userModel);
        }

        // DELETE: api/Member/5
        public void Delete(int id)
        {
            var member = Members.SingleOrDefault(x => x.Id == id);
            Members.Remove(member);
        }
    }
}
