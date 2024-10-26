using UnityEngine;

namespace OneHourGameJam.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private SpriteRenderer _bg;

        [SerializeField]
        private Sprite[] _sprites;

        private int _counter;
        private int _max;

        private void Awake()
        {
            Instance = this;
        }

        public void Register()
        {
            _counter++;
            _max++;
        }

        public void Remove()
        {
            _counter--;
        }
    }
}