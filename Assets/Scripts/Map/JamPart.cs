using OneHourGameJam.Manager;
using UnityEngine;

namespace OneHourGameJam.Map
{
    public class JamPart : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.Remove();
        }
    }
}
