using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBlog.EntityFrameWorkCore.Models;
using MyBlog.Core.Classifications;

namespace MyBlog.Application.ClassificationApplicationService
{
    public class ClassificationAppLicationService : IClassificationApplicationService
    {

        private readonly ClassificationManager _cManager;
        private readonly MyBlogContext _db;

        public ClassificationAppLicationService(
            ClassificationManager cManager,
            MyBlogContext db)
        {
            _cManager = cManager;
            _db = db;
        }
        public IQueryable<Classification> Get()
        {
            return _cManager.Get();
        }

        public void Create(string content)
        {
            Classification classification = new Classification();
            _cManager.Create(classification);
            
        }

        public void Remove(int id)
        {
            
        }
    }
}
