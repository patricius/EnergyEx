using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace commenergy.Models
{ 
    public class CommentRepository : ICommentRepository
    {
        commenergyContext context = new commenergyContext();

        public IQueryable<Comment> All
        {
            get { return context.Comments; }
        }

        public IQueryable<Comment> AllIncluding(params Expression<Func<Comment, object>>[] includeProperties)
        {
            IQueryable<Comment> query = context.Comments;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Comment Find(int id)
        {
            return context.Comments.Find(id);
        }

        public void InsertOrUpdate(Comment comment)
        {
            if (comment.ID == default(int)) {
                // New entity
                context.Comments.Add(comment);
            } else {
                // Existing entity
                context.Entry(comment).State = (System.Data.Entity.EntityState) EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var comment = context.Comments.Find(id);
            context.Comments.Remove(comment);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface ICommentRepository : IDisposable
    {
        IQueryable<Comment> All { get; }
        IQueryable<Comment> AllIncluding(params Expression<Func<Comment, object>>[] includeProperties);
        Comment Find(int id);
        void InsertOrUpdate(Comment comment);
        void Delete(int id);
        void Save();
    }
}