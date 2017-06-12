using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBlog.EntityFrameWorkCore.Models;
using MyBlog.Core.Classifications;
using MyBlog.Core;
using System.Net;

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
            return _cManager.Get().Where(m => !m.IsDeleted);
        }

        public Classification Get(int id)
        {
            var data = Get();
            var classify = data
                .AsParallel()
                .FirstOrDefault(m => m.Id == id);

            return classify ?? throw new UserFriendlyException("该分类不存在", HttpStatusCode.BadRequest);
        }
        public void Create(string content)
        {
            if (IsExited(content))
                throw new UserFriendlyException("已存在");
            Classification classification = Classification.Convert(content);
            _cManager.Create(classification);

        }

        private bool IsExited(string content)
        {
            var result = Get()
                .FirstOrDefault(m => m.Content
                .Equals(content, StringComparison.OrdinalIgnoreCase));

            return result == null ? false : true;
        }

        public void Remove(int id)
        {
            var data = Get(id);
            _cManager.Remove(id);
        }

        public void Update(int id, string content)
        {
            if (IsExited(content))
                throw new UserFriendlyException("已存在");
            var data = Get(id);
            _cManager.Update(id, content);

        }
    }
}
