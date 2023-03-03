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
            var process = await _articleApplication.Create(command);

            //var res = new Dictionary<string, object>();
            //res.Add("Message", process.Message);
            //res.Add("Article", process.Object);

            return process.IsSucceeded ? Ok(process.Message) : BadRequest(process.Message);
        }

        return BadRequest(ModelState);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromRoute] EditArticleCommand command)
    {
        if (ModelState.IsValid)
        {
            var process = await _articleApplication.Edit(command);

            var res = new Dictionary<string, object>();
            res.Add("Message", process.Message);
            res.Add("Article", process.Object);

            return process.IsSucceeded ? Ok(res) : BadRequest(process.Message);
        }
        return BadRequest(ModelState);
    }
}

