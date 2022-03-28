using Cs_SuperMarketWebApp.Models;

namespace Cs_SuperMarketWebApp.Services
{
    public interface IBill
    {

        bool GenerateBill(BillMaster bill, BillDetail[] details);
    }
}
