using System;
using System.Collections.Generic;
using System.Text;

namespace TouchOnline.Data.Services
{
    public class TextoFormatacao
    {
        public static string CriarExercicioComParagrafo(string texto, int numLimite)
        {
            var textoFinal = RedimensionarTexto(texto);
            var txtFinal = textoFinal;
            var txtParcial = string.Empty;
            var tamanho = 0;
            var rr = buscarTamanhoPg(textoFinal, numLimite);
            KeyValuePair<int, string> ss;
            tamanho = rr.Key;
            txtParcial = rr.Value;
            while (true)
            {
                try
                {
                    txtFinal = txtFinal[tamanho - 1] == ' '
                        ? txtFinal.Remove(tamanho - 1, 1).Insert(tamanho - 1, "¶") : txtFinal;

                    ss = buscarTamanhoPg(txtParcial, numLimite);
                    tamanho = tamanho + ss.Key;
                    txtParcial = ss.Value;

                    buscarTamanhoPg(txtParcial, numLimite);
                }
                catch (Exception)
                {
                    break;
                }
            }
            try
            {
                txtFinal = txtFinal.Remove(tamanho - 1, 1).Insert(tamanho - 1, "¶");
            }
            catch (Exception)
            {
                return txtFinal;
            }


            string textoPossivelEspaco;
            string final;

            if (txtFinal[txtFinal.Length - 1] == '¶')
            {
                textoPossivelEspaco = txtFinal.Remove(txtFinal.Length - 1);
            }
            else
            {
                textoPossivelEspaco = txtFinal;
            }
            if (textoPossivelEspaco[textoPossivelEspaco.Length - 1] == ' ')
            {
                final = textoPossivelEspaco.Remove(textoPossivelEspaco.Length - 1);
            }
            else
            {
                final = textoPossivelEspaco;
            }

            return final;
        }

        private static string RedimensionarTexto(string texto)
        {
            while (true)
            {
                if (texto.Length < 167)
                {
                    texto = texto + " " + texto;
                }
                else
                {
                    break;
                }
            }
            return texto;
        }

        private static KeyValuePair<int, string> buscarTamanhoPg(string texto, int numLimite)
        {
            if (texto.Length <= numLimite)
            {
                return new KeyValuePair<int, string>(texto.Length, texto);
            }
            try
            {
                var aa = BuscarIndiceDeCorteFrase(texto, numLimite);
                var bbTx = texto.Substring(aa + 1, texto.Length - aa - 1);
                var cc = BuscarIndiceDeCorteFrase(bbTx, numLimite);
                var ddTx = bbTx.Substring(cc + 1, bbTx.Length - cc - 1);
                var ee = BuscarIndiceDeCorteFrase(ddTx, numLimite);
                var finalTx = ddTx.Substring(ee + 1, ddTx.Length - ee - 1);
                return new KeyValuePair<int, string>(texto.Length - finalTx.Length, finalTx);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int BuscarIndiceDeCorteFrase(string texto, int indice)
        {
            var txt = string.Empty;
            while (texto.Length > indice)
            {
                try
                {
                    txt = texto.Substring(indice, 1);
                }
                catch (Exception)
                {
                    // throw;
                }

                if (txt == " ")
                    break;
                else
                    indice = indice - 1;
            }
            return indice;
        }
    }
}
