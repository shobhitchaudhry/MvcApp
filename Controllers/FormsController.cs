using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationTest.Models;
using System.IO;

namespace MvcApplicationTest.Controllers
{
    public class FormsController : Controller
    {
        private Form1DBContext db = new Form1DBContext();

        //
        // GET: /Forms/

        public ActionResult Index()
        {
            return View(db.Forms.ToList());
        }

        //
        // GET: /Forms/Details/5

        public ActionResult Details(int id = 0)
        {
            Form1 form1 =new Form1();
            try
            {
                form1 = db.Forms.Find(id);
                if (form1 == null)
                {
                    string newID = TempData["formID"].ToString();
                    Int32.TryParse(newID, out id);
                    form1 = db.Forms.Find(id);
                }
            }
            catch {
                throw new System.ArgumentException("Form cannot be null", "");
            }
                if (form1 == null)
                {
                    return HttpNotFound();
                }
            return View(form1);
        }

        //
        // GET: /Forms/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Forms/Create

        [HttpPost]
        public ActionResult Create(Form1 form1)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(form1);
                db.SaveChanges();


                TempData["form"] = Request.Form;
                return this.RedirectToAction("Edit");

                //return RedirectToAction("Edit", formID1);
            }

            return View(form1);
        }

        //
        // GET: /Forms/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Form1 form1 = new Form1();

            if (TempData["form"] != null)
            {
                try
                {
                    var dict = (TempData["form"]).ToString().Split('&').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);
                    form1.FirstName = (dict["FirstName"]);
                    form1.LastName = (dict["LastName"]);
                    form1.Phone = (dict["Phone"]);
                    form1.Address1 = (dict["Address1"]);
                    form1.Address2 = (dict["Address2"]);
                    form1.City = (dict["City"]);
                    form1.Postal = (dict["Postal"]);
                    return View(form1);

                }
                catch {
                    throw new System.ArgumentException("Parameters cannot be null","");
                }
               
            }
            
            else {
                form1 = db.Forms.Find(id);
                if (form1 == null)
                {
                    return HttpNotFound();
                }
                return View(form1);
            }
        }

        //
        // POST: /Forms/Edit/5

        [HttpPost]
        public ActionResult Edit(Form1 form1)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Resumes/"), fileName);
                    file.SaveAs(path);
                    form1.Resume = file.FileName;
                }
            }

            if (ModelState.IsValid)
            {
                int formID1 = ((Form1)(db.Forms.Where((s => s.FirstName.Contains(form1.FirstName) && s.LastName.Contains(form1.LastName)))).Single()).ID;
                    form1.ID = formID1;

                    var entry = db.Entry<Form1>(form1);

                    if (entry.State == EntityState.Detached)
                    {
                        var set = db.Set<Form1>();
                        Form1 attachedEntity = set.Local.SingleOrDefault(e => e.ID == form1.ID);  // You need to have access to key

                        if (attachedEntity != null)
                        {
                            var attachedEntry = db.Entry(attachedEntity);
                            attachedEntry.CurrentValues.SetValues(form1);
                        }
                        else
                        {
                            entry.State = EntityState.Modified; // This should attach entity
                        }
                    }

                db.SaveChanges();
                TempData["formID"] = form1.ID;
                return this.RedirectToAction("Details");
            }
            return View(form1);
        }


        public ActionResult Delete(int id = 0)
        {
            Form1 form1 = db.Forms.Find(id);
            if (form1 == null)
            {
                return HttpNotFound();
            }
            return View(form1);
        }

        //
        // POST: /Forms/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Form1 form1 = db.Forms.Find(id);
            db.Forms.Remove(form1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Resumes/"), fileName);
                    file.SaveAs(path);
                }
            }

            return RedirectToAction("UploadDocument");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}