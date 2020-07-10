namespace CarRentalSystem.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarRentalSystem.Infrastructure;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Refit;

    [AuthorizeAdministrator]
    public abstract class AdministrationController : Controller
    {
        protected async Task<ActionResult> Handle(Func<Task> action, ActionResult success, ActionResult failure)
        {
            try
            { 
                await action();
                return success;
            }
            catch (ApiException exception)
            {
                this.ProcessErrors(exception);
                return failure;
            }
        }

        private void ProcessErrors(ApiException exception)
        {
            if (exception.HasContent)
            {
                JsonConvert
                    .DeserializeObject<List<string>>(exception.Content)
                    .ForEach(error => this.ModelState.AddModelError(string.Empty, error));
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Internal server error.");
            }
        }
    }
}
