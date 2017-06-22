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
    using Models.MOV;

    public class cad_pessoaController : CrudControllerBase<CAD_PESSOA>
    {
        protected override IOrderedQueryable<CAD_PESSOA> Ordenar(IQueryable<CAD_PESSOA> query)
        {
            return query.OrderBy(e => e.id);
        }

        [Route("api/cad_pessoa/documento/{doc}")]
        [HttpGet]
        public IHttpActionResult Documento(string doc)
        {
            CAD_PESSOA item = db.CAD_PESSOA.Where(w => w.DOCUMENTO == doc).FirstOrDefault();

            //if (item == null)
            //{
            //    return NotFound();
            //}

            return Ok(item);
        }

        [Route("api/cad_pessoa/placa/{placa}")]
        [HttpGet]
        public IHttpActionResult Placa(string placa)
        {
            MOV_ENTRADA mov = new MOV_ENTRADA();
            CAD_VEICULO item = null;

            if (placa.Length > 7)
            {
                CAD_PESSOA pessoadoc = db.CAD_PESSOA.Where(w => w.DOCUMENTO == placa).FirstOrDefault();

                if (pessoadoc != null)
                  item = db.CAD_VEICULO.Where(w => w.COD_CADPESSOA == pessoadoc.id).FirstOrDefault();
            }
            else
            {
                item = db.CAD_VEICULO.Where(w => w.PLACA == placa.ToUpper()).FirstOrDefault();
            }

            if (item != null)
                mov.COD_CADVEICULO = item.id;

            if (item != null && item.COD_CADPESSOA > 0)
            {
                CAD_PESSOA pessoa = db.CAD_PESSOA.Where(w => w.id == item.COD_CADPESSOA).FirstOrDefault();
                mov.COD_CADPESSOA = pessoa.id;
                mov.NOME_PESSOA = pessoa.NOME;
                mov.DOCUMENTO_PESSOA = pessoa.DOCUMENTO;
                mov.PLACA = item.PLACA;

                CAD_APARTAMENTO ap = db.CAD_APARTAMENTO.Where(w => w.COD_CADPESSOA == item.COD_CADPESSOA).FirstOrDefault();

                if (ap != null)
                {
                    mov.NOME_PESSOA_AP = pessoa.NOME;
                    mov.DOCUMENTO_PESSOA_AP = pessoa.DOCUMENTO;
                    mov.TORRE = ap.TORRE;
                    mov.GARAGEM = ap.GARAGEM;
                    mov.COD_CADAPARTAMENTO = ap.id;
                }
            }

            return Ok(mov);
        }

    }

}
