using System;
using MyLearn.Data.Base;
using MyLearn.Models;
using Newtonsoft.Json;

namespace MyLearn.Dtos
{
    [JsonObject]
    public class TermDto : JsonObject<Term>
    {
        [JsonProperty]
        public string Code
        {
            get;
            set;
        }

        [JsonProperty]
        public string Title
        {
            get;
            set;
        }

        public override Term ToDomainModel()
        {
			var term = new Term
			{
				Code = this.Code,
                Description = this.Title
			};

            return term;
        }
    }
}
