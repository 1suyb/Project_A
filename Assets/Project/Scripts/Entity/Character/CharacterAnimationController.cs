using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Character _character;
    
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
    public void InitOnCreate(Character character)
    {
        _character = character;
    }
    public void InitOnActivate()
    {
        GetAnimator(null);
        _character.OnEquipped += GetAnimator;
        _character.OnUnequipped += ReleaseAnimator;
    }
    public void OnDisable()
    {
        EventHub.PlayerEventReceiver.OnEquip -= GetAnimator;
        EventHub.PlayerEventReceiver.OnUnEquip -= ReleaseAnimator;
    }

    private void GetAnimator(Equipment equipment)
    {
        if (equipment == null)
            return;
        
        EquipType type = equipment.EquipmentInfo.EquipType;
        if(type == EquipType.Weapon)
            _rightAnim = _character.RightHand.GetComponentInChildren<Animator>();
        else
            _leftAnim = _character.LeftHand.GetComponentInChildren<Animator>();
    }
    private void ReleaseAnimator(Equipment equipment)
    {
        if (equipment == null)
            return;
            
        EquipType type = equipment.EquipmentInfo.EquipType;
        if(type == EquipType.Weapon)
            _rightAnim = null;
        else
            _leftAnim = null;
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
