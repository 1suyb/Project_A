using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntry : SceneEntry
{
    private GameObject _gameManagerObj;
    protected override void InitManagers()
    {
        base.InitManagers();
        if (_gameManagerObj == null)
        {
            _gameManagerObj = ResourceLoader.Instantiate(Path.GameManager);
            
            GameManager gameManager = _gameManagerObj.GetComponent<GameManager>();
            GameManager.Init(gameManager);
            
            FactoryManager factoryManager = _gameManagerObj.GetComponent<FactoryManager>();
            FactoryManager.Init(factoryManager);
            
            PlayerManager playerManager = _gameManagerObj.GetComponent<PlayerManager>();
            PlayerManager.Init(playerManager);
            
            /*UIManager uiManager = _gameManagerObj.GetComponent<UIManager>();
            UIManager.Init(uiManager);*/
            
            RoutineManager routineManager = _gameManagerObj.GetComponent<RoutineManager>();
            RoutineManager.Init(routineManager);
            
        }
    }

    protected override void InitScene()
    {
        GameObject playerObj = ResourceLoader.Instantiate(Path.Character);
        GameObject cameraObj = ResourceLoader.Instantiate(Path.Camera);
    }
}
