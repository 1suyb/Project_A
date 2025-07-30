using UnityEngine;

public abstract class SceneEntry : MonoBehaviour
{
    private GameObject _systemManagerObj;
    protected void Awake()
    {
        InitManagers();
        InitScene();
    }
    protected void Start()
    {
    }


    protected virtual void InitManagers()
    {
        // TODO : 매니저 초기화, 검증
        if (_systemManagerObj == null)
        {
            _systemManagerObj = ResourceLoader.Instantiate(Path.SystemMamanger);
            InfoManager infoManager = _systemManagerObj.GetComponent<InfoManager>();
            InfoManager.Init(infoManager);
        }

    }

    protected abstract void InitScene();
}
