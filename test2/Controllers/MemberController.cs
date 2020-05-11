using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test2.Models;

namespace test2.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            using (Database1Entities db = new Database1Entities())
            {
                return View(db.members.ToList());
            }
        }

        // GET: Member/Details/5
        public ActionResult Details(int m_id)
        {
            using (Database1Entities db = new Database1Entities())
            {
                return View(db.members.Where(x=> x.member_id==m_id).FirstOrDefault());
            }
        }

        // GET: Member/Create
        public ActionResult Create()
        {
          
            return View();
            
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(member member_list)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    /*if (db.members.Any(x => x.member_id == member_list.member_id))
                     {
                        int id = db.members.Max(x => x.member_id);
                        member_list.member_id = id + 1;
                    }*/
                   
                    db.members.Add(member_list);
                    
                    int n =db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }  // TODO: Add insert logic here

            
           
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int m_id)
        {
            using (Database1Entities db = new Database1Entities())
            {
                return View(db.members.Where(x => x.member_id == m_id).FirstOrDefault());
            }
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int m_id, member member_list)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    db.Entry(member_list).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return View();
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int m_id)
        {
            using (Database1Entities db = new Database1Entities())
            {
                return View(db.members.Where(x => x.member_id == m_id).FirstOrDefault());
            }
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int m_id, FormCollection collection)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    member member_list = db.members.Where(x => x.member_id == m_id).FirstOrDefault();
                    db.members.Remove(member_list);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
