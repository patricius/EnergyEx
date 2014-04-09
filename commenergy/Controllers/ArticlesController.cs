using System;
using System.Security.AccessControl;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using commenergy.Controllers;
using commenergy.Models;
using System.Linq;
using commenergy.Models.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

public class ArticlesController : Controller
{
    const int PageSize = 10;

    public IArticleRepository _articleRepository;

    private readonly ICommentRepository _commentRepository;

    private readonly HttpContextBase _httpContext;


    public ArticlesController()
        : this(new ArticleRepository(),
        new CommentRepository(),
        new HttpContextWrapper(System.Web.HttpContext.Current))
    {
    }

    public ArticlesController(
        IArticleRepository articleRepository,
        ICommentRepository commentRepository,
        HttpContextBase baseContext)
    {
        this._httpContext = baseContext;
        this._articleRepository = articleRepository;
        this._commentRepository = commentRepository;
    }

    //
    // GET: /Articles/

    public ViewResult Index()
    {
        var currentPage = 1;

        if (!int.TryParse(_httpContext.Request.QueryString["page"], out currentPage)) currentPage = 1;

        var articleList = _articleRepository.GetsArticles(currentPage, PageSize);

        return View(articleList);
    }
    public JsonResult ArticleLists()
    {
        var currentPage = 1;

        if (!int.TryParse(_httpContext.Request.QueryString["page"], out currentPage)) currentPage = 1;

        return Json(_articleRepository.GetsArticles(currentPage, PageSize), JsonRequestBehavior.AllowGet);
    }

      [System.Web.Http.HttpPost]
    public JsonResult ArticleNavNext(int CurrentPage)
    {
        var newPage = CurrentPage + 1;
        return Json(_articleRepository.GetsArticles(newPage, PageSize), JsonRequestBehavior.AllowGet);
    }


      [System.Web.Http.HttpPost]
      public JsonResult ArticleNavPrev(int CurrentPage)
      {
          int newPage;
          if (CurrentPage < 1)
          {
              newPage = 1;
          }

          else
          {
              newPage = CurrentPage - 1;
          }

          return Json(_articleRepository.GetsArticles(newPage, PageSize), JsonRequestBehavior.AllowGet);
      }



    [System.Web.Mvc.Authorize]
    public ViewResult Admin()
    {
        var currentPage = 1;

        if (!int.TryParse(Request.QueryString["page"], out currentPage)) currentPage = 1;

        var articleList = _articleRepository.GetsArticles(currentPage, PageSize);

        return View(articleList);
    }



    public ViewResult Details(int id)
    {
        return View(_articleRepository.Find(id));
    }

    public ViewResult Display(string yyyy, string mm, string dd, string key)
    {
        var articledip = _articleRepository.Find(key);
        return View(articledip);
    }


    public JsonResult Displays(string yyyy, string mm, string dd, string key)
    {
        var articledip = _articleRepository.Find(key);
        return Json(articledip, JsonRequestBehavior.AllowGet);
    }
    [System.Web.Http.HttpPost]
    public JsonResult Comment(Comment model)
    {
        var article = _articleRepository.Find(model.ArticleId);

        model.IpAddress = Request.UserHostAddress;
        model.CreatedOn = DateTime.UtcNow;

        model.Author = model.Author;
        model.Body = model.Body;
        ModelState.Remove("CreatedOn");
        ModelState.Remove("IpAddress");

        TryUpdateModel(model);

        if (ModelState.IsValid)
        {
            _commentRepository.InsertOrUpdate(model);
            article.Comments.Add(model);
            _articleRepository.Save();
            _commentRepository.Save();

        }


        return Json(model, JsonRequestBehavior.AllowGet);
    }



    public JsonResult GetAllArticles()
    {
        return Json(_articleRepository.GetsArticles(1, 100), JsonRequestBehavior.AllowGet);
    }
    //
    //
    // GET: /Articles/Create

    public ActionResult Create()
    {
        return View();
    }



