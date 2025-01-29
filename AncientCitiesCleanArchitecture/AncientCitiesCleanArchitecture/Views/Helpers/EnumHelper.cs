using Microsoft.AspNetCore.Mvc.Rendering;

namespace AncientCities.WebAPI.Views.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<SelectListItem> GetEnumSelectList<T>(bool includeEmpty = true) where T : Enum
        {
            if (includeEmpty)
            {
                yield return new SelectListItem
                {
                    Text = "-- Select Era --",
                    Value = string.Empty
                };
            }

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                yield return new SelectListItem
                {
                    Text = value.ToString(),
                    Value = ((int)value).ToString()
                };
            }
        }
    }
}
