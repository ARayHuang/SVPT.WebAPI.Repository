using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Models
{
    public class TaskItemTestResultFileReturnModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime UploadAt { get; set; }
        public string S3FileAccessKey { get; set; }

    }
}
