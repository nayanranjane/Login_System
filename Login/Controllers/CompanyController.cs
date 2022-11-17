using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class CompanyController : Controller
    {
        RecruitmentManagementEntities db = new RecruitmentManagementEntities();
        public ActionResult Index()
        {
            var companies = db.Companies.ToList();
            return View(companies);
        }
        public ActionResult Create()
        {
            Company company = new Company();
            return View(company);
        }
        [HttpPost]
        public ActionResult Create(Company company)
        {
            var result = db.Companies.Add(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            Company company = new Company();
            company = db.Companies.Find(id);
            return View(company);
        }
        [HttpPost]
        public ActionResult Edit(Company company)
        {
            var result = db.Companies.Find(company.CompanyID);
            result.CompanyName = company.CompanyName;
            result.CompanyLogo = company.CompanyLogo;
            result.CompanyURL = company.CompanyURL;
            result.CompanyRegisterationDate = company.CompanyRegisterationDate;
            result.Email = company.Email;
            result.EmployeeCount = company.EmployeeCount;
            result.PhoneNo = company.PhoneNo;
            result.UserName = company.UserName;
            result.Password = company.Password;
            result.Location = company.Location;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            var company = db.Companies.Find(id);
            return View(company);

        }
        public ActionResult Delete(int? id)
        {
            var result = db.Companies.Find(id);
            db.Companies.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}