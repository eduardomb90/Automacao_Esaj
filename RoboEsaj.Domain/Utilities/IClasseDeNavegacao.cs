using System.Collections.Generic;

namespace RoboEsaj.Domain.Utilities
{
    public interface IClasseDeNavegacao
    {
        void Scrape(IList<string> dadosPesquisa);
    }
}