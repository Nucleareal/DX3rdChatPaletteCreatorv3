using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX3rdChatPaletteCreatorv3
{
    class PersonalData
    {
        public class Ability
        {
            public Ability(string name)
            {
                this.name = name;
            }

            public string name;
            public int value;

            public List<TupleItem<string, int>> children = new List<TupleItem<string, int>>();
        }

        public class Combo
        {
            public Combo(string 名前, string 侵蝕u, string ダイスu, string 組み合わせu, string 侵蝕o, string ダイスo, string 組み合わせo)
            {
                this.名前 = 名前;
                this.侵蝕u = 侵蝕u;
                this.ダイスu = ダイスu;
                this.組み合わせu = 組み合わせu;
                this.侵蝕o = 侵蝕o;
                this.ダイスo = ダイスo;
                this.組み合わせo = 組み合わせo;
            }

            public string 名前;
            public string 侵蝕u;
            public string ダイスu;
            public string 組み合わせu;
            public string 侵蝕o;
            public string ダイスo;
            public string 組み合わせo;
        }

        public class Effect
        {
            public Effect(string 名前, string 侵蝕)
            {
                this.名前 = 名前;
                this.侵蝕 = 侵蝕;
            }

            public string 名前;
            public string 侵蝕;
        }

        public string name = "ChatPalette"; //名前
        public Ability 肉体 = new Ability("肉体"); //パラメータ達
        public Ability 感覚 = new Ability("感覚");
        public Ability 精神 = new Ability("精神");
        public Ability 社会 = new Ability("社会");
        public List<Combo> combos = new List<Combo>();
        public List<Effect> arts = new List<Effect>();
    }
}
