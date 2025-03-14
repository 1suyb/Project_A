using UnityEngine;

public enum InputState
{
    Began,
    Stationary,
    Moved,
    Ended
}

public class InputEventSource : MonoBehaviour
{
    [SerializeField] private InputEventReceiver _inputEventReceiver;
    [SerializeField] private float _minMoveTime = 0.5f;
    [SerializeField] private float _minMoveDistance = 0.2f;
    
    private float _time = 0f;
    private InputState _inputState = InputState.Began;
    private Vector2 _startPos;
    
    private void Update()
    {
        TouchInput();
        #if UNITY_EDITOR
        MouseInput();
        #endif
    }

    private void TouchInput()
    {
        if(_inputState == InputState.Began || _inputState == InputState.Stationary)
            _time += Time.deltaTime;
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (_inputState == InputState.Ended)
                {
                    _inputState = InputState.Began;
                    _startPos = touch.position;
                    _inputEventReceiver.TouchBegan();
                }
                    
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                if (_time>_minMoveTime &&Vector2.Distance(_startPos, touch.position) < _minMoveDistance)
                {
                    if (_inputState == InputState.Began)
                    {
                        _inputState = InputState.Stationary;
                        _inputEventReceiver.TouchStationary();
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if(Vector2.Distance(_startPos, touch.position) >= _minMoveDistance)
                {
                    if (_inputState == InputState.Began)
                    {
                        _inputState = InputState.Moved;
                        _inputEventReceiver.TouchMoved();
                    }
                       
                    
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _inputState = InputState.Ended;
                _time = 0f;
                _inputEventReceiver.TouchEnded();
            }
        }
    }
#if UNITY_EDITOR
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _inputEventReceiver.TouchMoved();
        }
        if(Input.GetMouseButtonUp(0))
        {
            _inputEventReceiver.TouchEnded();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _inputEventReceiver.TouchStationary();
        }

        if (Input.GetMouseButtonUp(1))
        {
            _inputEventReceiver.TouchEnded();
        }
    }
#endif
}
