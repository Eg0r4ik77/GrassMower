using System.Collections.Generic;
using Enemies.Spawn;
using UnityEngine;
using Zenject;

public class GrassSpawner
{
    private readonly GrassPoolsProvider _enemyPoolsProvider;

    [Inject]
    public GrassSpawner(GrassPoolsProvider enemyPoolsProvider)
    {
        _enemyPoolsProvider = enemyPoolsProvider;
    }

    public Grass Spawn(GrassType type, Vector3 position)
    {
        GrassPool pool = _enemyPoolsProvider.Get(type);
        Grass grass = (Grass)pool.Get();

        grass.transform.position = position;
        grass.gameObject.SetActive(true);

        return grass;
    }
}    