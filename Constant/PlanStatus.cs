
namespace SVPT.WebAPI.Constant
{
    public enum PlanStatus
    {
        DRAFT = 0,
        LOCK = 1,
        READ_ONLY = 2
    }

    public class PlanStatusMapping
    {
        public static readonly string DRAFT = "DRAFT";
        public static readonly string LOCK = "LOCK";
        public static readonly string READ_ONLY = "READ ONLY";

        public static string Mapping(PlanStatus planStatus)
        {
            switch (planStatus)
            {
                case PlanStatus.DRAFT:
                    return DRAFT;
                case PlanStatus.LOCK:
                    return LOCK;
                case PlanStatus.READ_ONLY:
                    return READ_ONLY;
                default:
                    return string.Empty;
            }
        }
    }
}
