using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Web.Mvc;
using ClassLibrary.DAO;
using ClassLibrary;

namespace BanDongHo.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        SanPhamDao sanPhamDao = new SanPhamDao();
        DanhMucDao danhMucDao = new DanhMucDao();
        
        public ActionResult Index()
        {
            return Redirect("/Admin/SanPham?page=1");
        }
        [HttpGet]
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var SanPham = sanPhamDao.getSanPham();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.SanPham = SanPham.ToPagedList(pageNumber, pageSize);
            return View();
        }
        public ActionResult DanhMuc()
        {
            ViewBag.AllDanhMuc = danhMucDao.getDanhMuc();

            return View();
        }
        [HttpPost]
        public ActionResult DanhMuc(Category category)
        {
            danhMucDao.addCategory(category);
            ViewBag.AllDanhMuc = danhMucDao.getDanhMuc();
            return View();
        }

        [HttpPost]
        public ActionResult SuaDanhMuc(Category category)
        {
            danhMucDao.updateCategory(category);
            return Json(new { ten= category.Name, moTa= category.Description});
        }

        [HttpGet]
        public ActionResult XoaDanhMuc(int id)
        {
            danhMucDao.deleteCategory(id);
            return Redirect("/Admin/SanPham/DanhMuc");
        }
        public ActionResult SuaSP(int idsp)
        {
            ViewBag.CTSP = sanPhamDao.ctSP(idsp);
            ViewBag.DanhMuc = danhMucDao.getDanhMuc();
            return View();
        }
        [HttpPost]
        public ActionResult SuaSP(Product sanPham)
        {
            sanPhamDao.updateProduct(sanPham);
            return Redirect("/Admin/SanPham");
        }
        [HttpGet]
        public ActionResult ThemSP()
        {
            ViewBag.DanhMuc = danhMucDao.getDanhMuc();
            return View();
        }

        [HttpPost]
        public ActionResult ThemSP(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPhamDao.addProduct(sanPham);

                return Redirect("/Admin/SanPham");
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult XoaSP(int idsp)
        {
            sanPhamDao.deleteProduct(idsp);
            return Redirect("/Admin/SanPham");
        }
        [HttpGet]
        public ActionResult TimKiemSP(String q)
        {
            ViewBag.SanPham = sanPhamDao.getSanPham(q);
            return View();
        }
    }
}