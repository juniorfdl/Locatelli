namespace Models.MOV
{
    using Infra.Base.Interface;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MOV_ENTRADA : IEntidadeBase
    {
        [Key]
        [Column("COD_MOVENTRADA")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [NotMapped]
        public DateTime DATA_HORA { get; set; }
        public int? COD_CADPESSOA { get; set; }
        public int? COD_CADVEICULO { get; set; }
        public int CODIGOSISUSUARIO { get; set; }               

        [NotMapped]
        public string CEMP { get; set; }        
        [NotMapped]
        public string DOCUMENTO_PESSOA { get; set; }
        [NotMapped]
        public string DOCUMENTO_PESSOA_AP { get; set; }
        [NotMapped]
        public string NOME_PESSOA { get; set; }
        [NotMapped]
        public string NOME_PESSOA_AP { get; set; }
        [NotMapped]
        public string PLACA { get; set; }
        [NotMapped]
        public string USUARIO { get; set; }

        public int COD_CADAPARTAMENTO { get; set; }
        [NotMapped]
        public int TORRE { get; set; }
        [NotMapped]
        public int? GARAGEM { get; set; }
    }
}
