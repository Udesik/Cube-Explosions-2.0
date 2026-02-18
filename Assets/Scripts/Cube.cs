using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    
    private float _splitChance = 1f;
    
    public Rigidbody Rigidbody => _rigidbody;
    public float SplitChance => _splitChance;

    public void Init(float splitChance, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
        _renderer.material.color = Random.ColorHSV();
    }
}
