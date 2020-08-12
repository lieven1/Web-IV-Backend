using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Models;

namespace Web4Api.Data
{
    public class GebruikerFilter : ActionFilterAttribute
    {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerFilter(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }
        /*Omzetten van de Entity framework gebruiker naar onze zelf ontworpen gebruiker.*/
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["gebruiker"] = context.HttpContext.User.Identity.IsAuthenticated ? _gebruikerRepository.GetBy(context.HttpContext.User.Identity.Name) : null;
            base.OnActionExecuting(context);
        }
    }
}
