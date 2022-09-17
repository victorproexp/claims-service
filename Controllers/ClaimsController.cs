using Microsoft.AspNetCore.Mvc;

namespace claimsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClaimsController : ControllerBase
{
    private static List<Claim> _claims = new List<Claim>();

    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(ILogger<ClaimsController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("{id}")]
    public Claim GetClaim(int id)
    {
        _logger.LogInformation("GetClaim called at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        return _claims.Where(c => c.ClaimId == id).First();
    }

    [HttpGet()]
    public List<Claim> GetClaims()
    {
        _logger.LogInformation("GetClaims called at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        return _claims;
    }

    [HttpPost()]
    public Claim PostClaim(Claim claim)
    {
        _logger.LogInformation("PostClaim called at {DT}",
            DateTime.UtcNow.ToLongTimeString());

        try
        {
            _claims.Add(claim);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return claim;
    }
}
