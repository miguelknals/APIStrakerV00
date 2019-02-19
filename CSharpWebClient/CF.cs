using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laika // _04_test_ConexionPostgres
{
    public static class CF // al ser estática no hace falta crear instancia
    {
        public static string TrataNull (object kk)
        {
            string s = "";
            if (kk == DBNull.Value)
            {
                kk = "";
            } else 
            {
                s = kk.ToString();
                if (s == "N/A") { s = ""; }
            }
            return s;
            
        
        }

        public static string FormatOutput2Text(string jsonString)
        {
            var stringBuilder = new StringBuilder();

            bool escaping = false;
            bool inQuotes = false;
            int indentation = 0;

            foreach (char character in jsonString)
            {
                if (escaping)
                {
                    escaping = false;
                    stringBuilder.Append(character);
                }
                else
                {
                    if (character == '\\')
                    {
                        escaping = true;
                        stringBuilder.Append(character);
                    }
                    else if (character == '\"')
                    {
                        inQuotes = !inQuotes;
                        stringBuilder.Append(character);
                    }
                    else if (!inQuotes)
                    {
                        if (character == ',')
                        {
                            stringBuilder.Append(character);
                            stringBuilder.Append("\r\n");
                            stringBuilder.Append('\t', indentation);
                        }
                        else if (character == '[' || character == '{')
                        {
                            stringBuilder.Append(character);
                            stringBuilder.Append("\r\n");
                            stringBuilder.Append('\t', ++indentation);
                        }
                        else if (character == ']' || character == '}')
                        {
                            stringBuilder.Append("\r\n");
                            stringBuilder.Append('\t', --indentation);
                            stringBuilder.Append(character);
                        }
                        else if (character == ':')
                        {
                            stringBuilder.Append(character);
                            stringBuilder.Append('\t');
                        }
                        else
                        {
                            stringBuilder.Append(character);
                        }
                    }
                    else
                    {
                        stringBuilder.Append(character);
                    }
                }
            }

            return stringBuilder.ToString();
        }

        public static string FormatOutput2HTML (string jsonString)
        {
            string auxs = CF.FormatOutput2Text(jsonString);
            auxs = auxs.Replace("\r\n", "<br>");
            auxs = auxs.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            return auxs;
        }

    }
}
