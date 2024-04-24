using UnityEngine;

/// <summary>
/// Класс реализующий функционал джойстика
/// </summary>
public class Joystick : MonoBehaviour
{
    private Vector3 _direction;

    public void DirectionX(int num)
    {
        _direction.x = num;
    }

    public void DirectionY(int num) 
    { 
        _direction.y = num;
    }

    public Vector3 GetDirection()
    {
        return _direction;
    }
}
