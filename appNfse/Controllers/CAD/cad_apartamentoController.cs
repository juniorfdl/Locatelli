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

    public class cad_apartamentoController : CrudControllerBase<CAD_APARTAMENTO>
    {
        protected override IOrderedQueryable<CAD_APARTAMENTO> Ordenar(IQueryable<CAD_APARTAMENTO> query)
        {
            return query.OrderBy(e => e.id);
        }

        protected override void BeforeReturn(CAD_APARTAMENTO item)
        {
            item.CODIGO = item.id;

            if (item.COD_CADPESSOA > 0)
            {
                var pessoa = db.CAD_PESSOA.Where(w => w.id == item.COD_CADPESSOA).FirstOrDefault();

                if (pessoa != null)
                {
                    item.DOCUMENTO_PESSOA = pessoa.DOCUMENTO;
                    item.NOME_PESSOA = pessoa.NOME;
                }
            }

        }

        protected override IHttpActionResult ExecutarAntesPost(CAD_APARTAMENTO item)
        {
            item.id = item.CODIGO;
            return null;
        }        

    }    
    
}
