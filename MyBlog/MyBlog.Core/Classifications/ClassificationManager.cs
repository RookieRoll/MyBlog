using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Core.Classifications
{
    public class ClassificationManager
    {

        private readonly MyBlogContext _db;

        public ClassificationManager(MyBlogContext db)
        {
            _db = db;
        }

        public IQueryable<Classification> Get()
        {
            return _db.Classification;
        }

        public void Create(Classification classify)
        {
            _db.Classification.Add(classify);
            _db.SaveChanges();
        }

        public void Remove(int id)
        {
            var classify = _db.Classification.AsParallel().FirstOrDefault(m=>m.Id==id);
            classify.IsDeleted = true;
            classify.DeletionTime = DateTime.Now;
            classify.ModificationDate = DateTime.Now;
            _db.SaveChanges();
        }

    }
}
