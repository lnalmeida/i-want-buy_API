using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using i_want_buy.Domain.Products;
using i_want_buy.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace i_want_buy.Endpoints.Categories;

public static class CategoryPut
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    private static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDBContext context)
    {
        try
        {
            var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return Results.NotFound("Category not found.");
            }

            category.EditInfo(categoryRequest.Name, categoryRequest.Active);

            if (!category.IsValid)
            {
                return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
            }

            context.SaveChanges();
            return Results.Ok("Category edited successfully!");
        }
        catch (ApplicationException)
        {
            return Results.Problem("A server error has occurred, please contact the administrator.");
        }

    }
}