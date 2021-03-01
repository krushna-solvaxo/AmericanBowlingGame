using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame.Frames
{
    public class SpareFrame:Frame
    {
        public SpareFrame(List<int> rolls, int firstRoll, int secondRoll):base(rolls)
        {
            rolls.Add(firstRoll);
            rolls.Add(secondRoll);
        }
        public override int Score()
        {
            return 10 + FirstBonusRoll(); ;
        }

        override public int FrameSize()
        {
            return 2;
        }
    }
}
