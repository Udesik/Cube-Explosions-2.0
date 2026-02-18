using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reycaster : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    
    public event Action<Cube> CubeClicked;

    private void OnEnable()
    {
        _inputHandler.MouseClicked += CreateReycast;
    }

    private void OnDisable()
    {
        _inputHandler.MouseClicked -= CreateReycast;
    }

    private void CreateReycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeClicked?.Invoke(cube);
            }
        }
    }
}
