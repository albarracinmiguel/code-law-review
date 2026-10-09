using Shared.Data;

namespace Billing;

public class AddonQueries
{
    private readonly BillingDbContext _db;
    private readonly ITenantContext _tenant;

    public AddonQueries(BillingDbContext db, ITenantContext tenant)
    {
        _db = db;
        _tenant = tenant;
    }

    // Used by the add-on list on screen. This one is correct.
    public Task<List<Addon>> ListForReservationAsync(int reservationId) =>
        _db.Addons.NotDeleted().ForTenant(_tenant.TenantId)
            .Where(a => a.ReservationId == reservationId)
            .ToListAsync();
}
