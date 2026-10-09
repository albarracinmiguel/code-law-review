using Billing;
using Xunit;

namespace Billing.Tests;

public class InvoiceServiceTests : BillingTestBase
{
    [Fact]
    public async Task Test1()
    {
        // Two lines of 50.00, one add-on of 20.00 that was deleted, tax 0%.
        SeedLine(reservationId: 1, amount: 50.00m);
        SeedLine(reservationId: 1, amount: 50.00m);
        SeedAddon(reservationId: 1, price: 20.00m, deleted: true);
        var sut = CreateService(taxRate: 0m);

        var actual = await sut.GetReservationTotalAsync(1);

        var expected = await CreateService(taxRate: 0m).GetReservationTotalAsync(1);
        Assert.Equal(expected, actual);
    }
}
