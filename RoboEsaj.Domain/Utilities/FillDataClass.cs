using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using RoboEsaj.Database.Models;
using System.Data;
using System.Text.RegularExpressions;

namespace RoboEsaj.Domain.Utilities
{
    public class FillDataClass : IFillDataClass
    {
        public DecisaoModel Decisao { get; set; }
        private string _conteudo;

        public FillDataClass(DecisaoModel decisao)
        {
            Decisao = decisao;
        }

        public void AddToDb(ReadOnlyCollection<IWebElement> row, IDbConnection conn)
        {
            var i = 1;

            Decisao.Processo = row[i].Text;
            i++;

            if (row[i].Text.Contains("Classe"))
            {
                Decisao.Classe = row[i].Text.Replace("Classe: ", "");
                i++;
            }

            if (row[i].Text.Contains("Assunto"))
            {
                Decisao.Assunto = row[i].Text.Replace("Assunto: ", "");
                i++;
            }

            if (row[i].Text.Contains("Magistrado"))
            {
                Decisao.Magistrado = row[i].Text.Replace("Magistrado: ", "");
                i++;
            }

            if (row[i].Text.Contains("Comarca"))
            {
                Decisao.Comarca = row[i].Text.Replace("Comarca: ", "");
                i++;
            }

            if (row[i].Text.Contains("Foro"))
            {
                Decisao.Foro = row[i].Text.Replace("Foro: ", "");
                i++;
            }

            if (row[i].Text.Contains("Vara"))
            {
                Decisao.Vara = row[i].Text.Replace("Vara: ", "");
                i++;
            }

            if (row[i].Text.Contains("Data de Disponibilização"))
            {
                Decisao.Data = row[i].Text.Replace("Data de Disponibilização: ", "");
                i++;
            }

            
            _conteudo = row[i].Text;

            if (    Regex.IsMatch(_conteudo, @"\b(?im)(procedente|provimento|provido|acolho o pedido|concedo|
                                                    concedido|concedida|julgo procedente)")
                &&
                    !Regex.IsMatch(_conteudo, @"\b(?im)(improcedente|parcialmente procedente|indefiro|improvido|
                                                        nego provimento|nega provimento|não concedo|não concedida|
                                                        não concedido|julgo improcedente)"))
            {

                Decisao.Resultado = "Favorável";
            }
            else if (   Regex.IsMatch(_conteudo, @"\b(?im)(procedente|provimento|provido|acolho o pedido|concedo|
                                                        concedido|concedida|julgo procedente)")
                    &&
                        Regex.IsMatch(_conteudo, @"\b(?im)(improcedente|parcialmente procedente|indefiro|improvido|
                                                            nego provimento|nega provimento|não concedo|não concedida|
                                                            não concedido|julgo improcedente)"))
            {

                if (Regex.IsMatch(_conteudo, @"\b(?im)(julgo procedente)") &&
                    !Regex.IsMatch(_conteudo, @"\b(?im)(julgo improcedente)"))
                {

                    Decisao.Resultado = "Favorável";
                }
                else if (Regex.IsMatch(_conteudo, @"\b(?im)(julgo improcedente)") &&
                        !Regex.IsMatch(_conteudo, @"\b(?im)(julgo procedente)"))
                {

                    Decisao.Resultado = "Desfavorável";
                }
                else
                {

                    Decisao.Resultado = "Favorável (precisa ser consultado)";
                }

            }
            else if (   Regex.IsMatch(_conteudo, @"\b(?im)(improcedente|parcialmente procedente|indefiro|improvido|
                                                        nego provimento|nega provimento|não concedo|não concedida|
                                                        não concedido|julgo improcedente)")
                    &&
                        !Regex.IsMatch(_conteudo, @"\b(?im)(procedente|provimento|acolho o pedido|concedo|
                                                            concedido|julgo procedente)"))
            {

                Decisao.Resultado = "Desfavorável";
            }
            else if (Regex.IsMatch(_conteudo, @"\b(?im)(conciliação|acordo)") &&
                      Regex.IsMatch(_conteudo, @"\b(?im)(homologo|julgo extinto|declaro extinto)"))
            {

                Decisao.Resultado = "Homologação de Conciliação";
            }
            else if (Regex.IsMatch(_conteudo, @"\b(?im)(julgo extinto|julgo extinta|declaro extinto|declaro extinta)"))
            {

                Decisao.Resultado = "Extinto";
            }
            else
            {

                Decisao.Resultado = "Indefinido";
            }

            try
            {
                if(Decisao.Resultado != "Extinto" && Decisao.Resultado != "Indefinido")
                    SqliteDataAccess.SaveDecisaoWithoutOpeningDb(Decisao, conn);
            }
            catch (Exception)
            {

            }
        }
    }
}
