﻿using Client.Models;
using Data;
using Data.Model;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Location> _locationRepository;

        public HomeController(IRepository<Car> carRepository, IRepository<Location> locationRepository)
        {
            _carRepository = carRepository;
            _locationRepository = locationRepository;
        }

        // GET: Home        
        public ActionResult Index()
        {
            var cars = _carRepository.GetAll();
            return View(cars);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var car = _carRepository.GetById(id);
            return View(car);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            var car = new CarModel();
            car.Locations = new SelectList(_locationRepository.GetAll(), "Id", "Name", 0);
            return View(car);
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(CarModel car)
        {
            try
            {
                // TODO: Add insert logic here
                var dbCar = new Car
                {
                    Brand = car.Brand,
                    LocationId = car.SelectedLocationId,
                    Mileage = car.Mileage,
                    Reserved = car.Reserved,
                };
                _carRepository.Create(dbCar);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
