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
            { "menuFolder",     "Select folder..."},
            { "menuSave",       "Save"},
            { "menuOptions",    "Options"},
            { "menuLanguage",   "Language"},
            { "menuEnglish",    "English"},
            { "menuSpanish",    "Spanish"},
            { "tabStats",       "Stats"},
            { "tabPokedex",     "Pokédex"},
            { "tabGraphics",    "Graphics"},
        };

        public static Dictionary<string, string> Spanish = new Dictionary<string, string>
        {
            { "menuFile",       "Archivo"},
            { "menuFolder",     "Seleccionar carpeta..."},
            { "menuSave",       "Guardar"},
            { "menuOptions",    "Opciones"},
            { "menuLanguage",   "Idioma"},
            { "menuEnglish",    "Inglés"},
            { "menuSpanish",    "Español"},
            { "tabStats",       "Estadísticas"},
            { "tabPokedex",     "Pokédex"},
            { "tabGraphics",    "Gráficos"},
        };
    }
}
