using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autoglassback.Models
{
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = "";
        public string Situacao { get; set; } = "";
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string? DescricaoFornecedor { get; set; }
        public int CNPJFornecedor { get; set; }
    }
}
