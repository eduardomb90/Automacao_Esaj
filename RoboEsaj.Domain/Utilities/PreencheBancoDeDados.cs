﻿using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using RoboEsaj.Database.Models;
using System.Data;

namespace RoboEsaj.Domain.Utilities
{
    public class PreencheBancoDeDados
    {
        public DecisaoModel Decisao { get; set; }
        private string _conteudo;

        public PreencheBancoDeDados()
        {
            Decisao = new DecisaoModel();
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

            if (_conteudo.IndexOf("procedente", StringComparison.OrdinalIgnoreCase) >= 0 &&
                _conteudo.IndexOf("improcedente", StringComparison.OrdinalIgnoreCase) == -1 &&
                _conteudo.IndexOf("parcialmente procedente", StringComparison.OrdinalIgnoreCase) == -1)
            {
                Decisao.Resultado = "Procedente";
            }
            else if (_conteudo.IndexOf("julgo procedente", StringComparison.OrdinalIgnoreCase) >= 0 &&
                     _conteudo.IndexOf("julgo improcedente", StringComparison.OrdinalIgnoreCase) == -1)
            {
                Decisao.Resultado = "Procedente";
            }
            else if(_conteudo.IndexOf("parcialmente procedente", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Decisao.Resultado = "Parcialmente Procedente";
            }
            else if (_conteudo.IndexOf("julgo procedente", StringComparison.OrdinalIgnoreCase) >= 0 &&
                     _conteudo.IndexOf("julgo improcedente", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Decisao.Resultado = "Parcialmente Procedente";
            }
            else if (_conteudo.IndexOf("improcedente", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     _conteudo.IndexOf("nega provimento", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     _conteudo.IndexOf("nego provimento", StringComparison.OrdinalIgnoreCase) >= 0 &&
                     _conteudo.IndexOf("julgo procedente", StringComparison.OrdinalIgnoreCase) == -1)
            {
                Decisao.Resultado = "Improcedente";
            }
            else if (_conteudo.IndexOf("julgo extinto", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Decisao.Resultado = "Extinto";
            }
            else if (_conteudo.IndexOf("conciliação", StringComparison.OrdinalIgnoreCase) >= 0 &&
                     _conteudo.IndexOf("homologo", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Decisao.Resultado = "Homologação de Conciliação";
            }
            else if (_conteudo.IndexOf("concedido", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     _conteudo.IndexOf("concedida", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     _conteudo.IndexOf("concedo", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     _conteudo.IndexOf("defiro", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Decisao.Resultado = "Possivelmente Procedente";
            }
            else
            {
                Decisao.Resultado = "Indefinido";
            }

            try
            {
                SqliteDataAccess.SaveDecisaoWithoutOpeningDb(Decisao, conn);
            }
            catch (Exception)
            {
                
            }
        }
    }
}