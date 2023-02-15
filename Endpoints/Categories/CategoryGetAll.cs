using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using i_want_buy.Domain.Products;
using i_want_buy.Infra.Context;

namespace i_want_buy.Endpoints.Categories;

public static class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    private static IResult Action(ApplicationDBContext context)
    {
        try
        {
            var categories = context.Categories.ToList();
            if (categories != null)
            {
                var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active });
                return Results.Ok(response);
            };

            return Results.NotFound("There are no registered categories.");
        }
        catch (ApplicationException)
        {
            return Results.Problem("A server error has occurred, please contact the administrator.");
        }

    }
}