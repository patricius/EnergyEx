using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;

namespace commenergy.Models
{ 
    public class ArticleRepository : IArticleRepository
    {
        commenergyContext context = new commenergyContext();

        public IQueryable<Article> All
        {
            get { return context.Articles; }
        }

        public IQueryable<Article> AllIncluding(params Expression<Func<Article, object>>[] includeProperties)
        {
            IQueryable<Article> query = context.Articles;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

    

        public void InsertOrUpdate(Article article)
        {
            if (article.Id == default(int)) {
                // New entity
                context.Articles.Add(article);
            } else {
                // Existing entity
                context.Entry(article).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var article = context.Articles.Find(id);
            context.Articles.Remove(article);
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }

            catch (DbEntityValidationException dbValEx)
            {
                var
                    outputlines = new StringBuilder();

                foreach (var eve in dbValEx.EntityValidationErrors)
                {
                    outputlines.AppendFormat(
                        "{0}: Entity of type\"{1}\" in state\"{2}\" has the following validation errors:"
                        , DateTime.Now, eve.Entry.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputlines.AppendFormat("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new DbEntityValidationException(
                    string.Format("Validations errors\r\n{0}", outputlines.ToString()), dbValEx);
            }
        }

        public void Dispose() 
        {
            context.Dispose();
        }

        public Article Find(int id)
        {
            return context.Articles.Find(id);
        }


       public Article Find(string key)
        {
            return context.Articles.Include(i => i.Comments).First(e => e.Key == key);
        }

        public PagedResult<Article> GetsArticles(int page, int pageSize)
        {
            var results = context.Articles.OrderByDescending(o => o.CreatedOn).Include(i => i.Comments);

            var result = GetPagedResultForQuery(results, page, pageSize);

            return result;
        }

        private static PagedResult<Article> GetPagedResultForQuery(IQueryable<Article> query, int page, int pageSize)
        {
            var result = new PagedResult<Article> {CurrentPage = page, PageSize = pageSize, RowCount = query.Count()};
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize) .ToList();
            
            return result;
        }
    }

    public interface IArticleRepository : IDisposable
    {
        PagedResult<Article> GetsArticles(int page, int pageSize);
        IQueryable<Article> All { get; }
        IQueryable<Article> AllIncluding(params Expression<Func<Article, object>>[] includeProperties);
        Article Find(int id);
        Article Find(string key);
        void InsertOrUpdate(Article article);
        void Delete(int id);
        void Save();
    }
}