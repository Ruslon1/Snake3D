using UnityEngine;

public interface IMovable
{
    void Move(Vector3 to);
    void TryRotate(float coefficent);
}