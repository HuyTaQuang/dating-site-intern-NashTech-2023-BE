using DatingApp.DAL.Contacts;
using DatingApp.DAL.Data;
using DatingApp.DAL.Models;


namespace DatingApp.DAL.Repositories
{
    public class HobbyRepository : BaseRepository<Hobby>, IHobbyRepository
    {

        #region
        private AppDbContext _context;
        #endregion

        public HobbyRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
       
        }
        public IEnumerable<Hobby> GetAllHobbies()
        {
            try
            {
                var dataList = _context.Hobbies.ToList();
                if (dataList != null)
                {
                    return dataList;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Hobby GetHobbyById(int hobbyId)
        {
            try
            {
                var hobby = _context.Hobbies.FirstOrDefault(us => us.HobbyId == hobbyId);
                if (hobby != null)
                {
                    return hobby;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool InsertHobby(Hobby hobby)
        {
            try
            {
                Hobby dbTable = new Hobby();
                //dbTable = _DataContext.Users.Where(d => d.UserID.Equals(user.UserID)).FirstOrDefault();             
                dbTable.HobbyName = hobby.HobbyName;
                

                _context.Hobbies.Add(dbTable);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool UpdateHobbyById(Hobby hobby, int hoobyId)
        {
            var check = _context.Hobbies.Where(us => us.HobbyId.Equals(hoobyId)).SingleOrDefault();
            if (check != null)
            {
                check.HobbyName = hobby.HobbyName;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public int DeleteHobbyById(int hobbyId)
        {
            try
            {
                var hobby = _context.Hobbies.Where(us => us.HobbyId.Equals(hobbyId)).SingleOrDefault();
                if (hobby != null)
                {
                    _context.Hobbies.Remove(hobby);
                    _context.SaveChanges();
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }


    }
}
