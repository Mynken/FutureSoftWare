using FSW.Data.Abstract;
using FSW.Data.Entities;
using FSW.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FSW.Controllers
{
    [Authorize]
    public class AdminManageController : Controller
    {
        #region Start bindings
        IAskQestionRepository askQuestionrepository;
        IOrderSiteRepository orderSiteRepository;
        IFeedbackRepository feedbackRepository;
        IGalleryRepository galleryRepository;

        public AdminManageController(IAskQestionRepository repo, IOrderSiteRepository rep, IFeedbackRepository re, IGalleryRepository galleryRe)
        {
            askQuestionrepository = repo;
            orderSiteRepository = rep;
            feedbackRepository = re;
            galleryRepository = galleryRe;
        }

        public int pageSize = 5;

        #endregion

        public ActionResult Start()
        {
            return View();
        }

        #region Indexes
        public ActionResult QuestionIndex()
        {
            return View(askQuestionrepository.AskQuestions);
        }

        public ActionResult OrderSiteIndex()
        {
            return View(orderSiteRepository.OrderSites);
        }

        public ActionResult FeedbackIndex()
        {
            return View(feedbackRepository.Feedbacks);
        }
        #endregion

        #region ReadIndexes
        public ActionResult QuestionAll(int page = 1)
        {
            CustomListViewModel<AskQuestion> model = new CustomListViewModel<AskQuestion>
            {
                Items = askQuestionrepository.AskQuestionsAll
                    .OrderBy(question => question.id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = askQuestionrepository.AskQuestionsAll.Count()
                }
            };
            return View(model);
            //return View(askQuestionrepository.AskQuestionsAll);
        }

        public ActionResult OrderSiteAll(int page = 1)
        {
            CustomListViewModel<OrderSite> model = new CustomListViewModel<OrderSite>
            {
                Items = orderSiteRepository.OrderAll
                                .OrderBy(order => order.id)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = orderSiteRepository.OrderAll.Count()
                }
            };
            return View(model);
        }

        public ActionResult FeedbackAll(int page = 1)
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
            return View(model);
        }

        public ActionResult Gallery(int page = 1)
        {
            CustomListViewModel<Gallery> model = new CustomListViewModel<Gallery>
            {
                Items = galleryRepository.Galleries
                       .OrderBy(gallery => gallery.id)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = galleryRepository.Galleries.Count()
                }
            };
            return View(model);
        }
        #endregion

        #region Details
        public ViewResult QuestionDetails(int Id)
        {
            return View(askQuestionrepository.FindQuestion(Id));
        }

        public ViewResult OrderDetails(int Id)
        {
            return View(orderSiteRepository.FindOrder(Id));
        }

        public ViewResult FeedbackDetails(int Id)
        {
            return View(feedbackRepository.FindFeedback(Id));
        }

        public ViewResult GalleryDetails(int Id)
        {
            return View(galleryRepository.FindGallery(Id));
        }
        #endregion

        #region JSON
        public JsonResult QuestionArchive(int id)
        {
            try
            {
                var question = askQuestionrepository.FindQuestion(id);
                if (question == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                question.isCheked = true;
                askQuestionrepository.SaveQuestion(question);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        public JsonResult OrderArchive(int id)
        {
            try
            {
                var order = orderSiteRepository.FindOrder(id);
                if (order == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                order.isCheked = true;
                orderSiteRepository.SaveSiteOrder(order);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        public JsonResult FeedbackArchive(int id)
        {
            try
            {
                var feedback = feedbackRepository.FindFeedback(id);
                if (feedback == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                feedback.isCheked = true;
                feedbackRepository.SaveFeedback(feedback);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        public JsonResult DeleteFeedback(int id)
        {
            try
            {
                var feedback = feedbackRepository.FindFeedback(id);
                if (feedback == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                feedbackRepository.DeleteFeedback(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        public JsonResult DeleteGallery(int id)
        {
            try
            {
                var gallery = galleryRepository.FindGallery(id);
                if (gallery == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }
                galleryRepository.DeleteGallery(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        #endregion

        public ViewResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGallery(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                galleryRepository.SaveGallery(gallery);
                return RedirectToAction("Gallery");
            }
            else
            {
                return View();
            }
        }

        public ViewResult Edit(int id)
        {
            return View(feedbackRepository.FindFeedback(id));
        }

        [HttpPost]
        public ActionResult Edit(Feedback feedback)
        {
            feedbackRepository.SaveFeedback(feedback);
            return RedirectToAction("FeedbackIndex");

        }

        public ViewResult EditGallery(int id)
        {
            return View(galleryRepository.FindGallery(id));
        }

        [HttpPost]
        public ActionResult EditGallery(Gallery gallery)
        {
            galleryRepository.SaveGallery(gallery);
            return RedirectToAction("Gallery");

        }
    }
}