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

    public class CAD_APARTAMENTO : IEntidadeBase
    {
        [Key]
        [Column("COD_CADAPARTAMENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public int TORRE { get; set; }
        public int? GARAGEM { get; set; }
        public string CEMP { get; set; }
        [NotMapped]
        public int CODIGO { get; set; }

        public int? COD_CADPESSOA { get; set; }

        [NotMapped]
        public string DOCUMENTO_PESSOA { get; set; }
        [NotMapped]
        public string NOME_PESSOA { get; set; }

    }
}
