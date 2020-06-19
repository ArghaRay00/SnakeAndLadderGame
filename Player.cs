using System;
namespace snake_ladder
{
    class Player
    {
        public string Name { get;  private set; }
        public string Id { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}