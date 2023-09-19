using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private GrassMower _grassMower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Grass grass))
        { 
            _grassMower.Mow(grass);
        }
    }
}