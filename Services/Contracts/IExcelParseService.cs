using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services.Contracts
{
    public interface IExcelParseService
    {
        void CreateExcelPackage(Stream stream);
        void CreateExcelPackage(string path);
        string GetTestResultStatus();
        string GetVersion();
        string GetTemplateDate();
    }
}
