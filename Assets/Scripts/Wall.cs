using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private BoxCollider _oppositeWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeHead snakeHead))
        {
            snakeHead.transform.parent.position = _oppositeWall.ClosestPoint(snakeHead.transform.position);
            StartCoroutine(snakeHead.DisableMeshRendererForBonesWhile(1f));
        }
    }
}
