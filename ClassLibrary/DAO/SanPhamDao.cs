﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.DAO
{
    public class SanPhamDao
    {
        private DangMinhHieuDbEntities db = new DangMinhHieuDbEntities();
        public IEnumerable<Product> getSanPham() {
            return (IEnumerable<Product>) db.Product.ToList();
        }
        public IEnumerable<Product> getSanPham(string q)
        {
            var sp= db.Product.Where(x => x.Name.Contains(q)
                                            || x.Description.Contains(q))
                                       .ToList();
            return (IEnumerable<Product>)sp;
        }
        public List<Product> getSanPhamTheoLoai()
        {
            var sp = (from l in db.Product join k in db.Category on l.CategoryID equals k.CategoryID
                      where !l.Status.Contains("BLOCKED")
                      select l).Take(8).OrderByDescending(x=>x.ProductID).ToList();
            return sp;
        }
        public Product ctSP(int id)
        {
            var sp = db.Product.Where(x => x.ProductID == id).SingleOrDefault();
            return sp;
        }
        public void addProduct(Product product)
        {
            db.Product.Add(product);
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }
        public void updateProduct(Product product)
        {
            var sp = db.Product.Where(x => x.ProductID == product.ProductID).SingleOrDefault();
            sp.Name = product.Name;
            sp.Description = product.Description;
            sp.UnitCost = product.UnitCost;
            sp.Quantity = product.Quantity;
            sp.Image = product.Image;
            sp.Status = product.Status;
            db.SaveChanges();
        }
        public void deleteProduct(int id)
        {
            var sp = db.Product.Where(x => x.ProductID == id).SingleOrDefault();
            db.Product.Remove(sp);
            db.SaveChanges();
        }
    }
}
