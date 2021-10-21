using UnityEngine;

[RequireComponent(typeof(Snake))]
public class SnakeInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private IMovable _mover;

    private void Start()
    {
        _mover = GetComponent<Snake>();
    }

    private void Update()
    {
        _mover.TryRotate(_joystick.Horizontal);
        _mover.Move(transform.position + transform.forward * _speed * Time.deltaTime);
    }
}