using SVPT.WebAPI.Store.Context;

namespace SVPT.WebAPI.Store.Data
{
    public class Fixtures
    {
        public static void InitFixtures(SVTPDbContext context)
        {
            SVTPTemplateData svtpTemplateData = new SVTPTemplateData(context);
            svtpTemplateData.InsertBulkData();

            SVTPTemplateItemData svtpTemplateItemData = new SVTPTemplateItemData(context);
            svtpTemplateItemData.InsertBulkData();

            SVTPTaskData svtpTaskData = new SVTPTaskData(context);
            svtpTaskData.InsertBulkData();

            context.SaveChanges();
        }
    }
}
