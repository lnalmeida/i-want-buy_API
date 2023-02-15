using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using i_want_buy.Domain.Products;
using i_want_buy.Infra.Context;

namespace i_want_buy.Endpoints.Categories;

public static class CategoryGetById
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    private static IResult Action(Guid id, ApplicationDBContext context)
    {
        try
        {
            var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                var response = new CategoryResponse { Id = category.Id, Name = category.Name, Active = category.Active };
                return Results.Ok(response);
            }

            return Results.NotFound("Category not found.");
        }
        catch (ApplicationException)
        {
            return Results.Problem("A server error has occurred, please contact the administrator.");
        }

    }
}