using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Reycaster _reycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _reycaster.CubeClicked += HandleCubeClick;
    }

    private void OnDisable()
    { 
        _reycaster.CubeClicked -= HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
    {
        float randomValue = Random.value;

        if (randomValue <= cube.SplitChance)
        {
            List<Cube> createdCubes = _spawner.SpawnSplittedCubes(cube);
            IEnumerable<Rigidbody> rigidbodies = createdCubes.Select(c => c.Rigidbody);
            
            _exploder.ExplodeWithDivision(cube.transform.position, rigidbodies);
        }
		else
		{
			_exploder.ExplodeWithoutDivision(cube.transform.position, cube);
		}

        _spawner.DestroyCube(cube);
    }
}
