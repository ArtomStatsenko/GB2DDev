using Tools;

namespace Profile
{
    internal class PlayerData
    {
        public SubscriptionProperty<GameState> GameState { get; private set; }
        public Car CurrentCar { get; }

        public PlayerData(float carSpeed)
        {
            CurrentCar = new Car(carSpeed);

            GameState = new SubscriptionProperty<GameState>();
            GameState.Value = global::GameState.None;
        }
    }
}