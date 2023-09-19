using System;
using UnityEngine;

public class GrassMower : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    
    [SerializeField] private float _rotationMaxDegreesDelta = 6f;
    [SerializeField] private float _maxAngleBeforeStop = 45f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    public void Mow(Grass grass)
    {
        grass.Destroy();
    }

    public void TryMove(Vector3 direction)
    {
        bool rotated = Rotate(direction);

        if (rotated)
        {
            Vector3 speedVector = _speed * transform.forward;
            _characterController.SimpleMove(speedVector);
        }
    }

    private bool Rotate(Vector3 direction)
    {
        Quaternion transformRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        transform.rotation = 
            Quaternion.RotateTowards( transformRotation, targetRotation, _rotationMaxDegreesDelta);

        bool rotatedToMovementDirection =
            Quaternion.Angle(transformRotation, targetRotation) < _maxAngleBeforeStop;

        return rotatedToMovementDirection;
    }
}