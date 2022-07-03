using UnityEngine;

public class ManagerBase<TSystem> : MonoBehaviour
    where TSystem : ASystem<TSystem>, new()
{
    protected TSystem system { get; private set; }

    private void Awake()
    {
        system = GetSystem();
    }

    private TSystem GetSystem()
    {
        return SystemStore.GetSystem<TSystem>();
    }
}
