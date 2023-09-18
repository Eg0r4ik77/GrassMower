using UnityEngine;

namespace Enemies.Spawn
{
    public class GrassPool : MonoBehaviourObjectsPool
    {
        private readonly GrassType _type;
        private readonly GrassFactory _grassFactory;

        public GrassPool(GrassType type, Transform rootTransform, GrassFactory grassFactory) : base(rootTransform)
        {
            _type = type;
            _grassFactory = grassFactory;
        }

        protected override IPoolObject Create()
        {
            Grass grass = _grassFactory.Create(_type);

            grass.ReturnedToPool += Release;
            
            AttachToRoot(grass.transform);
            Release(grass);

            return grass;
        }
    }
}