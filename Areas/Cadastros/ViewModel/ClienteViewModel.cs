using AppWeb.Util.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Cadastros.ViewModel
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Tel. Fixo")]
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        [DisplayName("Nº")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        [DisplayName("Tipo")]
        public EnumTipoPessoa TipoPessoa { get; set; }
    }
}
