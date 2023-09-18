using UnityEngine;
using Zenject;

public class GrassField : MonoBehaviour
{
    [SerializeField] private GrassType _type;
    [SerializeField] private float _distanceBetweenInstances;

    private GrassSpawner _spawner;
    private MeshRenderer _meshRenderer;

    [Inject]
    private void Construct(GrassSpawner spawner)
    {
        _spawner = spawner;
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        SetGrass();
    }
    
    private void SetGrass()
    {
        Vector3 extents = _meshRenderer.bounds.extents;

        for (float x = -extents.x; x < extents.x; x += _distanceBetweenInstances)
        {
            for (float z = -extents.z; z < extents.z; z += _distanceBetweenInstances)
            {
                Vector3 spawnPosition = new Vector3(x, 0, z);
               _spawner.Spawn(_type, spawnPosition);
            }
        }
    }
}