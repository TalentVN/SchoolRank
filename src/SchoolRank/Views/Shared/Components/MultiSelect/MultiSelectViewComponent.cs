using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MultiSelectComponent.Views.Components
{
    public class MultiSelectViewComponent : ViewComponent
    {
        public MultiSelectViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(
        IEnumerable<SelectListItem> validItems, IEnumerable<SelectListItem> invalidItems, string submitUrl)
        {
            // ViewData["validItems"] = validItems;

            ViewData["validItems"] = Enumerable.Range(1, 50)
                        .Select(n => new SelectListItem
                        {
                            value = n.ToString(),
                            text = n.ToString()
                        }).ToArray();

            ViewData["invalidIds"] = Enumerable.Range(1, 25)
                        .Select(n => new string(n.ToString())).ToList();

            return View();
        }
    }

    public class SelectListItem
    {
        public string value { get; set; }

        public string text { get; set; }
    }
}
