public class PlayerAttackAct : IUndoCommand
{
    private PlayerController _playerController;
    private PlayerAnimationController _animController => _playerController.Player.PlayerAnimController;
    
    public PlayerAttackAct(PlayerController playerController)
    {
        _playerController = playerController;
    }
    
    public void Execute()
    {
        _animController.Attack();
    }

    public void Undo()
    {
        _animController.StopAttack();

    }
}