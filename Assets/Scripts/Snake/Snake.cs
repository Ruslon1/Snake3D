using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Snake : MonoBehaviour, IMovable
{
    [SerializeField] private FoodSpawner _spawner;
    [SerializeField] private SnakeBoneAdder _boneAdder;
    [SerializeField] private ScoreCounter _scoreCounter;

    public event UnityAction<Food> Eat;

    private void OnEnable()
    {
        Eat += OnEaten;
        Eat += _spawner.RemoveEatenFood;
    }
    
    private void OnDisable()
    {
        Eat -= OnEaten;
        Eat -= _spawner.RemoveEatenFood;
    }

    public void Move(Vector3 to)
    {
        transform.position = to;
    }

    public void TryRotate(float coefficent)
    {
        transform.Rotate(0, coefficent * 2f, 0);
    }

    public void EatFood(Food food)
    {
        Eat?.Invoke(food);
    }

    public void DeleteLastBone(ref List<SnakeBone> bones)
    {
        Destroy(bones[bones.Count - 1].gameObject);
        bones.Remove(bones[bones.Count - 1]);
    }

    private void OnEaten(Food food)
    {
        food.gameObject.SetActive(false);
        _boneAdder.AddSnakeBone();
        _scoreCounter.AddScore();
    }
}