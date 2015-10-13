using Sandbox.Common;
using Sandbox.Common.Components;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Engine;
using Sandbox.Game;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sescripts
{
    public class BOSS
    {
        IMyGridTerminalSystem GridTerminalSystem;
        
        // Start script
        
        #region Global variables.
        public readonly String version = "0.01";
        public Dictionary<String, IMyTextPanel> textPanels;
        public List<String> menuItems;
        public int selectedMenuItem = 0;
        public string control;
        public bool firstRun = true;
        #endregion

        public void Main(string control)
        {
            if(firstRun)
            {
                // Do first run stuff..
                
                // Set firstRun to false so this doesn't run again.
                firstRun = false;
            }
            
            if(string.IsNullOrEmpty(control))
                this.control = "none";
            else
                this.control = control;
            
            InitTextPanels();
            
            textPanels["WideTextPanel1"].WritePublicText("                                                                 BOSS " + version + "        current action: " + this.control + "\n");
            textPanels["WideTextPanel2"].WritePublicText("DEBUG");
            
            InitMenu();
        }
        
        public void InitMenu(){
            menuItems = new List<String>();
            menuItems.Add("Inventory summary");
            menuItems.Add("Status");
            menuItems.Add("AIDS");
            menuItems.Add("Watch South Park episode");
            
            InitMenuControls();
        }
        
        public void InitMenuControls(){
            /* DEBUG */ textPanels["WideTextPanel2"].WritePublicText("\nSwitch value: " + control, true);
            switch(control){
                case "left":
                    // TODO
                    break;
                case "up":
                    if(selectedMenuItem == 0)
                        selectedMenuItem = menuItems.Count - 1;
                    else 
                        selectedMenuItem -= 1;
                    break;
                case "down":
                    if(selectedMenuItem == menuItems.Count - 1)
                        selectedMenuItem = 0;
                    else 
                        selectedMenuItem += 1;
                    break;
                case "right":
                    break;
                default:        
                    break;
            }
            
            DrawMenu();
        }
        
        public void DrawMenu(){
            // Add dashes to the selected menu item so the user can identify the selected item.
            menuItems[selectedMenuItem] = "->" + menuItems[selectedMenuItem] + "<-";
            
            foreach(var menuItem in menuItems)
                textPanels["WideTextPanel1"].WritePublicText("\n " + menuItem, true);   
        }
        
        public void InitTextPanels(){
            textPanels = new Dictionary<String, IMyTextPanel> ();
            textPanels.Add("WideTextPanel1", GridTerminalSystem.GetBlockWithName("WideTextPanel1") as IMyTextPanel);
            textPanels.Add("WideTextPanel2", GridTerminalSystem.GetBlockWithName("WideTextPanel2") as IMyTextPanel);
            textPanels.Add("TextPanel1", GridTerminalSystem.GetBlockWithName("TextPanel1") as IMyTextPanel);
            textPanels.Add("TextPanel2", GridTerminalSystem.GetBlockWithName("TextPanel2") as IMyTextPanel);
            textPanels.Add("TextPanel3", GridTerminalSystem.GetBlockWithName("TextPanel3") as IMyTextPanel);
            textPanels.Add("TextPanel4", GridTerminalSystem.GetBlockWithName("TextPanel4") as IMyTextPanel);
            foreach(var textPanel in textPanels.Values){
                textPanel.ShowPublicTextOnScreen();
                textPanel.RequestShowOnHUD(false);
                textPanel.WritePublicText("");
            }
        }
        
        public class Monitor{
            public int aapje { get; set; }
        }
        
        // End script
    }
}
