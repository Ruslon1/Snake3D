using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SnakeHead : MonoBehaviour
{
    [SerializeField] private List<SnakeBone> _bones;
    [SerializeField] private Snake _snake;

    public List<SnakeBone> Bones => _bones; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
            _snake.EatFood(food);

        if (other.TryGetComponent(out Wall wall))
            _snake.DeleteLastBone(ref _bones);
    }

    public IEnumerator DisableMeshRendererForBonesWhile(float time)
    {
        _bones.ForEach(i => i.DisableMeshRenderer());

        yield return new WaitForSeconds(time);

        _bones.ForEach(i => i.EnabledMeshRenderer());
    }

    public void AddBonesToArray(SnakeBone bone)
    {
        _bones.Add(bone);
    }
}