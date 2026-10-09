using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Data;

namespace Api;

[ApiController]
[Authorize(Policy = "TenantUser")]
[Route("reservations")]
public class AddonsController : ControllerBase
{
    private readonly BillingDbContext _db;

    public AddonsController(BillingDbContext db) => _db = db;

    [HttpGet("{reservationId}/addons/total")]
    public async Task<decimal> GetAddonsTotal(int reservationId, [FromQuery] int tenantId)
    {
        var addons = await _db.Addons.NotDeleted().ForTenant(tenantId)
            .Where(a => a.ReservationId == reservationId).ToListAsync();

        return addons.Sum(a => a.Price);
    }
}
