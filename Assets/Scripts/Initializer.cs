using UnityEngine;

namespace DefaultNamespace
{
    public class Initializer : MonoBehaviour
    {
        private void Awake()
        {
            TTTCore.Instance.Init();
        }
    }
}