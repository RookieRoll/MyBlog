using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewModel.Classifications
{
    public class ClassificationViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string CreateTime { get; set; }
        public string ModificationTime { get; set; }

        public static ClassificationViewModel Convert(int id, string content,
            DateTime createTime,
            DateTime? modificationTime)
        {
            var modificatime = (modificationTime).Value;
            return new ClassificationViewModel
            {
                Id = id,
                Content = content,
                CreateTime = createTime.ToString("yyyy-MM-dd HH-mm"),
                ModificationTime = modificatime.ToString("yyyy-MM-dd HH-mm")
            };
        }
    }
}
