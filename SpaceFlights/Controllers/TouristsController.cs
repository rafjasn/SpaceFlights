using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpaceFlights.Models;

namespace SpaceFlights.Controllers
{
    public class TouristsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tourists
        public ActionResult Index()
        {
            return View(db.Tourists.ToList());
        }

        // GET: Tourists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }


            var Results = from f in db.Flights
                select new
                {
                    f.FlightId,
                    f.Name,
                    Checked = ((from tf in db.TouristsToFlights
                                   where (tf.TouristId == id) & (tf.FlightId == f.FlightId)
                                   select tf).Count() > 0)
                };
            var MyViewModel = new TouristsViewModel();
            MyViewModel.TouristId = id.Value;
            MyViewModel.FirstName = tourist.FirstName;
            MyViewModel.LastName = tourist.LastName;
            MyViewModel.Gender = tourist.Gender;
            MyViewModel.Country = tourist.Country;
            MyViewModel.Remarks = tourist.Remarks;
            MyViewModel.DateOfBirth = tourist.DateOfBirth;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel
                {
                    Id = item.FlightId,
                    Name = item.Name,
                    Checked = item.Checked
                });
            }

            MyViewModel.Flights = MyCheckBoxList;
            return View(MyViewModel);
        }

        // GET: Tourists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tourists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Gender,Country,Remarks,DateOfBirth")] Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                db.Tourists.Add(tourist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourist);
        }

        // GET: Tourists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }


            var Results = from f in db.Flights
                select new
                {
                    f.FlightId,
                    f.DepartureDate,
                    f.Name,
                    Checked = ((from tf in db.TouristsToFlights
                                   where (tf.TouristId == id) & (tf.FlightId == f.FlightId)
                                   select tf).Count() > 0)
                };
            var MyViewModel = new TouristsViewModel();
            MyViewModel.TouristId = id.Value;
            MyViewModel.FirstName = tourist.FirstName;
            MyViewModel.LastName = tourist.LastName;
            MyViewModel.Gender = tourist.Gender;
            MyViewModel.Country = tourist.Country;
            MyViewModel.Remarks = tourist.Remarks;
            MyViewModel.DateOfBirth = tourist.DateOfBirth;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel
                {
                    Id = item.FlightId,
                    Name = item.Name,
                    Checked = item.Checked,
                    DepartureDate = item.DepartureDate
                });
            }

            MyViewModel.Flights = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Tourists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TouristsViewModel tourist)
        {
            if (ModelState.IsValid)
            {
                var myTourist = db.Tourists.Find(tourist.TouristId);

                myTourist.FirstName = tourist.FirstName;
                myTourist.LastName = tourist.LastName;

                foreach (var item in db.TouristsToFlights)
                {
                    
                        if (item.TouristId == tourist.TouristId)
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                            
                           

                        }
                    
                }

                foreach (var item in tourist.Flights)
                {
                    foreach (var item2 in db.Flights.Where(n =>n.FlightId == item.Id))
                    {


                        if (item.Checked && item2.NumberOfSeats > item2.NumberOfSeatsTaken)
                        {

                            db.TouristsToFlights.Add(new TouristToFlight()
                            {
                                TouristId = tourist.TouristId,
                                FlightId = item.Id
                            });
                            item2.NumberOfSeatsTaken += 1;
                        }
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourist);
        }

        // GET: Tourists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }

        // POST: Tourists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tourist tourist = db.Tourists.Find(id);
            db.Tourists.Remove(tourist);
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
