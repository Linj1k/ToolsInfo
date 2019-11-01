using MSCLoader;
using UnityEngine;
using HutongGames.PlayMaker;

namespace ToolsInfo
{
    public class ToolsInfo : Mod
    {
        public override string ID => "ToolsInfo"; //Your mod ID (unique)
        public override string Name => "ToolsInfo"; //You mod name
        public override string Author => "Linj"; //Your Username
        public override string Version => "1.0"; //Version

        // Set this to true if you will be load custom assets from Assets folder.
        // This will create subfolder in Assets folder for your mod.
        public override bool UseAssetsFolder => false;
        public override bool LoadInMenu => false;

        public Settings ShowToolsInfo;
        private FsmFloat _wrenchSize;

        public ToolsInfo() {
            ShowToolsInfo = new Settings("ShowToolsInfo", "Activate/Deactivate GUI", true);
        }

        public override void OnLoad()
        {
            _wrenchSize = FsmVariables.GlobalVariables.FindFsmFloat("ToolWrenchSize");
            ModConsole.Print("ToolsInfo has been loaded!");
        }

        public override void ModSettings()
        {
            Settings.AddCheckBox(this, ShowToolsInfo);
        }

        public override void OnGUI()
        {
            var myStyle = new GUIStyle();
            myStyle.fontSize = 20;
            myStyle.fontStyle = FontStyle.Bold;
            myStyle.normal.textColor = Color.white;

            if ((bool)ShowToolsInfo.GetValue())
            {
                if (FsmVariables.GlobalVariables.FindFsmBool("PlayerHandRight").Value)
                {
                    if(_wrenchSize.Value != 0) {
                        GUI.Label(new Rect(Screen.width - 340, 60, 50, 20), Mathf.RoundToInt(_wrenchSize.Value * 10f).ToString(), myStyle);
                    }
                }
            }
        }
    }
}