using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceMVC.Models;
using CarInsuranceMVC.ViewModels;


namespace CarInsuranceMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var quoteVMs = new List<QuoteVM>();
                var quotes = (from c in db.Quotes where c.Removed == null select c).ToList();
                foreach (var quote in quotes)
                {
                    var quoteVM = new QuoteVM();
                    quoteVM.Id = quote.Id;
                    quoteVM.FirstName = quote.FirstName;
                    quoteVM.LastName = quote.LastName;
                    quoteVM.EmailAddress = quote.EmailAddress;
                    quoteVMs.Add(quoteVM);

                }

                return View(quoteVMs);
            }
        }

        public ActionResult Remove(int Id)
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var quote = db.Quotes.Find(Id);
                quote.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}