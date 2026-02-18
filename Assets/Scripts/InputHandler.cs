using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action MouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked?.Invoke();
        }
    }
}
