using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX3rdChatPaletteCreator
{
    public class DX3rdJsonData
    {
        public class SaveData
        {
            public class TabInfo
            {
                public int color { get; set; } = 255 << 16 | 255 << 8 | 255;
                public List<object> lines { get; set; } = new List<object>();
                public string name { get; set; }
                public string tabName { get; set; }
            }
            public List<TabInfo> tabInfos { get; set; } = new List<TabInfo>();
        }
        public SaveData saveData { get; set; } = new SaveData();
        public string saveDataTypeName { get; set; } = "ChatPalette2";
    }
}
