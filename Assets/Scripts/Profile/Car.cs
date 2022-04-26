namespace Profile
{
    internal class Car : IUpgradableCar
    {
        private readonly float _defaultSpeed;

        public float Speed { get; set; }

        public Car(float speed)
        {
            _defaultSpeed = speed;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}