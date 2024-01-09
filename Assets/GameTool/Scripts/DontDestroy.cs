

// ReSharper disable once CheckNamespace
namespace GameTool
{
    public class DontDestroy : SingletonMonoBehaviour<DontDestroy>
    {
        protected override void Awake()
        {
            if (Exists())
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
