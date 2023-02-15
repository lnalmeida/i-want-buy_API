using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using i_want_buy.Domain.Products;
using i_want_buy.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace i_want_buy.Endpoints.Categories;

public static class CategoryDelete
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    private static IResult Action([FromRoute] Guid id, ApplicationDBContext context)
    {
        try
        {
            var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return Results.Ok("Category deleted successfully!");
            }

            return Results.NotFound("Category not found.");
        }
        catch (ApplicationException)
        {
            return Results.Problem("A server error has occurred, please contact the administrator");
        }
    }
}