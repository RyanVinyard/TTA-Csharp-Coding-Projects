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
        public ActionResult Apply(string firstName, string lastName, string emailAddress, int dateOfBirth, int carYear, string carMake, string carModel, bool dui, int speedingTickets, bool coverageOrLiability, int total)
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


                int quoteTotal = 25;
                if (dateOfBirth > 05092001)
                {
                    quoteTotal = quoteTotal + 100;
                }

                else if (dateOfBirth > 05091994)
                {
                    quoteTotal = quoteTotal + 25;
                }

                if (dateOfBirth < 05091919)
                {
                    quoteTotal = quoteTotal + 25;
                }

                if (carYear > 2015)
                {
                    quoteTotal = quoteTotal + 25;
                }

                if (carMake == "Porsche" && carModel == "911 Carrera")
                {
                    quoteTotal = quoteTotal + 50;
                }

                if (carMake == "Porsche")
                {
                    quoteTotal = quoteTotal + 25;
                }

                quoteTotal = (quoteTotal * (speedingTickets * 10));

                if (dui == true)
                {
                    quoteTotal = Convert.ToInt16(quoteTotal * 1.25);
                }

                if (coverageOrLiability == true)
                {
                    quoteTotal = Convert.ToInt16(quoteTotal * 1.5);
                }
                quote.Total = quoteTotal;

                db.Quotes.Add(quote);
                db.SaveChanges();
            }

            return View("Quote");
                        
        }

    }
}