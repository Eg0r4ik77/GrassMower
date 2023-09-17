using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Grass/Factory")]
public class GrassPrefabs : ScriptableObject
{
    [SerializeField] private List<Grass> _grassPrefabs;

    public T Get<T>() where T : Grass
    {
        var enemyPrefab = (T)_grassPrefabs.FirstOrDefault(enemy => enemy is T);
        return enemyPrefab;
    }
}