using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DiagnosticoEnfermedades.Helpers
{
    public static class WordReplaceHelper
    {
        public static void ReemplazarMarcadoresRobusto(Body body, Dictionary<string, string> campos)
        {
            var textos = body.Descendants<Text>().ToList();

            foreach (var campo in campos)
            {
                string marcador = "{" + campo.Key + "}";
                string reemplazo = campo.Value ?? "";

                int i = 0;
                while (i < textos.Count)
                {
                    // Intentar buscar el marcador partido entre varios nodos
                    int length = marcador.Length;
                    int idx = 0;
                    int start = i;

                    while (start < textos.Count && idx < length)
                    {
                        string t = textos[start].Text;
                        int toMatch = System.Math.Min(length - idx, t.Length);
                        if (t.StartsWith(marcador.Substring(idx, toMatch)))
                        {
                            idx += toMatch;
                            if (idx == length)
                                break;
                            start++;
                        }
                        else
                            break;
                    }

                    // Si encontramos el marcador partido
                    if (idx == length)
                    {
                        // Reemplazar texto en el primer nodo
                        textos[i].Text = textos[i].Text.Replace(
                            textos[i].Text.Substring(0, System.Math.Min(marcador.Length, textos[i].Text.Length)),
                            reemplazo
                        );
                        // Vaciar los nodos intermedios
                        for (int j = i + 1; j <= start; j++)
                            textos[j].Text = "";
                        i = start + 1;
                    }
                    else
                    {
                        // Si el marcador está completo en un solo nodo
                        if (textos[i].Text.Contains(marcador))
                        {
                            textos[i].Text = textos[i].Text.Replace(marcador, reemplazo);
                        }
                        i++;
                    }
                }
            }
        }
    }
}