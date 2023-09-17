using System.Collections.Generic;
using UnityEngine;

public class GrassField : MonoBehaviour
{
    [SerializeField] private GrassType _type;
    [SerializeField] private float _distanceBetweenInstances;
    [SerializeField] private GrassPrefabs _prefabs;

    private List<Grass> _grassList;
    private GrassFactory _factory;

    private MeshRenderer _meshRenderer;

    private Vector2 _size;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _factory = new GrassFactory(_prefabs);
        SetGrass();

    }

    private void SetGrass()
    {
        Vector3 size = _meshRenderer.bounds.extents;

        for (float i = -size.x; i < size.x; i += _distanceBetweenInstances)
        {
            for (float j = -size.z; j < size.z; j += _distanceBetweenInstances)
            {
                Grass grass = _factory.Create(_type);
                grass.transform.SetParent(transform);
                grass.transform.position = new Vector3(i, 0, j);
            }
        }
    }

}