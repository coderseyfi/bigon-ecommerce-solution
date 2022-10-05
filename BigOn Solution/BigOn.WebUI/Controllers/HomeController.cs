using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace BigOn.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BigOnDbContext db;
        private readonly IConfiguration configuration;

        public HomeController(BigOnDbContext db, IConfiguration configuration) 
        {
            this.db = db;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactPost model)
        {
            if (ModelState.IsValid)
            {
                db.ContactPosts.Add(model);
                db.SaveChanges();

                //ViewBag.Message = "Muracietiniz qeyde alindi, tezlikle geri donush edeceyik";
                //ModelState.Clear();
                //return View();

                var response = new
                {
                    error = false,
                    message = "Muracietiniz qeyde alindi, tezlikle geri donush edeceyik",
                };

                return Json(response);
            }

            var responseError = new
            {
                error = true,
                message = "Melumatlar uygun deyil, duzelish edib yeniden yoxlayin",
                state = ModelState.GetErrors()
            };

            return Json(responseError);

        }

        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();
            return View(data);

        }

        [HttpPost]

        public IActionResult Subscribe(Subscribe model)
        {
            if (!ModelState.IsValid)
            {
                string msg = ModelState.Values.First().Errors[0].ErrorMessage;

                return Json(new
                {
                    error = true,
                    message = msg
                });
            }

            var entity = db.Subscribes.FirstOrDefault(s => s.Email.Equals(model.Email));

            if (entity != null && entity.IsApproved == true)
            {
                return Json(new
                {
                    error = false,
                    message = "Siz artiq abune olmusunuz"
                });
            }

            if (entity == null)
            {
                db.Subscribes.Add(model);
                db.SaveChanges();
            }
            else if (entity != null)
            {
                model.Id = entity.Id;
            }

            string token = $"{model.Id}-{model.Email}-{Guid.NewGuid()}".Encrypt(Program.key);

            token = HttpUtility.UrlEncode(token); // tokendeki boshluqlari % ile evez edir

            string message = $"Abuneliyinizi <a href='https://localhost:44382/approve-subscribe?token={token}'>link</a> vasitesile tesdiq edin";


            configuration.SendMail("seyfaddinmn@code.edu.az", message, "Subscribe Approve ticket");
            return Json(new
            {
                error = false,
                message = "E-mailinizə təsdiq mesajı göndərildi"
            });

            

        }

        [Route("/approve-subscribe")]
        public string SubscribeApprove(string token)
        {

            token = token.Decrypt(Program.key);
            Match match = Regex.Match(token, @"^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$");

            if (!match.Success)
            {
                return "Token uygun deyil.";
            }

            int id = Convert.ToInt32(match.Groups["id"]);
            string email = match.Groups["email"].Value;
            string randomKey = match.Groups["randomKey"].Value;

            var entity = db.Subscribes.FirstOrDefault(s => s.Id == id);

            if (entity == null)
            {
                return "Tapilmadi";
            }

            if (entity.IsApproved)
            {
                return "Artiq tesdiq edilib";
            }

            entity.IsApproved = true;
            entity.ApprovedDate = DateTime.UtcNow.AddHours(4);
            db.SaveChanges();

            return $"ID: {id} | Email: {email} | Random Key: {randomKey}";
        }

    }
}

