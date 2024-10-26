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
            _max++;
        }

        public void Remove()
        {
            _counter++;

            var prog = (float)_counter * (_sprites.Length - 1) / _max;
            _bg.sprite = _sprites[Mathf.FloorToInt(prog)];
        }


        // http://answers.unity.com/answers/502236/view.html
        public static Bounds CalculateBounds(Camera cam)
        {
            float screenAspect = Screen.width / (float)Screen.height;
            float cameraHeight = cam.orthographicSize * 2;
            Bounds bounds = new(
                cam.transform.position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }
    }
}