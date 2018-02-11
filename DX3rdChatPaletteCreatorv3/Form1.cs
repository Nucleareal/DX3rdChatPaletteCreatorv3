using DX3rdChatPaletteCreator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DX3rdChatPaletteCreatorv3
{
    public partial class Form1 : Form
    {
        private PersonalData data;

        private int loadingvalue;

        public Form1()
        {
            InitializeComponent();

            data = new PersonalData();
            dataGettingProgress.Maximum = 100;
        }

        private void urlAccessButton_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser.Url = new Uri(urlArea.Text);
            }
            catch (Exception e1)
            {
                labelNameValue.Text = "不正なURLです";
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && ActiveControl == urlArea)
            {
                urlAccessButton.PerformClick();
            }
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            data = new PersonalData();

            if(webBrowser.Document == null)
            {
                labelNameValue.Text = "は？";
                return;
            }

            data.name = getElementValue("base.name");
            if (data.name == "" || data.name == null)
            {
                labelNameValue.Text = "まだページがロードされていないか、名前が空です";
                return;
            }

            labelNameValue.Text = "◆出力中です";
            dataGettingProgress.Value = 0;
            
            data.肉体.value = int.Parse(getElementValue("baseAbility.body.subtotal"));
            data.感覚.value = int.Parse(getElementValue("baseAbility.sense.subtotal"));
            data.精神.value = int.Parse(getElementValue("baseAbility.mind.subtotal"));
            data.社会.value = int.Parse(getElementValue("baseAbility.society.subtotal"));

            data.肉体.children.Add(new TupleItem<string, int>("白兵", getElementValueAsInt("skills.hak.A.lv")));
            data.肉体.children.Add(new TupleItem<string, int>("回避", getElementValueAsInt("skills.kai.A.lv")));
            data.感覚.children.Add(new TupleItem<string, int>("射撃", getElementValueAsInt("skills.sha.A.lv")));
            data.感覚.children.Add(new TupleItem<string, int>("知覚", getElementValueAsInt("skills.tik.A.lv")));
            data.精神.children.Add(new TupleItem<string, int>("RC", getElementValueAsInt("skills.rc.A.lv")));
            data.精神.children.Add(new TupleItem<string, int>("意思", getElementValueAsInt("skills.isi.A.lv")));
            data.社会.children.Add(new TupleItem<string, int>("交渉", getElementValueAsInt("skills.kou.A.lv")));
            data.社会.children.Add(new TupleItem<string, int>("調達", getElementValueAsInt("skills.tyo.A.lv")));

            //ここからB技能(めんどくさい)
            int abilityNumber = 0;
            while (processNextBAbility(abilityNumber))
            {
                abilityNumber++;
            }

            dataGettingProgress.Value = 10;

            int comboNumber = 0;
            while (processNextCombo(comboNumber))
            {
                comboNumber++;
            }

            dataGettingProgress.Value = 20;

            var json = new DX3rdJsonData();

            string[] shifts = { "0%", "60%", "80%", "100%", "130%" };

            for(var i = 0; i < 5; i++)
            {
                var info = new DX3rdJsonData.SaveData.TabInfo();

                info.tabName = shifts[i];

                CreatePage(i, info);

                json.saveData.tabInfos.Add(info);
            }

            dataGettingProgress.Value = 50;

            var serializer = new DataContractJsonSerializer(typeof(DX3rdJsonData));
            var fs = new FileStream($"{data.name}_CP.cpd", FileMode.Create);

            try
            {
                serializer.WriteObject(fs, json);
            }
            finally
            {
                fs.Close();
            }

            dataGettingProgress.Value = 100;
            labelNameValue.Text = "◆出力が完了しました(exeと同じフォルダにあると思います)";
        }

        private void CreatePage(int addtional, DX3rdJsonData.SaveData.TabInfo item)
        {
            if(addtional == 0)
            {
                item.lines.Add($"1d10 登場侵蝕/リザレクション");
                item.lines.Add($"{(data.肉体.value+10)} タイタス昇華復活HP");
            }

            item.lines.Add($"-------- 肉体 --------");
            item.lines.Add($"({{{data.肉体.name}@0%}}+{addtional})dx {data.肉体.name}");
            foreach (var element in data.肉体.children)
            {
                item.lines.Add($"({{{data.肉体.name}@0%}}+{addtional})dx+{{{element.Item1}@0%}} {data.肉体.name}->{element.Item1}");
            }

            item.lines.Add($"-------- 感覚 --------");
            item.lines.Add($"({{{data.感覚.name}@0%}}+{addtional})dx {data.感覚.name}");
            foreach (var element in data.感覚.children)
            {
                item.lines.Add($"({{{data.感覚.name}@0%}}+{addtional})dx+{{{element.Item1}@0%}} {data.感覚.name}->{element.Item1}");
            }

            item.lines.Add($"-------- 精神 --------");
            item.lines.Add($"({{{data.精神.name}@0%}}+{addtional})dx {data.精神.name}");
            foreach (var element in data.精神.children)
            {
                item.lines.Add($"({{{data.精神.name}@0%}}+{addtional})dx+{{{element.Item1}@0%}} {data.精神.name}->{element.Item1}");
            }

            item.lines.Add($"-------- 社会 --------");
            item.lines.Add($"({{{data.社会.name}@0%}}+{addtional})dx {data.社会.name}");
            foreach (var element in data.社会.children)
            {
                item.lines.Add($"({{{data.社会.name}@0%}}+{addtional})dx+{{{element.Item1}@0%}} {data.社会.name}->{element.Item1}");
            }

            item.lines.Add($"-------- その他 --------");
            if (addtional == 0) item.lines.Add($"衝動判定は 精神-意思");

            item.lines.Add("");

            //コンボ
            if(addtional == 0)
            {
                foreach(var e in data.combos)
                {
                    item.lines.Add($"{e.ダイスu} 0%-99% [{e.名前}] 侵蝕値:{e.侵蝕u} 組み合わせ:{e.組み合わせu}");
                }
            }
            if(addtional == 3)
            {
                foreach (var e in data.combos)
                {
                    item.lines.Add($"{e.ダイスo} 100%-159% [{e.名前}] 侵蝕値:{e.侵蝕o} 組み合わせ:{e.組み合わせo}");
                }
            }

            //変数
            if (addtional == 0)
            {
                item.lines.Add($"-------- 変数 --------");
                item.lines.Add($"//{data.肉体.name}={data.肉体.value}");
                item.lines.Add($"//{data.感覚.name}={data.感覚.value}");
                item.lines.Add($"//{data.精神.name}={data.精神.value}");
                item.lines.Add($"//{data.社会.name}={data.社会.value}");

                item.lines.Add($"-------- 肉体 --------");
                foreach (var element in data.肉体.children)
                {
                    item.lines.Add($"//{element.Item1}={element.Item2}");
                }
                item.lines.Add($"-------- 感覚 --------");
                foreach (var element in data.感覚.children)
                {
                    item.lines.Add($"//{element.Item1}={element.Item2}");
                }
                item.lines.Add($"-------- 精神 --------");
                foreach (var element in data.精神.children)
                {
                    item.lines.Add($"//{element.Item1}={element.Item2}");
                }
                item.lines.Add($"-------- 社会 --------");
                foreach (var element in data.社会.children)
                {
                    item.lines.Add($"//{element.Item1}={element.Item2}");
                }
            }
        }

        private bool processNextCombo(int comboNumber)
        {
            string baseName = comboNumber == 0 ? "combo.0" : $"combo.{comboNumber:D3}";
            if (webBrowser.Document.GetElementById(baseName) == null) return false;

            if (getElementValue(baseName + ".name") != "")
            {
                data.combos.Add(new PersonalData.Combo(getElementValue(baseName + ".name"),
                    getElementValue(baseName + ".under100.cost"),
                    getElementValue(baseName + ".under100.dice"),
                    getElementValue(baseName + ".under100.combination"),
                    getElementValue(baseName + ".over100.cost"),
                    getElementValue(baseName + ".over100.dice"),
                    getElementValue(baseName + ".over100.combination")
                    ));
            }

            return true;
        }

        private bool processNextBAbility(int abilityNumber)
        {
            string baseName = abilityNumber == 0 ? "skills.B.0" : $"skills.B.{abilityNumber:D3}";

            if (webBrowser.Document.GetElementById(baseName) == null) return false;

            string name1 = getElementValue(baseName + ".name1"); var lv1 = getElementValueAsInt(baseName + ".lv1");
            string name2 = getElementValue(baseName + ".name2"); var lv2 = getElementValueAsInt(baseName + ".lv2");
            string name3 = getElementValue(baseName + ".name3"); var lv3 = getElementValueAsInt(baseName + ".lv3");
            string name4 = getElementValue(baseName + ".name4"); var lv4 = getElementValueAsInt(baseName + ".lv4");

            //if (lv1 == 0 && lv2 == 0 && lv3 == 0 && lv4 == 0) return false;

            if (name1 != "" && lv1 != 0) data.肉体.children.Add(new TupleItem<string, int>("運転:" + name1, lv1));
            if (name2 != "" && lv2 != 0) data.感覚.children.Add(new TupleItem<string, int>("芸術:" + name2, lv2));
            if (name3 != "" && lv3 != 0) data.精神.children.Add(new TupleItem<string, int>("知識:" + name3, lv3));
            if (name4 != "" && lv4 != 0) data.社会.children.Add(new TupleItem<string, int>("情報:" + name4, lv4));

            return true;
        }

        private int getElementValueAsInt(string v)
        {
            HtmlElement element = webBrowser.Document.GetElementById(v);

            string str = element.GetAttribute("value");

            var result = str == null || str == "" ? 0 : int.Parse(str);

            return result;
        }

        private string getElementValue(string v)
        {
            HtmlElement element = webBrowser.Document.GetElementById(v);

            string str = element.GetAttribute("value");

            if (str == null) str = element.InnerHtml;

            return str;
        }
    }
}
