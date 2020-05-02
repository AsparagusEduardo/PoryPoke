using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPokeEditor
{
    public class Language
    {
        public static Dictionary<string, string> English = new Dictionary<string, string>
        {
            { "menuFile",       "File"},
            { "menuOptions",    "Options"},
            { "menuLanguage",   "Language"},
            { "menuEnglish",    "English"},
            { "menuSpanish",    "Spanish"},
            { "tabInforma",     "Information"},
            { "tabPokedex",     "Pokédex"},
            { "tabGraphic",     "Graphics"},
        };

        public static Dictionary<string, string> Spanish = new Dictionary<string, string>
        {
            { "menuFile",       "Archivo"},
            { "menuOptions",    "Opciones"},
            { "menuLanguage",   "Idioma"},
            { "menuEnglish",    "Inglés"},
            { "menuSpanish",    "Español"},
            { "tabInforma",     "Información"},
            { "tabPokedex",     "Pokédex"},
            { "tabGraphic",     "Gráficos"},
        };
    }
}
