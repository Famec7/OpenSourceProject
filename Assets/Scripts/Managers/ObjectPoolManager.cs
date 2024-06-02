using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    private List<Component> _objectPool;
    
    protected override void Init()
    {
        _objectPool = new List<Component>();
    }
    
    /// <summary>
    /// 오브젝트 풀에 오브젝트 추가
    /// </summary>
    /// <param name="prefab"> 추가할 오브젝트 </param>
    /// <param name="count"> 추가할 오브젝트 개수 </param>
    /// <param name="parent"> 오브젝트 부모</param>
    /// <typeparam name="Component"></typeparam>
    /// <returns></returns>
    public void CreateObjectPool(Component prefab, int count, Transform parent = null)
    {
        for (int i = 0; i < count; i++)
        {
            Component obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(parent);
            _objectPool.Add(obj);
        }
    }
    
    /// <summary>
    /// 오브젝트 풀에서 사용 가능한 오브젝트를 반환
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns> 컴포넌트로 반환 </returns>
    public T GetObject<T>(string name) where T : Component
    {
        foreach (var obj in _objectPool)
        {
            if (obj is not (T { gameObject: { activeSelf: false } } t and IPool pool)) continue;
            if (pool.Name != name) continue;
            
            pool.GetFromPool();
            t.gameObject.SetActive(true);

            return t;
        }
        
        return null;
    }
    
    /// <summary>
    /// 오브젝트 풀에 오브젝트 반환
    /// </summary>
    /// <param name="obj"> 반환할 오브젝트 </param>
    public void ReturnObject(Component obj)
    {
        if (obj is not IPool pool) return;
        
        pool.ReturnToPool();
        obj.gameObject.SetActive(false);
    }
    
    public void ClearPool()
    {
        foreach (var obj in _objectPool)
        {
            if (obj is not IPool pool) continue;
            
            pool.ReturnToPool();
            Destroy(obj.gameObject);
        }
        
        _objectPool.Clear();
    }
}