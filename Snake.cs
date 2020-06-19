using System;

namespace snake_ladder
{

    class Snake
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public Snake(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}