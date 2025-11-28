public class PowerupCommand : ICommand
{
    private PlayerController _reciever;
    private PowerupType _type;
    private float _duration;
    public PowerupCommand(PlayerController r, PowerupType t, float d)
    {
        _reciever = r;
        _type = t;
        _duration = d;
    }
    public void Execute()
    {
        _reciever.ApplyPowerUp(_type, _duration);
    }
    public void Undo()
    {
        _reciever.CancelPowerUp(_type);
    }
}
