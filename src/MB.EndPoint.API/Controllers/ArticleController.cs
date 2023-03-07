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
        try
        {
            if (ModelState.IsValid)
            {
                var res = await _articleApplication.Create(command);
                return res.IsSucceeded ? CreatedAtAction(nameof(GetBy), new { id = res.Object }, command) : BadRequest(res.Message);
            }

            return BadRequest(ModelState);
        }

        catch (Exception ex) { return BadRequest(); }
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromForm] EditArticleCommand command)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var res = await _articleApplication.Edit(command);
                return res.IsSucceeded ? Ok(res.Object) : BadRequest(res.Message);
            }

            return BadRequest(ModelState);
        }

        catch { return BadRequest(); }
    }

    [HttpPut("active/{id}")]
    public async Task<IActionResult> Active(ulong id)
    {
        try
        {
            var res = await _articleApplication.Active(id);
            return res.IsSucceeded ? Ok(res.Object) : BadRequest(res.Message);
        }

        catch { return BadRequest(); }
    }

    [HttpPut("deActive/{id}")]
    public async Task<IActionResult> Deactive(ulong id)
    {
        try
        {
            var res = await _articleApplication.DeActive(id);
            return res.IsSucceeded ? Ok(res.Object) : BadRequest(res.Message);
        }

        catch { return BadRequest(); }
    }

}