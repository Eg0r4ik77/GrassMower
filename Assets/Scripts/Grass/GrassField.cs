using UnityEngine;
using Zenject;

public class GrassField : MonoBehaviour
{
    [SerializeField] private GrassType _type;
    [SerializeField] private float _distanceBetweenInstances;

    private GrassSpawner _spawner;

    private MeshRenderer _meshRenderer;
    private Vector2 _size;

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
        Vector3 size = _meshRenderer.bounds.extents;

        for (float i = -size.x; i < size.x; i += _distanceBetweenInstances)
        {
            for (float j = -size.z; j < size.z; j += _distanceBetweenInstances)
            {
                Vector3 spawnPosition = new Vector3(i, 0, j);
                _spawner.Spawn(_type, spawnPosition);
            }
        }
    }

}