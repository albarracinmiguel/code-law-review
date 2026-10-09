using Shared.Billing;
using Shared.Data;

namespace Billing;

public class InvoiceService : IInvoiceService
{
    private readonly BillingDbContext _db;
    private readonly ITenantContext _tenant;
    private readonly decimal _taxRate;

    public InvoiceService(BillingDbContext db, ITenantContext tenant, BillingOptions options)
    {
        _db = db;
        _tenant = tenant;
        _taxRate = options.TaxRate;
    }

    public async Task<decimal> GetReservationTotalAsync(int reservationId)
    {
        var lines = await _db.InvoiceLines.NotDeleted().ForTenant(_tenant.TenantId)
            .Where(l => l.ReservationId == reservationId).ToListAsync();

        var addons = await _db.Addons.ForTenant(_tenant.TenantId)
            .Where(a => a.ReservationId == reservationId).ToListAsync();

        var subtotal = lines.Sum(l => l.Amount) + addons.Sum(a => a.Price);
        var tax = Math.Round(subtotal * _taxRate, 2);

        return subtotal + tax;
    }
}
