using CarInsuranceMVC.Models;
using CarInsuranceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarInsuranceMVC.Controllers
{
    public partial class HomeController : Controller
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


                
                if (dateOfBirth > 05092001)
                {
                    Total.quoteTotal = Total.quoteTotal + 100;
                }

                else if (dateOfBirth > 05091994)
                {
                    Total.quoteTotal = Total.quoteTotal + 25;
                }

                if (dateOfBirth < 05091919)
                {
                    Total.quoteTotal = Total.quoteTotal + 25;
                }

                if (carYear > 2015)
                {
                    Total.quoteTotal = Total.quoteTotal + 25;
                }

                if (carMake == "Porsche" && carModel == "911 Carrera")
                {
                    Total.quoteTotal = Total.quoteTotal + 50;
                }

                if (carMake == "Porsche")
                {
                    Total.quoteTotal = Total.quoteTotal + 25;
                }

                if (speedingTickets > 0)
                {
                    Total.quoteTotal = (Total.quoteTotal * (speedingTickets * 10));
                }
                

                if (dui == true)
                {
                    Total.quoteTotal = Convert.ToInt16(Total.quoteTotal * 1.25);
                }

                if (coverageOrLiability == true)
                {
                    Total.quoteTotal = Convert.ToInt32(Total.quoteTotal * 1.5);
                }
                quote.Total = Total.quoteTotal;

                db.Quotes.Add(quote);
                db.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Your total is: $" + Total.quoteTotal + " per month.");
                Total.quoteTotal = 25;
                
            }

            return View("Quote");
                        
        }

    }
}