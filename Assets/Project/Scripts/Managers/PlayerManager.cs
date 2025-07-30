
public class PlayerManager : Singleton<PlayerManager>
{
    public Character Character { get; private set; }
    
    
    public void InitOnCreate()
    { 
        // 캐릭터 생성
        Character.InitOnCreate();
    }
    public void InitOnActivate()
    {
        Character.InitOnActivate();
    }
    
    public void Release()
    {
        Character.Release();
    }
    

    public void Heal()
    {
        
    }
    public void Damage()
    {
        
    }
    public void Dead()
    {
        
    }
    
    
}

