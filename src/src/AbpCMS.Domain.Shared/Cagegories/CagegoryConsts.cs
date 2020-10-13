namespace AbpCMS.Cagegories
{
    public static class CagegoryConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Cagegory." : string.Empty);
        }

    }
}