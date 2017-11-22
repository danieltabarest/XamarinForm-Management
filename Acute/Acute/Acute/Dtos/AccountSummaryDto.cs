using System;
namespace MyLearn.Dtos
{
    public class AccountSummaryDto : Data.Base.JsonObject<string>
    {
        public string TotalBalance
        {
            get;
            set;
        }

        public override string ToDomainModel()
        {
            return TotalBalance;
        }
    }
}
