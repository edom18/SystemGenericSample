using System.Collections.Generic;
using UnityEngine;

public static class SystemStore
{
    private static Dictionary<System.Type, ISystem> s_dict = new();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Register()
    {
        var hoge = new HogeSystem();
        var fuga = new FugaSystem();
        s_dict.Add(typeof(HogeSystem), hoge);
        s_dict.Add(typeof(FugaSystem), fuga);
    }
    
    public static T GetSystem<T>() where T : class, ISystem
    {
        System.Type type = typeof(T);
        if (s_dict.TryGetValue(type, out ISystem system))
        {
            return system as T;
        }

        return null;
    }
}
