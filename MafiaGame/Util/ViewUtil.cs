using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MafiaGame.Util
{
    public static class ViewUtil
    {
        public static IEnumerable<SelectListItem> ToOptionList<T>(IEnumerable<T> options, Func<T, string> valueExtractor)
        {
            var items = new List<SelectListItem>();

            foreach(var option in options)
            {
                items.Add(new SelectListItem { Text = valueExtractor.Invoke(option) });
            }

            return items;
        }
    }
}