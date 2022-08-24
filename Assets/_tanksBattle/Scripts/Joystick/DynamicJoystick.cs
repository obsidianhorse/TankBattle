using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }
    
    [SerializeField] private float moveThreshold = 1;
    
    private bool _isStarting = true;

    protected override void Start()
    {
        MoveThreshold = moveThreshold;
        base.Start();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        if (_isStarting == true)
        {
            OnPointerUp(eventData);
            _isStarting = false;

            base.OnPointerDown(eventData);
        }
    }
}