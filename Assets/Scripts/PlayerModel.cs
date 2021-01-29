namespace Shipov_Snake
{
    internal class PlayerModel
    {
        public int Size;
        public float Speed { get; }

        PlayerModel(PlayerSOData playerData)
        {
            Size = playerData.StartSize;
            Speed = playerData.StartSpeed;
        }
    }
}
