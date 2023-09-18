using UnityEngine;

public class GrassMower : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Grass grass))
        { 
            Mow(grass);
        }
    }

    public void TryMove(Vector3 direction)
    {
        bool rotated = Rotate(direction);

        if (rotated)
        {
            _characterController.SimpleMove(_speed * transform.forward);
        }
    }

    private bool Rotate(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = Quaternion.RotateTowards( transform.rotation,
            targetRotation, 
            1f);

        bool rotated = Quaternion.Angle(transform.rotation, targetRotation) < 180f;

        return rotated;
    }

    private void Mow(Grass grass)
    {
        grass.Destroy();
    }
}