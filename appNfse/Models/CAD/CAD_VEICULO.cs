namespace Models.Cadastros
{
    using Infra.Base.Interface;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CAD_VEICULO : IEntidadeBase
    {
        [Key]
        [Column("COD_CADVEICULO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public string PLACA { get; set; }
        //[Required]
        //public int COD_CADAPARTAMENTO { get; set; }
        public string DESCRICAO { get; set; }
        public string VISITANTE { get; set; }
        public string CEMP { get; set; }

        public int? COD_CADPESSOA { get; set; }

        [NotMapped]
        public string DOCUMENTO_PESSOA { get; set; }
        [NotMapped]
        public string NOME_PESSOA { get; set; }
    }
}

