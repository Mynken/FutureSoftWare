using FSW.Data.Abstract;
using FSW.Data.Entities;
using FSW.Infrastructure;
using FutureSoftWare.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSW.Controllers
{
    //[RequireHttps]
    [Culture]
    public class HomeController : Controller
    {
        #region Start Bindings
        IAskQestionRepository askQuestionrepository;
        IOrderSiteRepository orderSiteRepository;
        IFeedbackRepository feedbackRepository;
        IGalleryRepository galleryRepository;

        public int pageSize = 5;
        public int gallerySize = 6;

        public HomeController(IAskQestionRepository askQuestionRepo, IOrderSiteRepository orderSiteRepo, IFeedbackRepository feedbackRepo, IGalleryRepository galleryRepo)
        {
            askQuestionrepository = askQuestionRepo;
            orderSiteRepository = orderSiteRepo;
            feedbackRepository = feedbackRepo;
            galleryRepository = galleryRepo;
        }
        #endregion

        #region Static pages
        public ActionResult Index()
        {
            if (!Request.Browser.IsMobileDevice)
                return View();
            else
                return View("~/Views/Mobile/Index.cshtml");
        }
        public ActionResult About()
        {
            if (!Request.Browser.IsMobileDevice)
                return View();
            else
                return View("~/Views/Mobile/About.cshtml");
        }
        public ActionResult Contacts()
        {
            if (!Request.Browser.IsMobileDevice)
                return View();
            else
                return View("~/Views/Mobile/Contacts.cshtml");
        }
        public ActionResult PriceList()
        {
            return View();
        }
        public ActionResult Brief()
        {
            return View();
        }
        public ActionResult InDevelopment()
        {
            return View();
        }
        public ActionResult FullQuestionList()
        {
            return View();
        }
        
        #endregion

        #region PartialViews
        public ActionResult PartialButtonUp()
        {
            return PartialView("~/Views/Home/Partial/PartialButtonUp.cshtml");
        }
        public ActionResult PartialAskQuestion()
        {
            return PartialView("~/Views/Home/Partial/PartialAskQuestion.cshtml");
        }
        public ActionResult PartialPriceList(string info)
        {
            return PartialView("~/Views/Home/Partial/PartialPriceList.cshtml", info);
        }
        public PartialViewResult PartialFeedback(int page = 1)
        {
                CustomListViewModel<Feedback> model = new CustomListViewModel<Feedback>
                {
                    Items = feedbackRepository.FeedbacksAll
                        .OrderBy(feedback => feedback.id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = feedbackRepository.FeedbacksAll.Count()
                    }
                };
            return PartialView("~/Views/Home/Partial/PartialFeedback.cshtml", model);
        }
        #endregion
      
        #region Forms
        public ViewResult AskQuestion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AskQuestion(AskQuestion askQuestion)
        {
            if (ModelState.IsValid)
            {
                askQuestionrepository.SaveQuestion(askQuestion);
                // add Resources
                TempData["message"] = string.Format("Спасибо за ваш запрос, {0} ",
                       askQuestion.Name + ", мы свяжемся с вами в ближайшее время");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ViewResult OrderSite(string text)
        {
            List<SelectListItem> tariffPlan = new List<SelectListItem>();

            tariffPlan.Add(new SelectListItem { Text = "Сайт-визитка", Value = "Сайт-визитка" });
            tariffPlan.Add(new SelectListItem { Text = "Бизнес - сайт", Value = "Бизнес - сайт" });
            tariffPlan.Add(new SelectListItem { Text = "Сайт компании", Value = "Сайт компании" });
            tariffPlan.Add(new SelectListItem { Text = "Landing Page", Value = "Landing Page" });
            tariffPlan.Add(new SelectListItem { Text = "Custom сайт", Value = "Custom сайт" });
            tariffPlan.Add(new SelectListItem { Text = "Дополнительные услуги", Value = "Дополнительные услуги" });
            tariffPlan.Add(new SelectListItem { Text = "Другое", Value = "Другое" });

            var model = new OrderSite
            {
                TariffPlan = text,
                Tariffs = tariffPlan
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult OrderSite(OrderSite orderSite)
        {
            if (ModelState.IsValid)
            {
                orderSiteRepository.SaveSiteOrder(orderSite);
                // add Resources
                TempData["message"] = string.Format("Спасибо за ваш запрос, {0} ",
                       orderSite.Name + ", мы свяжемся с вами в ближайшее время");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(Feedback feedback)
        {
            if (feedbackRepository.Validation(feedback) && ModelState.IsValid)
            {
                feedbackRepository.SaveFeedback(feedback);
                // add Resources
                TempData["message"] = string.Format("Спасибо за ваш отзыв, {0}. Через некоторое время Ваш отзыв появится в списке отзывов.",
                       feedback.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // TODO add Resources
                ModelState.AddModelError("", "Только 1 отзыв в течении дня с той же самой почты");
                return View();
            }
        }
        #endregion

        #region Errors
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View("~/Views/Home/Errors/Forbidden.cshtml");
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("~/Views/Home/Errors/NotFound.cshtml");
        }
        public ActionResult ServiceUnavaible()
        {
            Response.StatusCode = 503;
            return View("~/Views/Home/Errors/ServiceUnavaible.cshtml");
        }
        #endregion

        public ActionResult Gallery(int page = 1)
        {
            CustomListViewModel<Gallery> model = new CustomListViewModel<Gallery>
            {
                Items = galleryRepository.Galleries
                       .OrderBy(gallery => gallery.id)
                       .Skip((page - 1) * gallerySize)
                       .Take(gallerySize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = gallerySize,
                    TotalItems = galleryRepository.Galleries.Count()
                }
            };
            return View(model);
        }
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            List<string> cultures = new List<string>() { "ru", "en", "pl" };
            if (!cultures.Contains(lang))
            {
                lang = "en";
            }
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}



//  [OutputCache(Duration = 3600, VaryByParam = "none")] onServer for same content for all
// [OutputCache(Duration=3600, VaryByParam="none", Location=OutputCacheLocation.Client, NoStore=true)] onClient for every user not same content
// NoStore property is used to inform proxy servers and browser that they should not store a permanent copy of the cached content.
// [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]

//    <caching>
//<outputCacheSettings>
//    <outputCacheProfiles>
//        <add name = "Cache1Hour" duration="3600" varyByParam="none"/>
//    </outputCacheProfiles>
//</outputCacheSettings>
//</caching>

//For example, the <caching> web configuration section in Listing 6 defines a cache profile named Cache1Hour.
//    The<caching> section must appear within the<system.web> section of a web configuration file.
//     [OutputCache(CacheProfile = "Cache1Hour")]