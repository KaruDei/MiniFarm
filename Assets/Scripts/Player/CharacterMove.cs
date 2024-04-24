using UnityEngine;

/// <summary>
/// Класс передвижения игрока
/// </summary>
public class CharacterMove : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    [Header("Sprites")]
    [SerializeField] private Sprite _front;
    [SerializeField] private Sprite _back;
    [SerializeField] private Sprite _left;
    [SerializeField] private Sprite _right;

    private Vector3 _direction;
    private void FixedUpdate()
    {
        _direction = _joystick.GetDirection();
        if (_direction.magnitude != 0)
        {
            _rigidbody.velocity = _direction * _speed;
            ChangeSprite();
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _spriteRenderer.sprite = _front;
        }
    }

    public void ChangeSprite()
    {
        if (_direction.x > 0)
            _spriteRenderer.sprite = _right;
        else if (_direction.x < 0)
            _spriteRenderer.sprite = _left;
        else if (_direction.y > 0)
            _spriteRenderer.sprite = _back;
        else if (_direction.y < 0)
            _spriteRenderer.sprite = _front;
            
    }
}
