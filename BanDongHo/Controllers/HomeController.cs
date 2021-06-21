using ClassLibrary;
using ClassLibrary.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Controllers
{
    public class HomeController : Controller
    {
        SanPhamDao sanPhamDao = new SanPhamDao();
        DanhMucDao danhMucDao = new DanhMucDao();
        public ActionResult Index()
        {
            ViewBag.SanPham= sanPhamDao.getSanPhamTheoLoai();
            ViewBag.DanhMuc = danhMucDao.getDanhMuc();
            return View();
        }

    }
}