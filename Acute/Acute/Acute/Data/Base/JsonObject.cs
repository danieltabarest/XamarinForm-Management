using System;
namespace Acute.Data.Base
{
    public abstract class JsonObject<DomainModel>
    {
        public abstract DomainModel ToDomainModel();
    }
}
