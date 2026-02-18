using System;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void ExplodeWithDivision(Vector3 position, IEnumerable<Rigidbody> targets)
    {
        foreach (Rigidbody rb in targets)
        {
            rb.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }

    public void ExplodeWithoutDivision(Vector3 position, Cube cube)
    {
		float magnificationFactor = 1 / cube.transform.localScale.x;
        float explosionForce = _explosionForce * magnificationFactor;
		float explosionRadius = _explosionRadius * magnificationFactor;

		Collider[] colliders = Physics.OverlapSphere(position, explosionRadius);
		foreach (Collider col in colliders)
        {
           	Rigidbody rb = col.attachedRigidbody;

           	rb.AddExplosionForce(explosionForce, position, explosionRadius);
       	}
    }
}
