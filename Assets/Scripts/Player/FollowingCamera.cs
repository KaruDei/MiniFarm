using UnityEngine;

/// <summary>
/// Класс передвижения камеры за игроком
/// </summary>
public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Vector3 _newTargetPos = Vector3.zero;

    private void FixedUpdate()
    {
        _newTargetPos = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _newTargetPos, _speed);
    }
}
