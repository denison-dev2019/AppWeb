using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Cadastro.ViewModel
{
    public class PromocaoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Promoção"), MaxLength(200, ErrorMessage = "Descrição deve ter no máximo 200 caracteres.")]
        public string Descricao { get; set; }

    }
}
