using ClassLibrary.DAO;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        TaiKhoanDao taiKhoanDao = new TaiKhoanDao();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kTraDangNhap(Account account)
        {
            bool oke= taiKhoanDao.checkTK(account.userName, account.password);
            if(oke)
                return Redirect("/Admin/SanPham");
            return Redirect("/Admin/Login");
        }
    }
}