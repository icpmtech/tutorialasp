using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication5.Areas.Administration.Models;

namespace WebApplication5.Areas.Administration
{
    public class UserController : ApiController
    {
      
        ModelUser modelUser = new ModelUser();
        public UserController()
        {
           
        }
        // GET: api/User
        public IEnumerable<UserModel> Get()
        {
            return modelUser.Users.Select(x=>new UserModel { Id=x.Id, Name=x.Name });
          
        }

        // GET: api/User/5
        public UserModel Get(int id)
        {
          var user=   modelUser.Users.Where(x => x.Id == id).FirstOrDefault();
           return new UserModel { Id = user.Id, Name = user.Name };
        }

        // POST: api/User
        public void Post(UserModel userModel)
        {
            try
            {
                modelUser.Users.Add(new UserEntity { Id = userModel.Id, Name = userModel.Name });
                modelUser.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Post error in save to database", ex);
            }
            
        }

        // PUT: api/User/5
        public void Put(int id, UserModel userModel)
        {
            try
            {
                var userEntity = modelUser.Users.Where(x => x.Id == id).FirstOrDefault();
                if (userEntity == null)
                {
                    return;
                }
                userEntity.Name = userModel.Name;
                modelUser.Users.Attach(userEntity);
                modelUser.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Put error in save to database", ex);
            }

        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            //var user = users.SingleOrDefault(x => x.Id == id);
            //users.Remove(user);
        }
    }
}
