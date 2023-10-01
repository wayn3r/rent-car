using Microsoft.AspNetCore.Mvc.Rendering;
using RentCar.Database.Entities;

namespace RentCar.Helpers
{
    public class StatusSelectItemsHelper
    {

   
            public static IEnumerable<SelectListItem> GetStatusOptions()
            {
                var items = new List<SelectListItem>();

                IEnumerable<Status> statuses = Enum.GetValues(typeof(Status)).Cast<Status>();

                foreach (var status in statuses)
                {
                   

                    items.Add(new SelectListItem()
                    {
                        Text = status.ToString(),
                        Value = ((int)status).ToString(),
                    });
                }

                return items;
            }
        }
    }

