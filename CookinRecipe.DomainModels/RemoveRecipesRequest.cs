using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookinRecipe.DomainModels
{
    public class RemoveRecipesRequest
    {
        public long ListId { get; set; }
        public List<long> RecipeIds { get; set; }
    }
}
