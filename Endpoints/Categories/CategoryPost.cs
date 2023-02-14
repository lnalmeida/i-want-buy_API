using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using i_want_buy.Domain.Products;
using i_want_buy.Infra.Context;

namespace i_want_buy.Endpoints.Categories;

public static class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    private static IResult Action(CategoryRequest categoryRequest, ApplicationDBContext context)
    {
        var category = new Category
        {
            Name = categoryRequest.Name
        };

        context.Categories.Add((category));
        context.SaveChanges();

        return Results.Created($"/Categories/{category.Id}", category.Id);
    }
}