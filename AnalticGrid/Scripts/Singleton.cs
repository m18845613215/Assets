using UnityEngine;
using System.Collections;
public class Singleton<T> : MonoBehaviour
where T : Component
{
    private static T _instance;
    public static T Instance {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = (T)obj.AddComponent(typeof(T));
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            //Destroy(gameObject); //不应该直接删除 提醒一下
            Debug.LogError(typeof(T).Name + " = many UnitySingleton");
        }
    }
}