using System;
using System.Collections.Generic;
using System.Text;

namespace AmericanBowlingGame.Frames
{
    public abstract class Frame:IFrame
    {
        protected List<int> Rolls;
        protected int StartingRoll;

        public Frame(List<int> rolls)
        {
            this.Rolls = rolls;
            this.StartingRoll = rolls.Count;
        }

        protected int FirstBonusRoll()
        {
            return Rolls[StartingRoll + FrameSize()];
        }

        protected int SecondBonusRoll()
        {
            return Rolls[StartingRoll + FrameSize() + 1];
        }

        abstract public int FrameSize();
        abstract public int Score();
    }
}
