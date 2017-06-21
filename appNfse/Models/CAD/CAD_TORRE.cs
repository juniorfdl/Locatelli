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

    public class CAD_TORRE : IEntidadeBase
    {
        [Key]
        [Column("COD_CADTORRE")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [NotMapped]
        public string CEMP { get; set; }
    }
}
