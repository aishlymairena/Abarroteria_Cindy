using Abarroteria_Cindy.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Abarroteria_Cindy.Filters
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string Nombre) : base(typeof(ClaimRequirementFiltrer))
        {
            Arguments = new object[] { new ModuloVm { Nombre = Nombre } };
        }
    }

    public class ClaimRequirementFiltrer : IAuthorizationFilter
    {
        private EmpleadoVm UsuarioObjeto;
        readonly ModuloVm _claim;

        public ClaimRequirementFiltrer(ModuloVm claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            try
            {
                string sesionBase64 = filterContext.HttpContext.Session.GetString("UsuarioObjeto");
                if (string.IsNullOrEmpty(sesionBase64))
                {
                    filterContext.Result = new RedirectResult("~/Usuario/Index?Codigo=1");
                    return;
                }
                var base64EncodedBytes = System.Convert.FromBase64String(sesionBase64);
                var sesión = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                UsuarioObjeto = JsonConvert.DeserializeObject<EmpleadoVm>(sesión);
                if (UsuarioObjeto == null)
                {
                    filterContext.Result = new RedirectResult("~/Usuario/Index?Codigo=1");
                    return;
                }
                var encontro = false;
                foreach (var item in UsuarioObjeto.Menu)
                {

                    var modusloact = item.Modulos.FirstOrDefault(w => w.Nombre == _claim.Nombre);
                    encontro = modusloact != null;
                    if (encontro)
                    {
                        break;
                    }
                }
                if (!encontro && _claim.Nombre.ToLower() != "principal")
                {

                    filterContext.Result = new RedirectResult("~/Home/Index?Codigo=1");
                    return;
                }
            }


            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Index?Codigo=1");
            }
        }
    }
}
