using MB.Application.Contract.CommentAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MB.EndPoint.API.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{

    private readonly IMemoryCache _memoryCache;
    private readonly ICommentApplication _commentApplication;

    public CommentController(IMemoryCache memoryCache, ICommentApplication commentApplication)
    {
        _memoryCache = memoryCache;
        _commentApplication = commentApplication;
    }

    [HttpGet("{articleId}")]
    public async Task<IActionResult> GetAll(ulong articleId)
    {
        var result = await _memoryCache.GetOrCreateAsync((string)($"comments{articleId}"), entry =>
        {
            entry.AbsoluteExpiration = DateTime.Now.AddHours(10);
            return _commentApplication.GetListBy(articleId);
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateCommentCommand command)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var res = await _commentApplication.Create(command);
                _memoryCache.Remove((string)($"comments{res.Object}"));
                return res.IsSucceeded ? CreatedAtAction(nameof(GetAll), new { articleId = res.Object }, command) : BadRequest(res.Message);
            }

            return BadRequest(ModelState);
        }
        catch (Exception ex) { return BadRequest(); }
    }
}