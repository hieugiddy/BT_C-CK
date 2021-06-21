using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
    public class TaiKhoanDao
    {
        private DangMinhHieuDbEntities db = new DangMinhHieuDbEntities();
        public bool checkTK(string user, string mk)
        {
            UserAccount userAccount = db.UserAccount.Where(x => x.UserName == user && x.Password == mk).SingleOrDefault();
            if (userAccount != null)
                return true;
            return false;
        }
        public UserAccount ctTK(int id)
        {
            UserAccount userAccount = db.UserAccount.Where(x => x.ID == id).SingleOrDefault();
            return userAccount;
        }
        public IEnumerable<UserAccount> getUserAccounts()
        {
            return (IEnumerable<UserAccount>)db.UserAccount.OrderByDescending(x=>x.ID).ToList();
        }
        public IEnumerable<UserAccount> getUserAccounts(string q)
        {
            var tk = db.UserAccount.Where(x => x.UserName.Contains(q)
                                              || x.Status.Contains(q))
                                       .OrderByDescending(x => x.ID).ToList();
            return (IEnumerable<UserAccount>)tk;
        }
        public void addUserAccount(UserAccount userAccount)
        {
            db.UserAccount.Add(userAccount);
            db.SaveChanges();
        }
        public void updateUserAccount(UserAccount userAccount)
        {
            var ac = db.UserAccount.Where(x => x.ID == userAccount.ID).SingleOrDefault();
            ac.UserName = userAccount.UserName;
            ac.Password = userAccount.Password;
            ac.Status = userAccount.Status;
            db.SaveChanges();
        }
        public void deleteUserAccount(int id)
        {
            var ac = db.UserAccount.Where(x => x.ID == id).SingleOrDefault();
            db.UserAccount.Remove(ac);
            db.SaveChanges();
        }
    }
}
