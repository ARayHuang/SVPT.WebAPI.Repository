using System;

namespace SVPT.WebAPI.Store.Entity
{
    public class TaskItemTestResultFile : Default
    {
        public Guid Id { get; set; }
        public Guid TaskItemTestResultId { get; set; }
        public string FileName { get; set; }
        public string UploadFileTemporyURL { get; set; }
        public string S3FileAccessKey { get; set; }
        public string VersionId { get; set; }

        public TaskItemTestResult TaskItemTestResult { get; set; }
    }
}
