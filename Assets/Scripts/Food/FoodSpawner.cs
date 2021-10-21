using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private List<Food> _foods;

    private List<Food> _spawnedFoods = new List<Food>();

    private void Start()
    {
        Spawn();
        StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            var index = Random.Range(i, _foods.Count);
            _foods[index].gameObject.SetActive(true);
            _spawnedFoods.Add(_foods[index]);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => _spawnedFoods.Count == 0);
            Spawn();
        }
    }

    public void RemoveEatenFood(Food food)
    {
        _spawnedFoods.Remove(food);
    }
}
