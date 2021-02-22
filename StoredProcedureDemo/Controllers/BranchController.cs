using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoredProcedureDemo.Models;

namespace StoredProcedureDemo.Controllers
{
    
    public class BranchController : Controller
    {
        spDemoEntities1 db = new spDemoEntities1();

        // GET: Branch
        public ActionResult Index()
        {
            return View(db.sp_select_branch().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch o)
        {
            db.sp_insert_branch(o.BranchId, o.BranchName);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var s = db.sp_find_branch(id).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Branch b)
        {
            db.sp_update_branch(b.BranchId, b.BranchName);
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            db.sp_delete_branch(id);
            return RedirectToAction("Index");
        }
    }
}