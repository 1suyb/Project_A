public class BuffHandler
{
    private BuffInfo _buffInfo;
    public BuffHandler(int id)
    {
        _buffInfo = InfoManager.Instance.Load<BuffInfo>(id);
    }
    public void ApplyBuff(Entity target)
    {
        //target.ApplyBuff(_buffInfo);
    }
}