using Amazon.S3;
using Amazon.S3.Transfer;
using SVPT.WebAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository
{
    public class S3FileRepository : IS3FileRepository
    {
        private readonly ITransferUtility _transferUtility;

        #region Constant
        public readonly string BucketName = "svtp-2";
        #endregion

        public S3FileRepository(ITransferUtility transferUtility)
        {
            _transferUtility = transferUtility ?? throw new ArgumentNullException(nameof(transferUtility));
        }

        public async Task UploadFile(Stream stream, string key)
        {
            await _transferUtility.UploadAsync(stream, BucketName, key);
        }

        public async Task<Stream> DownloadFile(string key)
        {
            return await _transferUtility.OpenStreamAsync(BucketName, key);
        }
    }
}
