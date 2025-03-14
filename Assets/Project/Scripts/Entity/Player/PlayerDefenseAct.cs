public class PlayerDefenseAct : IUndoCommand
{
    private PlayerController _playerController;
    private PlayerAnimationController _animController => _playerController.Player.PlayerAnimController;
    
    public PlayerDefenseAct(PlayerController playerController)
    {
        _playerController = playerController;
    }
    
    public void Execute()
    {
        _animController.Defense();
    }

    public void Undo()
    {
        _animController.StopDefense();

    }
}