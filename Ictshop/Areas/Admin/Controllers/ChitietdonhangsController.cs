﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Areas.Admin.Controllers
{
    public class ChitietdonhangsController : Controller
    {
        private Qlbanhang db = new Qlbanhang();

        // GET: Admin/Chitietdonhangs
        public ActionResult Index()
        {
            var chitietdonhangs = db.Chitietdonhangs.Include(c => c.Donhang).Include(c => c.Sanpham);
            return View(chitietdonhangs.ToList());
        }

        // GET: Admin/Chitietdonhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // GET: Admin/Chitietdonhangs/Create
        public ActionResult Create()
        {
            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Diachinhanhang");
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp");
            return View();
        }

        // POST: Admin/Chitietdonhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madon,Masp,Soluong,Phuongthucthanhtoan,Dongia,Thanhtien")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Chitietdonhangs.Add(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Diachinhanhang", chitietdonhang.Madon);
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", chitietdonhang.Masp);
            return View(chitietdonhang);
        }

        // GET: Admin/Chitietdonhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Diachinhanhang", chitietdonhang.Madon);
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", chitietdonhang.Masp);
            return View(chitietdonhang);
        }

        // POST: Admin/Chitietdonhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madon,Masp,Soluong,Phuongthucthanhtoan,Dongia,Thanhtien")] Chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Madon = new SelectList(db.Donhangs, "Madon", "Diachinhanhang", chitietdonhang.Madon);
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", chitietdonhang.Masp);
            return View(chitietdonhang);
        }

        // GET: Admin/Chitietdonhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // POST: Admin/Chitietdonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietdonhang chitietdonhang = db.Chitietdonhangs.Find(id);
            db.Chitietdonhangs.Remove(chitietdonhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
