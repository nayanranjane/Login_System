using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class SkillsController : Controller
    {
        RecruitmentManagementEntities db = new RecruitmentManagementEntities();
        // GET: Skills
        public ActionResult Index()
        {
            var result =  db.Skills.ToList();
            return View(result);
        }
    }
}