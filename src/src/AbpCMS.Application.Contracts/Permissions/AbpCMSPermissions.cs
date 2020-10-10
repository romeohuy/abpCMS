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
    }
}