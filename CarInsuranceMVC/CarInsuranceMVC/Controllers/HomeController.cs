using CarInsuranceMVC.Models;
using CarInsuranceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string firstName, string lastName, string emailAddress, int dateOfBirth, int carYear, string carMake, string carModel, bool dui, int speedingTickets, bool coverageOrLiability)
        {


            using (InsuranceEntities db = new InsuranceEntities())
            {
                var quote = new Quote();
                quote.FirstName = firstName;
                quote.LastName = lastName;
                quote.EmailAddress = emailAddress;
                quote.DateOfBirth = dateOfBirth;
                quote.CarYear = carYear;
                quote.CarMake = carMake;
                quote.CarModel = carModel;
                quote.Dui = dui;
                quote.SpeedingTickets = speedingTickets;
                quote.CoverageOrLiability = coverageOrLiability;

                db.Quotes.Add(quote);
                db.SaveChanges();
            }

            return View("Quote");
                        
        }

    }
}