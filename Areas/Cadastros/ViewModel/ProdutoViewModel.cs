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
        [DisplayName("Nome"),MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [DisplayName("Preço"), DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Preco { get; set; }
        public int PromocaoID { get; set; }
    }
    public class ProdutoGetViewModel : ProdutoBaseViewModel
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public PromocaoViewModel Promocao { get; set; }
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
