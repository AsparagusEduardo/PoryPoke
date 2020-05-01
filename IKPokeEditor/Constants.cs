using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPokeEditor
{
    public class Constants
    {
        public static string[] filePathNames = {
            //("pFile_back_pic_table_inc"),
            //("pFile_front_pic_table_inc"),
            //("pFile_back_pic_coords_inc"),
            //("pFile_front_pic_coords_inc"),
            //("pFile_graphics_inc"),
            //("pFile_palette_table_inc"),
            //("pFile_shiny_palette_table_inc"),
            ("pFile_species_h"),
            //("pFile_global_h"),
            //("pFile_graphics_h"),
            //("pFile_pokedex_h"),
            //("pFile_direct_sound_data_inc"),
            //("pFile_voice_groups_inc"),
            //("pFile_battle_1_c"),
            ("pFile_base_stats_h"),
            //("pFile_cry_ids_h"),
            //("pFile_level_up_learnset_pointers_h"),
            //("pFile_level_up_learnsets_h"),
            //("pFile_tmhm_learnsets_h"),
            //("pFile_species_names_en_h"),
            //("pFile_pokedex_entries_en_h"),
            //("pFile_pokedex_orders_h"),
            //("pFile_pokedex_c"),
            //("pFile_pokemon_1_c"),
            //("pFile_pokemon_icon_c"),
            //("pFile_move_names_en_h"),
            //("pFile_items_en_h"),
            ("pFile_pokemon_h"),
            //("pFile_abilities_h"),
            //("pFile_evolution_h")
        };

        public static string[] filePaths = {
            //(directory.ToString() + "\\data\\graphics\\pokemon\\back_pic_table.inc"),
            //(directory.ToString() + "\\data\\graphics\\pokemon\\front_pic_table.inc"),
            //(directory.ToString() + "\\data\\graphics\\pokemon\\back_pic_coords.inc"),
            //(directory.ToString() + "\\data\\graphics\\pokemon\\front_pic_coords.inc"),
            //(directory.ToString() + "\\data\\graphics\\pokemon\\graphics.inc"),
            //(directory.ToString() + "\\data\\graphics\\pokemon\\palette_table.inc"),
            //(directory.ToString() + "\\data\\graphics\\pokemon\\shiny_palette_table.inc"),
            "\\include\\constants\\species.h",
            //(directory.ToString() + "\\include\\global.h"),
            //(directory.ToString() + "\\include\\graphics.h"),
            //(directory.ToString() + "\\include\\pokedex.h"),
            //(directory.ToString() + "\\sound\\direct_sound_data.inc"),
            //(directory.ToString() + "\\sound\\voice_groups.inc"),
            //(directory.ToString() + "\\src\\battle\\battle_1.c"),
            "\\src\\data\\pokemon\\base_stats.h",
            //(directory.ToString() + "\\src\\data\\pokemon\\cry_ids.h"),
            //(directory.ToString() + "\\src\\data\\pokemon\\level_up_learnset_pointers.h"),
            //(directory.ToString() + "\\src\\data\\pokemon\\level_up_learnsets.h"),
            //(directory.ToString() + "\\src\\data\\pokemon\\tmhm_learnsets.h"),
            //(directory.ToString() + "\\src\\data\\text\\species_names_en.h"),
            //(directory.ToString() + "\\src\\data\\pokedex_entries_en.h"),
            //(directory.ToString() + "\\src\\data\\pokedex_orders.h"),
            //(directory.ToString() + "\\src\\pokedex.c"),
            //(directory.ToString() + "\\src\\pokemon_1.c"),
            //(directory.ToString() + "\\src\\pokemon_icon.c"),
            //(directory.ToString() + "\\src\\data\\text\\move_names_en.h"),
            //(directory.ToString() + "\\src\\data\\items .h"),
            "\\include\\constants\\pokemon.h",
            //(directory.ToString() + "\\include\\constants\\abilities.h"),
            //(directory.ToString() + "\\src\\data\\pokemon\\evolution.h"),
        };
    }
}
