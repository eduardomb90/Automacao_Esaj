using OpenQA.Selenium;
using RoboEsaj.Database.Models;
using System.Collections.ObjectModel;
using System.Data;

namespace RoboEsaj.Domain.Utilities
{
    public interface IFillDataClass
    {
        DecisaoModel Decisao { get; set; }

        void AddToDb(ReadOnlyCollection<IWebElement> row, IDbConnection conn);
    }
}