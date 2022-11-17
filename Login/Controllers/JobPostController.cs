using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class JobPostController : Controller
    {
        RecruitmentManagementEntities db = new RecruitmentManagementEntities();
        // GET: JobPost
        public ActionResult Index()
        {
            var JobPosts = db.JobPosts.ToList();
            return View(JobPosts);
        }
        public ActionResult Delete(int? id)
        {
            var result = db.JobPosts.Find(id);
            var isDeleted = db.JobPosts.Remove(result);
            return RedirectToAction("Index");

        }
        public ActionResult Create()
        {
            JobPost jobPost = new JobPost();
            return View(jobPost);

        }
        [HttpPost]
        public ActionResult Create(JobPost jobPost)
        {
            var result = db.JobPosts.Add(jobPost);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? id)
        {
            JobPost jobPost = new JobPost();
            jobPost = db.JobPosts.Find(id);
            return View(jobPost);

        }
        public ActionResult Edit(JobPost jobPost)
        {
            var result = db.JobPosts.Find(jobPost.JobId);
            result.Title = jobPost.Title;
            result.CompanyID = jobPost.CompanyID;
            result.CTC = jobPost.CTC;
            result.Location = jobPost.Location;
            result.PostDate = jobPost.PostDate;
            result.LastDate = jobPost.LastDate;
            result.Skill_1 = jobPost.Skill_1;
            result.Skill_2 = jobPost.Skill_2;
            result.Skill_3 = jobPost.Skill_3;
            result.Description = jobPost.Description;
            result.SSCMarks = jobPost.SSCMarks;
            result.HSCMarks = jobPost.HSCMarks;
            result.UGMarks = jobPost.UGMarks;
            result.RequiredExperience = jobPost.RequiredExperience;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}