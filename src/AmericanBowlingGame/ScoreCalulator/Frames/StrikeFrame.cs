using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame.Frames
{
    public class StrikeFrame:Frame
    {
        public StrikeFrame(List<int> rolls):base(rolls)
        {
            rolls.Add(10);
        }

        override public int FrameSize()
        {
            return 1;
        }
        public override int Score()
        {
            return 10 + FirstBonusRoll() + SecondBonusRoll();
        }
    }
}
