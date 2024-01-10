using projectDB.Entities;

namespace projectDB.Services
{
    public class UserService:IUserService
    {
        private readonly CaseStudyDbContext dbContext;

        //Service to DBContext 
        public UserService(CaseStudyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        //To add user
        public User addUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        //To remove user
        public void removeUser(User user) 
        { 
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }

        //To get all users
        public List<User> getAllUsers()
        {
            return dbContext.Users.ToList();
        }


        //To change password
        public User UpdateUser(User user)
        {
            dbContext.Users.Update(user);
            dbContext.SaveChanges();
            return user;
        }

        //get user
        public User GetUser(int id)
        { 
            return dbContext.Users.Find(id);
        }

        //login user

        public User ValidateUser(string username, string password)
        {
            try
            {
                //User user = dbContext.Users.Find(username,password);
                //User user = (User)from f in dbContext.Users where username==f.UserName && password==f.Password select f;
                return dbContext.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);
                
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
