namespace Controllers.MOV
{
    using Infra.Base.Interface.Base;
    using Models.MOV;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class mov_entradaController : CrudControllerBase<MOV_ENTRADA>
    {
        protected override IOrderedQueryable<MOV_ENTRADA> Ordenar(IQueryable<MOV_ENTRADA> query)
        {
            return query.OrderBy(e => e.id);
        }

        protected override void BeforeReturn(MOV_ENTRADA item)
        {
            var ap = db.CAD_APARTAMENTO.Where(w => w.id == item.COD_CADAPARTAMENTO).FirstOrDefault();
            item.TORRE = ap.TORRE;
            item.GARAGEM = ap.GARAGEM;

            if (item.COD_CADPESSOA > 0)
            {
                var pessoa = db.CAD_PESSOA.Where(w => w.id == item.COD_CADPESSOA).FirstOrDefault();

                if (pessoa != null)
                {
                    item.DOCUMENTO_PESSOA_AP = pessoa.DOCUMENTO;
                    item.NOME_PESSOA_AP = pessoa.NOME;
                }
            }

            if (item.COD_CADVEICULO > 0)
            {
                var veiculo = db.CAD_VEICULO.Where(w => w.id == item.COD_CADVEICULO).FirstOrDefault();

                if (veiculo != null)
                {
                    item.PLACA = veiculo.PLACA;

                    if (veiculo.COD_CADPESSOA == item.COD_CADPESSOA)
                    {
                        item.DOCUMENTO_PESSOA = item.DOCUMENTO_PESSOA_AP;
                        item.NOME_PESSOA = item.NOME_PESSOA_AP;
                    }
                    else
                    {
                        var pessoaveiculo = db.CAD_PESSOA.Where(w => w.id == veiculo.COD_CADPESSOA).FirstOrDefault();

                        if (pessoaveiculo != null)
                        {
                            item.DOCUMENTO_PESSOA = pessoaveiculo.DOCUMENTO;
                            item.NOME_PESSOA = pessoaveiculo.NOME;
                        }
                    }
                }
            }

            if (item.CODIGOSISUSUARIO > 0)
            {
                var usr = db.SIS_USUARIO.Where(w => w.id == item.CODIGOSISUSUARIO).FirstOrDefault();

                if (usr != null)
                {
                    item.PLACA = usr.NOME;
                }
            }
        }

    }

}
