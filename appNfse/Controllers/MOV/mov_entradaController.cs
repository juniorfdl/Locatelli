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
    using Models.Cadastros;
    using Infra.Base;

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

        protected override IHttpActionResult ExecutarAntesPost(MOV_ENTRADA item)
        {
            CAD_PESSOA pessoa = null;
            var fb = new FuncoesBanco(db);
            if (item.COD_CADPESSOA == null)
            {
                pessoa = new CAD_PESSOA();                
                pessoa.id = fb.BuscarPKRegistro(pessoa.GetType().Name);
                item.COD_CADPESSOA = pessoa.id;
                pessoa.ATIVO = "S";
                pessoa.CEMP = "01";
                pessoa.DOCUMENTO = item.DOCUMENTO_PESSOA;
                pessoa.NOME = item.NOME_PESSOA;
                pessoa.TIPO = "1";

                //if (item.NOME_PESSOA_AP != null)
                //{
                //    pessoa.TIPO = "1";
                //}
                //else
                //    if (item.NOME_PESSOA_AP != item.NOME_PESSOA)
                //{
                //    pessoa.TIPO = "2";
                //}
            }            

            CAD_VEICULO veiculo = null;

            if (item.COD_CADVEICULO == null)
            {
                veiculo = new CAD_VEICULO();
                veiculo.id = fb.BuscarPKRegistro(veiculo.GetType().Name);
                veiculo.PLACA = item.PLACA.ToUpper();                
                veiculo.COD_CADPESSOA = item.COD_CADPESSOA;
                item.COD_CADVEICULO = veiculo.id;
                veiculo.CEMP = "01";
                //if (pessoa == null)
                //{
                //    veiculo.VISITANTE = "S";
                //}
            }

            bool fezInsert = false;

            if (pessoa != null)
            {
                db.CAD_PESSOA.Add(pessoa);
                fezInsert = true;
            }            

            if (veiculo != null)
            {
                db.CAD_VEICULO.Add(veiculo);
                fezInsert = true;
            }

            if (fezInsert == true)
              db.SaveChanges();

            var ap = db.CAD_APARTAMENTO.Where(w => w.id == item.COD_CADAPARTAMENTO).FirstOrDefault();

            if (ap == null)
            {
                ap = new CAD_APARTAMENTO();
                ap.id = item.COD_CADAPARTAMENTO;
                ap.GARAGEM = item.GARAGEM;
                ap.TORRE = item.TORRE;
                ap.COD_CADPESSOA = item.COD_CADPESSOA;
                ap.CEMP = "01";
                db.CAD_APARTAMENTO.Add(ap);                
                db.SaveChanges();
            }

            if (pessoa != null)
            {
                pessoa.COD_CADAPARTAMENTO = item.COD_CADAPARTAMENTO;
                db.Entry(pessoa).State = EntityState.Modified;
            }

            if (ap != null)
            {
                ap.COD_CADPESSOA = item.COD_CADPESSOA;
                db.Entry(ap).State = EntityState.Modified;
            }

            if (veiculo != null)
            {
                veiculo.COD_CADPESSOA = item.COD_CADPESSOA;
                db.Entry(veiculo).State = EntityState.Modified;
            }

            if (fezInsert == true)
                db.SaveChanges();

            return null;
        }

    }

}
