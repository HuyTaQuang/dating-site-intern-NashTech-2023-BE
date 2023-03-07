using DatingApp.DAL.Contacts;
using DatingApp.DAL.Data;
using DatingApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private AppDbContext _dbContext;
       

        public BaseRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<T> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        //public T GetRecordById(int recordId)
        //{
        //    try
        //    {
        //        var user = _dbContext.Users.FirstOrDefault(us => us.UserId == recordId);
        //        if (user != null)
        //        {
        //            return user;
        //        }
        //        else
        //            return ;
        //    }
        //    catch(Exception)
        //    {
        //        throw new Exception();
        //    }
        //}

        //public int InsertRecord(T t)
        //{     
        //    try
        //    {
        //        var user = new typeof(T).Name();
        //        {
                    
        //        };
        //        _dbContext.Add(t);
        //        _dbContext.SaveChanges();
        //        return 1;
        //    }
        //    catch(Exception ex)
        //    {
        //        return 0;
        //    }
            
        //}

        public int UpdateRecordById(T t, int recordId)
        {
            throw new NotImplementedException();
        }
        public int DeleteRecordById(T t, int recordId)
        {
            throw new NotImplementedException();
        }

        public T GetRecordById(int recordId)
        {
            throw new NotImplementedException();
        }

        public int InsertRecord(T t)
        {
            throw new NotImplementedException();
        }
    }
}
