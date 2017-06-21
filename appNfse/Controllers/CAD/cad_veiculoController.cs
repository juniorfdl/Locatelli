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

    public class cad_veiculoController : CrudControllerBase<CAD_VEICULO>
    {
        protected override IOrderedQueryable<CAD_VEICULO> Ordenar(IQueryable<CAD_VEICULO> query)
        {
            return query.OrderBy(e => e.id);
        }

        protected override void BeforeReturn(CAD_VEICULO item)
        {
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

    }    
    
}
