using System.Collections.Generic;

namespace RoboEsaj.Domain.Utilities
{
    public interface IScrapClass
    {
        void Scrape(IList<string> dadosPesquisa, bool linkCheck);
    }
}