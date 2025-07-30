public class PlayerDefenseAct : IUndoCommand
{
    private CharacterController _characterController;
    private CharacterAnimationController _animController => _characterController.Character.CharacterAnimController;
    
    public PlayerDefenseAct(CharacterController characterController)
    {
        _characterController = characterController;
    }
    
    public void Execute()
    {
        _animController.Defense();
        _characterController.characterState = CharacterState.Defense;
    }

    public void Undo()
    {
        _animController.StopDefense();
        _characterController.characterState = CharacterState.Idle;
    }
}