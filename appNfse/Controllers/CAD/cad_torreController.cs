namespace Controllers.CAD
{
    using Infra.Base.Interface.Base;
    using Models.Cadastros;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class cad_torreController : CrudControllerBase<CAD_TORRE>
    {
        protected override IOrderedQueryable<CAD_TORRE> Ordenar(IQueryable<CAD_TORRE> query)
        {
            return query.OrderBy(e => e.id);
        }
       
    }    
    
}
