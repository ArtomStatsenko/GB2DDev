using Profile.Analytic;
using Tools;

namespace Profile
{
    internal class PlayerData
    {
        public SubscriptionProperty<GameState> GameState { get; private set; }
        public Car CurrentCar { get; }
        public IAnalyticTool AnalyticTool { get; }

        public PlayerData(float carSpeed, IAnalyticTool analyticTool)
        {
            CurrentCar = new Car(carSpeed);
            AnalyticTool = analyticTool;

            GameState = new SubscriptionProperty<GameState>();
            GameState.Value = global::GameState.None;
        }
    }
}