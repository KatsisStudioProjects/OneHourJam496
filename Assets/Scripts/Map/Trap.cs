using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneHourGameJam.Map
{
    public class Trap : AAI
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
