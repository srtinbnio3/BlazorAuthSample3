using System;
using BlazorAuthSample3.Server.Services;
using BlazorAuthSample3.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuthSample3.Server.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;
    public ProductController(IProductService productService)
    => this.productService = productService;
    [HttpGet]
    public async ValueTask<ActionResult<List<Product>>> GetAll()
    => Ok(await productService.GetAllAsync());
}