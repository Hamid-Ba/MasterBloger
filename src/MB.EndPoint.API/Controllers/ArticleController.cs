using System;
using MB.Application.Contract.ArticleAgg;
using Microsoft.AspNetCore.Mvc;

namespace MB.EndPoint.API.Controllers;

[ApiController]
[Route("api/Article")]
public class ArticleController : ControllerBase
{
    private readonly IArticleApplication _articleApplication;

    public ArticleController(IArticleApplication articleApplication) => _articleApplication = articleApplication;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _articleApplication.GetList());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBy(ulong id)
    {
        var res = await _articleApplication.GetBy(id);
        return res != null ? Ok(res) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateArticleCommand command)
    {
        if (ModelState.IsValid)
        {
            var res = await _articleApplication.Create(command);
            return res.IsSucceeded ? CreatedAtAction(nameof(GetBy), new { id = res.Object }, command) : BadRequest(res.Message);
        }

        return BadRequest(ModelState);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromForm] EditArticleCommand command)
    {
        if (ModelState.IsValid)
        {
            var res = await _articleApplication.Edit(command);
            return res.IsSucceeded ? Ok(res.Object) : BadRequest(res.Message);
        }
        return BadRequest(ModelState);
    }
}