using System;
using BlazorAuthSample3.Server.Data;
using BlazorAuthSample3.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuthSample3.Server.Services;
public interface IProductService
{
    ValueTask<List<Product>> GetAllAsync();
}
public class ProductService : IProductService
{
    private readonly DataContext context;
    public ProductService(IDbContextFactory<DataContext> factory)
        => context = factory.CreateDbContext();
    public async ValueTask<List<Product>> GetAllAsync()
    {
        using (context)
        {
            return await context.Products.ToListAsync();
        }
    }
}