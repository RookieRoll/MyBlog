using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Application.ClassificationApplicationService
{
    public interface IClassificationApplicationService
    {
        IQueryable<Classification> Get();
        void Create(string content);
    }
}
