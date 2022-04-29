using UnityEngine;

public sealed class Enemy : IEnemy
{
    private const int MONEY_COEF = 5;
    private const float POWER_COEF = 1.5f;
    private const int MAX_HEALTH_PLAYER = 5;
    private string _name;
    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;

    public int Power
    {
        get
        {
            var healthCoef = _healthPlayer > MAX_HEALTH_PLAYER ? 100 : 5;
            var power = (int)(_moneyPlayer / MONEY_COEF + healthCoef + _powerPlayer / POWER_COEF);
            
            return power;
        }
    }

    public Enemy(string name)
    {
        _name = name;
    }

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _moneyPlayer = dataPlayer.Money;
                break;
            case DataType.Health:
                _healthPlayer = dataPlayer.Health;
                break;
            case DataType.Power:
                _powerPlayer = dataPlayer.Power;
                break;
        }

        Debug.Log($"Notified {_name} change to {dataPlayer}");
    }
}
