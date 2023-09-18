using UnityEngine;

public class TargetFollow : MonoBehaviour
{
   [SerializeField] private Transform _target;

   private Vector3 _offset;

   private void Start()
   {
      _offset = _target.position - transform.position;
   }

   private void Update()
   {
      transform.position = _target.position - _offset;
   }
}
