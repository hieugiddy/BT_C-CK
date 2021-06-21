using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using ClassLibrary.DAO;
using PagedList;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        TaiKhoanDao taiKhoanDao = new TaiKhoanDao();
        public ActionResult Index()
        {
            return Redirect("/Admin/TaiKhoan?page=1");
        }
        [HttpGet]
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var TaiKhoan = taiKhoanDao.getUserAccounts();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.TaiKhoan = TaiKhoan.ToPagedList(pageNumber, pageSize);
            return View();
        }

        
        [HttpPost]
        public ActionResult ThemTaiKhoan(UserAccount taiKhoan)
        {
            taiKhoanDao.addUserAccount(taiKhoan);
            return Redirect("/Admin/TaiKhoan");
        }
        [HttpGet]
        public ActionResult SuaTK(int idtk)
        {
            ViewBag.CTTaiKhoan = taiKhoanDao.ctTK(idtk);

            return View();
        }
        [HttpPost]
        public ActionResult SuaTK(UserAccount taiKhoan)
        {
            taiKhoanDao.updateUserAccount(taiKhoan);
            
            return Redirect("/Admin/TaiKhoan");
        }
        [HttpGet]
        public ActionResult TimKiemTK(String q)
        {
            ViewBag.TaiKhoan = taiKhoanDao.getUserAccounts(q);
            return View();
        }
        [HttpGet]
        public ActionResult XoaTK(int idtk)
        {
            taiKhoanDao.deleteUserAccount(idtk);

            return Redirect("/Admin/TaiKhoan");
        }
    }
}