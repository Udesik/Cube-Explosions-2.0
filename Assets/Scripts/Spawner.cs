using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _minAmount = 2;
    [SerializeField] private int _maxAmount = 7;
    [SerializeField] private float _scaleMultiplier = 0.5f;
    [SerializeField] private float _chanceMultiplier = 0.5f;

    public List<Cube> SpawnSplittedCubes(Cube parentCube)
    {
        int count = Random.Range(_minAmount, _maxAmount);
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_prefab, parentCube.transform.position, Quaternion.identity);
            
            Vector3 newScale = parentCube.transform.localScale * _scaleMultiplier;
            float newChance = parentCube.SplitChance * _chanceMultiplier;
            
            newCube.Init(newChance, newScale);
            newCubes.Add(newCube);
        }

        return newCubes;
    }
    
    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
