namespace AbpCMS.Companies
{
    public static class CompanyConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Company." : string.Empty);
        }

    }
}