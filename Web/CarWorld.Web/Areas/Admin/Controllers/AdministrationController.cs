namespace CarWorld.Web.Areas.Administration.Controllers
{
    using CarWorld.Common;
    using CarWorld.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Admin")]
    public class AdministrationController : BaseController
    {
    }
}
