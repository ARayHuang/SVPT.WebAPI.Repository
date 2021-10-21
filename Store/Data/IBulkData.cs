using System.Collections.Generic;

namespace SVPT.WebAPI.Store.Data
{
    public interface IBulkData<T>
    {
        void InsertBulkData();
        List<T> GenerateData();
    }
}
