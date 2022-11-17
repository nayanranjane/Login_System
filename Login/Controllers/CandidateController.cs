using Login.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        RecruitmentManagementEntities db = new RecruitmentManagementEntities();

        public ActionResult Index()
        {
            var result = db.Candidates.ToList();
            return View(result);
        }
        public ActionResult Details(int? id)
        {
            var Candidate = new Candidate();
            Candidate = db.Candidates.Find(id);
            return View(Candidate);
        }
        public ActionResult Delete(int? id)
        {
            var result = db.Candidates.Find(id);
            db.Candidates.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var candidate = new Candidate();
            candidate = db.Candidates.Find(id);
            return View(candidate);

        }

        [HttpPost]
        public ActionResult Edit(Candidate candidate)
        {
            var result = db.Candidates.Find(candidate.CandidateID);
            result.CandidateName = candidate.CandidateName;
            result.CandidateEmail = candidate.CandidateEmail;
            result.CandidateMobileNo = candidate.CandidateMobileNo;
            result.CandidateLocation = candidate.CandidateLocation;
            result.UserName = candidate.UserName;
            result.Password = candidate.Password;
            result.CandidateImg = candidate.CandidateImg;
            result.CandidateGender = candidate.CandidateGender;
            result.CandidateDateOfBirth = candidate.CandidateDateOfBirth;
            result.SSC_Marks = candidate.SSC_Marks;
            result.SSC_School = candidate.SSC_School;
            result.HSC_College = candidate.HSC_College;
            result.HSC_Marks = candidate.HSC_Marks;
            result.UG_Marks = candidate.UG_Marks;
            result.UG_College = candidate.UG_College;
            result.Skill_1 = candidate.Skill_1;
            result.Skill_2 = candidate.Skill_2;
            result.Skill_3 = candidate.Skill_3;
            db.SaveChanges();
            return RedirectToAction("Index");   


        }
        public ActionResult Create()
        {
            Candidate candidate = new Candidate();
            var skills = db.Skills.ToList();
            ViewData["Skills"] = skills;
            List<Skill> skillItem = new List<Skill>();
            foreach(var item in skills)
            {
                skillItem.Add(new Skill { SkillsID = item.SkillsID,SkillName = item.SkillName});
            }
            ViewBag.SKILLS = skillItem;
            return View(candidate); 
        }
        [HttpPost]

        public ActionResult Create(Candidate candidate)
        {
            if (true)
            {
                string filename = Path.GetFileNameWithoutExtension(candidate.ImageFile.FileName); // .FleName Contain the name of the file with the directory
                string extension = Path.GetExtension(candidate.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                candidate.CandidateImg = "~/Image" + filename;
                filename = Path.Combine(Server.MapPath("~/Image"), filename);
                candidate.ImageFile.SaveAs(filename);
                var result = (db.Candidates.Add(candidate));
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Create", "Candidate");
            }
        }
 



    }
}