    //
    // POST: /Articles/Create
    [System.Web.Mvc.HttpPost]
    [ValidateInput(false)]
    public JsonResult Create(Article article)
    {
        if (ModelState.IsValid)
        {

            article.Author = User.Identity.Name;
            article.UserId = User.Identity.GetUserId();
            article.Key = Utilities.WebSafeMaker(article.Key);
            article.CreatedOn = DateTime.Now;
            article.Body = article.Body;
            article.ImagePath = article.ImagePath;
            article.Title = article.Title.Trim();
            article.MetaDescription = article.MetaDescription;

            _articleRepository.InsertOrUpdate(article);

            _articleRepository.Save();
        }
        return Json(article, JsonRequestBehavior.AllowGet);
    }



    //
    // GET: /Articles/Edit/5

    public ActionResult Edit(int id)
    {
        return View(_articleRepository.Find(id));
    }

    //
    // POST: /Articles/Edit/5

    [System.Web.Mvc.HttpPost]
    [ValidateInput(false)]
    public JsonResult Edit(Article article)
    {


        var currentArticle = _articleRepository.Find(article.Id);

        currentArticle.Key = Utilities.WebSafeMaker(article.Key);

        currentArticle.UpdatedOn = DateTime.UtcNow;

        currentArticle.Body = article.Body;
        currentArticle.Title = article.Title.Trim();
        currentArticle.MetaDescription = article.MetaDescription;

        _articleRepository.InsertOrUpdate(currentArticle);

        _articleRepository.Save();
        return Json(article, JsonRequestBehavior.AllowGet);
    }

    //
    // GET: /Articles/Delete/5
    [System.Web.Mvc.Authorize]
    public ActionResult Delete(int id)
    {
        return View(_articleRepository.Find(id));
    }

    //
    // POST: /Articles/Delete/5
    [System.Web.Mvc.Authorize]
    [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        _articleRepository.Delete(id);
        _articleRepository.Save();

        return RedirectToAction("Admin");
    }


    public ViewResult UserDashboard()
    {
        string username = User.Identity.Name;
        var UserArticles = _articleRepository.FindByAuthor(username);
        return View(UserArticles);
    }

    public JsonResult UserInfo()
    {

        string username = User.Identity.Name;
        var UserArticles = _articleRepository.FindByAuthor(username);
        var UserArticles4 = _articleRepository.FindByAuthor(username);
        return Json(UserArticles, JsonRequestBehavior.AllowGet);

    }


    //public JsonResult SubmitRating(int Id, int Rating)
    //{


    //    var currentArticle = _articleRepository.Find(Id);

    //    currentArticle.Key = Utilities.WebSafeMaker(currentArticle.Key);

    //    currentArticle.UpdatedOn = DateTime.UtcNow;

    //    currentArticle.Body = currentArticle.Body;
    //    currentArticle.Title = currentArticle.Title;
    //    currentArticle.MetaDescription = currentArticle.MetaDescription;
    //    currentArticle.Ratings.Add(Rating);

    //    _articleRepository.InsertOrUpdate(currentArticle);

    //    _articleRepository.Save();
    //    return Json(currentArticle, JsonRequestBehavior.AllowGet);
    //}



    public JsonResult SaveRating(int Id, float rating)
    {

        var post = _articleRepository.Find(Id);

        if (post.Ratings == null)
            post.Ratings = new List<Ratings>();

        if (User.Identity.IsAuthenticated)
        {
      
            var postRating = new Ratings()
            {
                ArticleId = Id,
                Rating = rating,
                DateTime = DateTime.Now,

            };
            if (User.Identity.IsAuthenticated)
            {
                postRating.UserId = User.Identity.GetUserId();
                post.Ratings.Add(postRating);
                post.AvgRating = post.Ratings.Average(a => a.Rating);
            }

            _articleRepository.InsertOrUpdate(post);

            _articleRepository.Save();
        }
        return Json(post.AvgRating, JsonRequestBehavior.AllowGet);
    }


        [System.Web.Http.HttpPost]
        public JsonResult Upload()
        {
          for (int i = 0; i < Request.Files.Count; i++) {
        // for each file being sent over...
        HttpPostedFileBase file = Request.Files[i];
 
        // Example of gathering information from each file
        int fileSize = file.ContentLength;
        string fileName = file.FileName;
        string mimeType = file.ContentType;
 
        // Open input stream
        System.IO.Stream fileContent = file.InputStream;
        file.SaveAs(Server.MapPath("~/Content/") + fileName); //File will be saved in application root
       
        }
    // Return JSON
          

    return Json("File Uploaded!");

}



}