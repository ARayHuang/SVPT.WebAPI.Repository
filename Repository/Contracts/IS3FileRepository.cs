using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface IS3FileRepository
    {
        Task UploadFile(Stream stream, string key);
        Task<Stream> DownloadFile(string key);
    }
}
