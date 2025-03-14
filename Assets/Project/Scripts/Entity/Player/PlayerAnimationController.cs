using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Player _player;
    
    private Animator _rightAnim;
    private Animator _leftAnim;
    
    private readonly string _isAttack = "IsAttack";
    private readonly string _isDefense = "IsDefense";
    
    private int _isAttackHash;
    private int _isDefenseHash;

    private bool _isRightNull => _rightAnim == null;
    private bool _isLeftNull => _leftAnim == null;


    private void Awake()
    {
        HashSetUp();
    }
    public void InitOnCreate(Player player)
    {
        _player = player;
    }
    public void InitOnActivate()
    {
        GetAnimator();

    }

    public void GetAnimator()
    {
        _rightAnim = _player.RightHand.GetComponentInChildren<Animator>();
        _leftAnim = _player.LeftHand.GetComponentInChildren<Animator>();
    }
    
    private void HashSetUp()
    {
        _isAttackHash = Animator.StringToHash(_isAttack);
        _isDefenseHash = Animator.StringToHash(_isDefense);
    }

    public void Attack()
    {
        if(_isRightNull) return;
        _rightAnim.SetBool(_isAttackHash, true);
    }

    public void StopAttack()
    {
        if(_isRightNull) return;
        _rightAnim.SetBool(_isAttackHash, false);
    }
    public void Defense()
    {
        if(_isLeftNull) return;
        _leftAnim.SetBool(_isDefenseHash, true);
        _rightAnim.SetBool(_isDefenseHash, true);
    }

    public void StopDefense()
    {
        if(_isLeftNull) return;
        _leftAnim.SetBool(_isDefenseHash, false);
        _rightAnim.SetBool(_isDefenseHash, false);
    }
}
