using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umfgcloud.loja.dominio.service.Entidades;

namespace umfgcloud.loja.dominio.service.Interfaces.Builders
{
    public interface IProdutoBuilder
    {
        IProdutoBuilder SetDescricao(string descricao);
        IProdutoBuilder SetEAN(string ean);
        IProdutoBuilder SetValorCompra(decimal valorCompra);
        IProdutoBuilder SetValorVenda(decimal valorVenda);

        ProdutoEntity Build();
    }
}
