namespace SVPT.WebAPI.Constant
{
    public enum ResultStatus
    {
        NA = 0,
        NOT_START = 1,
        IN_PROGRESS = 2,
        PASS = 3,
        PASS_WITH_FIX = 4,
        FAILED = 5,
        COMPLETED = 6,
        UNKNOWN = 7,
        BLOCKED = 8,
        WAIVED = 9
    }

    public class ResultStatusMapping
    {
        public static readonly string NA = "NA";
        public static readonly string NOT_START = "NOT_START";
        public static readonly string IN_PROGRESS = "IN_PROGRESS";
        public static readonly string PASS = "PASS";
        public static readonly string PASS_WITH_FIX = "PASS_WITH_FIX";
        public static readonly string FAILED = "FAILED";
        public static readonly string COMPLETED = "COMPLETED";
        public static readonly string UNKNOWN = "UNKNOWN";
        public static readonly string BLOCKED = "BLOCKED";
        public static readonly string WAIVED = "WAIVED";

        public static string Mapping(ResultStatus resultStatus)
        {
            switch (resultStatus)
            {
                case ResultStatus.NA:
                    return NA;
                case ResultStatus.NOT_START:
                    return NOT_START;
                case ResultStatus.IN_PROGRESS:
                    return IN_PROGRESS;
                case ResultStatus.PASS:
                    return PASS;
                case ResultStatus.PASS_WITH_FIX:
                    return PASS_WITH_FIX;
                case ResultStatus.FAILED:
                    return FAILED;
                case ResultStatus.COMPLETED:
                    return COMPLETED;
                case ResultStatus.UNKNOWN:
                    return UNKNOWN;
                case ResultStatus.BLOCKED:
                    return BLOCKED;
                case ResultStatus.WAIVED:
                    return WAIVED;
                default:
                    return string.Empty;
            }
        }
    }
}
