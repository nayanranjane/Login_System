using Login.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class JobApplicationController : Controller
    {
        RecruitmentManagementEntities dbAccess = new RecruitmentManagementEntities();
        // GET: JobApplication
        public ActionResult Index()
        {
            var jobApplication = dbAccess.JobApplications.ToList();
            return View(jobApplication);
        }
        public ActionResult Create()
        {
            JobApplication jobApplication = new JobApplication();
            return View(jobApplication);
        }
        [HttpPost]
        public ActionResult Create(JobApplication jobApplication)
        {
            var result = dbAccess.JobApplications.Add(jobApplication);
            dbAccess.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            JobApplication jobApplication = new JobApplication();
            jobApplication = dbAccess.JobApplications.Find(id);
            return View(jobApplication);

        }
        [HttpPost]
        public ActionResult Edit(JobApplication jobApplication)
        {
            var result = dbAccess.JobApplications.Find(jobApplication.ApplicationId);
            result.CandidateId = jobApplication.CandidateId;
            result.JobId = jobApplication.JobId;
            result.Resume = jobApplication.Resume;
            result.ApplicationDate = jobApplication.ApplicationDate;
            result.Status = jobApplication.Status;
            result.AbleToReallocation = jobApplication.AbleToReallocation;
            result.PrevCompanyName = jobApplication.PrevCompanyName;
            result.WorkExperience = jobApplication.WorkExperience;
            result.NoticePeriod = jobApplication.NoticePeriod;
            dbAccess.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            var result = dbAccess.JobApplications.Find(id);
            dbAccess.JobApplications.Remove(result);
            dbAccess.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int? id)
        {
            JobApplication jobApplication = new JobApplication();
            jobApplication = dbAccess.JobApplications.Find(id);
            return View(jobApplication);

        }
    }
}