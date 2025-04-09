using UnityEngine;

public class UI : MonoBehaviour
{
    public virtual void Open()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        this.gameObject.SetActive(false);
    }
}
