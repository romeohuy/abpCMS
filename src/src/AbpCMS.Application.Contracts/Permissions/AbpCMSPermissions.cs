namespace AbpCMS.Permissions
{
    public static class AbpCMSPermissions
    {
        public const string GroupName = "AbpCMS";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = GroupName + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Cagegories
        {
            public const string Default = GroupName + ".Cagegories";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Companies
        {
            public const string Default = GroupName + ".Companies";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class CompanyDatas
        {
            public const string Default = GroupName + ".CompanyDatas";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}