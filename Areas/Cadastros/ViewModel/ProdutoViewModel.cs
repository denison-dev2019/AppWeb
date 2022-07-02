using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Cadastro.ViewModel
{
    public class ProdutoBaseViewModel
    {
        [DisplayName("Descrição"),MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [DisplayName("Preço Custo"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Preco { get; set; }
        [DisplayName("Margem %"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal PercentualVenda { get; set; }
        public int PromocaoID { get; set; }
        [DisplayName("Preço Venda"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal PrecoFinal { get; set; }
        public int FornecedorId { get; set; }
    }
    public class ProdutoGetViewModel : ProdutoBaseViewModel
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public PromocaoViewModel? Promocao { get; set; }
    }

    public class ProdutoViewModel : ProdutoBaseViewModel
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        [DisplayName("Promoção")]
        public int PromocaoID { get; set; }
    }

    public class ProdutoPostViewModel : ProdutoBaseViewModel
    {
        [DisplayName("Promoção")]
        public int PromocaoID { get; set; }
    }


    public class ProdutoGetFiltroViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
