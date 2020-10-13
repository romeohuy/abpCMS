namespace AbpCMS.CompanyDatas
{
    public static class CompanyDataConsts
    {
        private const string DefaultSorting = "{0}Percent asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyData." : string.Empty);
        }

    }
}