using System.Collections.Generic;

public abstract class Pool
{
    private readonly List<IPoolObject> _objects = new();

    public IPoolObject Get()
    {
        IPoolObject poolObject = GetUnusedObject();

        if (poolObject == null)
        {
            poolObject = Create();
            _objects.Add(poolObject);
        }
        
        return poolObject;
    }

    protected abstract IPoolObject Create();

    protected void Release(IPoolObject poolObject)
    {
        poolObject.Clear();
        poolObject.InUse = false;
    }
    
    private void Add(IPoolObject poolObject)
    {
        _objects.Add(poolObject);
    }

    private IPoolObject GetUnusedObject()
    {
        foreach (IPoolObject poolObject in _objects)
        {
            if (poolObject.InUse == false)
            {
                poolObject.InUse = true;
                return poolObject;
            }
        }

        return null;
    }
}