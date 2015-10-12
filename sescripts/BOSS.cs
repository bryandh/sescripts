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

        public void main()
        {
            List<IMyTerminalBlock> blocks;

            blocks = new List<IMyTerminalBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyRadioAntenna>(blocks);
            if (blocks.Count == 0) return;
            IMyRadioAntenna antenna = blocks[0] as IMyRadioAntenna;

            antenna.SetCustomName("Hello Galaxy!");
        }
    }
}
