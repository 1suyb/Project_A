using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public Character Character { get; private set; }
    public CharacterStatHandler Status => Character.CharacterStatHandler;
    
    public Transform RightHand => Character.RightHand;
    public Transform LeftHand => Character.LeftHand;
    
    public Equipment Weapon { get; private set; }
    public Equipment Shield { get; private set; }
    
    public Transform WeaponObject { get; private set; }
    public Transform ShieldObject { get; private set; }
    
    public void InitOnCreate(Character character)
    {
        Character = character;
    }

    public void InitOnActivate()
    {
        EventHub.PlayerEventReceiver.OnEquip += Equip;
        EventHub.PlayerEventReceiver.OnUnEquip += UnEquip;
        TestCode();
    }
/// <summary>
/// 장비 장착 테스트 코드
/// </summary>
    private void TestCode()
    {
        Equipment weapon = new Equipment(101);
        Equipment shield = new Equipment(201);
        weapon.Use();
        shield.Use();
    }

    public void OnDisable()
    {
        EventHub.PlayerEventReceiver.OnEquip -= Equip;
        EventHub.PlayerEventReceiver.OnUnEquip -= UnEquip;
    }
    /// <summary>
    /// 장착
    /// </summary>
    /// <param name="equipment"></param>
    private void Equip(Equipment equipment)
    {
        EquipmentInfo equipInfo = equipment.EquipmentInfo;
        if (equipInfo.EquipType == EquipType.Weapon)
        {
            WeaponEquip(equipment);
        }
        else if (equipInfo.EquipType == EquipType.Shield)
        {
            ShieldEquip(equipment);
        }
        
        foreach (var option in equipment.Options)
        {
            //option.Apply(Status);
        }
        Character.RaiseEquippedEvent(equipment);
    }
    /// <summary>
    /// 장착 해제
    /// </summary>
    /// <param name="equipment"></param>
    private void UnEquip(Equipment equipment)
    {
        
        foreach (var option in equipment.Options)
        {
            //option.Remove(Status);
        }
        Character.RaiseUnEquippedEvent(equipment);
    }

    /// <summary>
    /// 장비에 알맞은 모델을 불러옵니다
    /// </summary>
    /// <param name="equipment"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    private Transform InstantiateModel(Equipment equipment, Transform parent)
    {
        GameObject model = Instantiate(Resources.Load<GameObject>(Path.EquipModel(equipment.EquipmentInfo.ID)), parent);
        return model.transform;
    }
    /// <summary>
    /// 장비의 컴포넌트를 부착합니다
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T AddEquipmentComponent<T>(GameObject obj) where T : MonoBehaviour
    {
        T component = obj.GetComponent<T>();
        if (component == null)
        {
            component = obj.AddComponent<T>();
        }

        return component;
    }
    
    /// <summary>
    /// 무기를 장착합니다.
    /// </summary>
    /// <param name="equipment"></param>
    private void WeaponEquip(Equipment equipment)
    {
        Weapon = equipment;
        WeaponObject = InstantiateModel(equipment, RightHand);
        Weapon wp = AddEquipmentComponent<Weapon>(WeaponObject.gameObject);
        wp.SetPlayer(Character);
    }
    
    /// <summary>
    /// 방어구를 장착합니다.
    /// </summary>
    /// <param name="equipment"></param>
    private void ShieldEquip(Equipment equipment)
    {
        Shield = equipment;
        ShieldObject = InstantiateModel(equipment, LeftHand);
        AddEquipmentComponent<Shield>(ShieldObject.gameObject);
    }
}
