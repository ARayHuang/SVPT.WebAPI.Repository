using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Helper
{
    public interface IFileNameParseHelper
    {
        public FileNameSplitContainer ParseFilename(string fileName);
    }


    public class FileNameParseHelper : IFileNameParseHelper
    {
        #region Constant
        public readonly int VERSION_INDEX = 0;
        public readonly int PROJECT_INDEX = 1;
        public readonly int PHASE_INDEX = 2;
        public readonly int TEST_ITEM_INDEX = 3;
        public readonly int VENDOR_INDEX = 4;
        public readonly string FILENAME_SPLIT_SYMBOL = "_";
        public readonly string ITEM_SPLIT_SYMBOL = "-";
        public readonly string SUB_ITEM_SPLIT_SYMBOL = "^";
        public readonly string S3_PATH_SYMBOL = "/";
        #endregion

        public FileNameSplitContainer ParseFilename(string fileName)
        {
            try
            {
                string[] key = fileName.Split(FILENAME_SPLIT_SYMBOL);
                if (key.Length < 5)
                {
                    throw new ArgumentNullException();
                }
                string[] Item = key[TEST_ITEM_INDEX].Split(ITEM_SPLIT_SYMBOL);

                FileNameSplitContainer container = new FileNameSplitContainer()
                {
                    Version = key[VERSION_INDEX].Trim(),
                    Project = key[PROJECT_INDEX].Trim(),
                    Phase = key[PHASE_INDEX].Trim(),
                    Item = Item[0].Contains(SUB_ITEM_SPLIT_SYMBOL) ? Item[0].Split(SUB_ITEM_SPLIT_SYMBOL)[0].Trim() : Item[0].Trim(),
                    SubItem = Item[0].Contains(SUB_ITEM_SPLIT_SYMBOL) ? Item[0].Split(SUB_ITEM_SPLIT_SYMBOL)[1].Trim() : string.Empty,
                    Information = Item[1] != null ? String.Join(ITEM_SPLIT_SYMBOL, Item, 1, Item.Length - 1).Trim() : string.Empty,
                    Vendor = key[VENDOR_INDEX] != "NA" ? key[VENDOR_INDEX].Trim() : string.Empty,
                    ExtraKey = String.Join(FILENAME_SPLIT_SYMBOL, key, 5, key.Length - 5).Trim(),
                    FullName = fileName.Trim()
                };

                container = GenS3UploadPath(container);

                return container;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        private FileNameSplitContainer GenS3UploadPath(FileNameSplitContainer container)
        {
            string s3UploadString = String.Join(S3_PATH_SYMBOL,
                container.Version,
                container.Project,
                container.Phase,
                container.Item);

            if (!string.IsNullOrEmpty(container.SubItem))
            {
                s3UploadString = String.Join(S3_PATH_SYMBOL, s3UploadString, container.SubItem);
            }

            if (!string.IsNullOrEmpty(container.Vendor))
            {
                s3UploadString = String.Join(S3_PATH_SYMBOL, s3UploadString, container.Vendor);
            }

            container.S3UploadPath = s3UploadString;

            return container;
        }
    }

    public class FileNameSplitContainer
    {
        public string Version { get; set; }
        public string Project { get; set; }
        public string Phase { get; set; }
        public string Item { get; set; }
        public string SubItem { get; set; }
        public string Information { get; set; }
        public string Vendor { get; set; }
        public string ExtraKey { get; set; }
        public string FullName { get; set; }
        public string S3UploadPath { get; set; }
        public string TestResult { get; set; }
    }
}
