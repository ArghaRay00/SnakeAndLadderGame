using System;
namespace snake_ladder
{
    class Ladder
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public Ladder(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}