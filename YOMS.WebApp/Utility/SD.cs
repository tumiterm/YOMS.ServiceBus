namespace YOMS.WebApp.Utility
{
    public  class SD
    {
        public static string AuthAPIBase {get; set;}
        public static string ProfilingAPI { get; set;}
        public static string EmailAPI { get; set;}

        public const string RoleAdmin = "ADMIN";
        public const string RoleApplicant = "APPLICANT";
        public const string TokenCookie = "JWTToken";

        public enum APIType
        {
            GET,
            POST,
            PUT, 
            DELETE

        }
    }
}
