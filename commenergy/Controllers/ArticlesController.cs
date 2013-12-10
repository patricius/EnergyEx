    using System;
    using System.Security.AccessControl;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using commenergy.Controllers;
    using commenergy.Models;
  
    using Newtonsoft.Json;
    using JsonSerializer = EventStore.Serialization.JsonSerializer;

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
            this._httpContext        = baseContext;
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

        //public ViewResult Display(string yyyy, string mm, string dd, string key)
        //{
        //    return View(_articleRepository.Find(key));
        //}

        [System.Web.Http.HttpPost]
        public ActionResult Comment(Comment model)
        {
            var article = _articleRepository.Find(model.ArticleID);

            model.IpAddress = Request.UserHostAddress;
            model.CreatedOn = DateTime.UtcNow;

            ModelState.Remove("CreatedOn");
            ModelState.Remove("IpAddress");

            TryUpdateModel(model);

            if (ModelState.IsValid)
            {
                _commentRepository.InsertOrUpdate(model);

                _commentRepository.Save();
            }

            Response.Redirect("~/" + article.URLTo + "#comments");
            return new EmptyResult();
        }



        public JsonResult GetAllArticles()
        {
            return Json(_articleRepository.GetsArticles(1, 4), JsonRequestBehavior.AllowGet);
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
        article.Key = Utilities.WebSafeMaker(article.Key);
        article.CreatedOn = DateTime.Now;
       article.Body = article.Body;
       article.Title = article.Title.Trim();
        article.MetaDescription = article.MetaDescription;

        _articleRepository.InsertOrUpdate(article);

        _articleRepository.Save();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _articleRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }


