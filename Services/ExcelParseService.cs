using OfficeOpenXml;
using SVPT.WebAPI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services
{
    public class ExcelParseService : IExcelParseService
    {
        private ExcelPackage _package;
        private ExcelWorksheet _excelSheet;

        #region Constant
        public readonly string COVER_SHEET = "Cover";
        public readonly string TEST_RESULT = "F3";
        public readonly string VERSION = "A1";
        public readonly string RELEASED_DATE = "I1";
        #endregion

        public void CreateExcelPackage(Stream stream)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage(stream);
            _excelSheet = _package.Workbook.Worksheets[COVER_SHEET];
        }

        public void CreateExcelPackage(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage(new FileInfo(path));
            _excelSheet = _package.Workbook.Worksheets[COVER_SHEET];
        }

        public string GetTestResultStatus()
        {
            return _excelSheet.Cells[TEST_RESULT].Text;
        }

        public string GetVersion()
        {
            return _excelSheet.Cells[VERSION].Text;
        }

        public string GetTemplateDate()
        {
            return _excelSheet.Cells[RELEASED_DATE].Text;
        }
    }
}
