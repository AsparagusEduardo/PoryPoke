using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPokeEditor
{
    public class Constants
    {
        public static Dictionary<string, string> FilePaths = new Dictionary<string, string>
        {
            //{ "pFile_back_pic_table_inc",           "\\data\\graphics\\pokemon\\back_pic_table.inc"},
            //{ "pFile_front_pic_table_inc",          "\\data\\graphics\\pokemon\\front_pic_table.inc"},
            //{ "pFile_back_pic_coords_inc",          "\\data\\graphics\\pokemon\\back_pic_coords.inc"},
            //{ "pFile_front_pic_coords_inc",         "\\data\\graphics\\pokemon\\front_pic_coords.inc"},
            //{ "pFile_graphics_inc",                 "\\data\\graphics\\pokemon\\graphics.inc"},
            //{ "pFile_palette_table_inc",            "\\data\\graphics\\pokemon\\palette_table.inc"},
            //{ "pFile_shiny_palette_table_inc",      "\\data\\graphics\\pokemon\\shiny_palette_table.inc"},
            { "pFile_species_h",                    "\\include\\constants\\species.h"},
            //{ "pFile_global_h",                     "\\include\\global.h"},
            //{ "pFile_graphics_h",                   "\\include\\graphics.h"},
            //{ "pFile_pokedex_h",                    "\\include\\pokedex.h"},
            //{ "pFile_direct_sound_data_inc",        "\\sound\\direct_sound_data.inc"},
            //{ "pFile_voice_groups_inc",             "\\sound\\voice_groups.inc"},
            //{ "pFile_battle_1_c",                   "\\src\\battle\\battle_1.c"},
            { "pFile_base_stats_h",                 "\\src\\data\\pokemon\\base_stats.h"},
            //{ "pFile_cry_ids_h",                    "\\src\\data\\pokemon\\cry_ids.h"},
            //{ "pFile_level_up_learnset_pointers_h", "\\src\\data\\pokemon\\level_up_learnset_pointers.h"},
            //{ "pFile_level_up_learnsets_h",         "\\src\\data\\pokemon\\level_up_learnsets.h"},
            //{ "pFile_tmhm_learnsets_h",             "\\src\\data\\pokemon\\tmhm_learnsets.h"},
            //{ "pFile_species_names_en_h",           "\\src\\data\\text\\species_names_en.h"},
            //{ "pFile_pokedex_entries_en_h",         "\\src\\data\\pokedex_entries_en.h"},
            //{ "pFile_pokedex_orders_h",             "\\src\\data\\pokedex_orders.h"},
            //{ "pFile_pokedex_c",                    "\\src\\pokedex.c"},
            //{ "pFile_pokemon_1_c",                  "\\src\\pokemon_1.c"},
            //{ "pFile_pokemon_icon_c",               "\\src\\pokemon_icon.c"},
            //{ "pFile_move_names_en_h",              "\\src\\data\\text\\move_names_en.h"},
            { "pFile_items_h",                      "\\src\\data\\items.h"},
            { "pFile_pokemon_h",                    "\\include\\constants\\pokemon.h"},
            { "pFile_abilities_h",                  "\\include\\constants\\abilities.h"},
            //{ "pFile_evolution_h",                  "\\src\\data\\pokemon\\evolution.h"},
        };
    }
}
