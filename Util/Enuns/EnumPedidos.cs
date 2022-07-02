using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Util.Enuns
{
    public enum EnumStatusPedido
    {
        Aberto = 0,
        Producao = 1,
        Cancelado = 2,
        Finalizado = 3,
        Entregue = 4
    }

    public enum EnumFormaPagamento
    {
        VisaDebito = 0,
        VisaCredito = 1,
        MasterDebito = 2,
        MasterCredito = 3,
        Boleto = 4,
    }

    public enum EnumStatusEntrega
    {
        Produzindo = 0,
        AguardandoRetirada = 1,
        Concluido = 2
    }

    public enum EnumTipoPessoa
    {
        PF = 0,
        PJ = 1,
    }
}
