public class PlayerAttackAct : IUndoCommand
{
    private CharacterController _characterController;
    private CharacterAnimationController _animController => _characterController.Character.CharacterAnimController;
    
    public PlayerAttackAct(CharacterController characterController)
    {
        _characterController = characterController;
    }
    
    public void Execute()
    {
        _animController.Attack();
        _characterController.characterState = CharacterState.Attack;
    }

    public void Undo()
    {
        _animController.StopAttack();
        _characterController.characterState = CharacterState.Idle;
    }
}