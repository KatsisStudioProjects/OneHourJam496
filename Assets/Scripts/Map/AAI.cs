using OneHourGameJam.Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace OneHourGameJam.Map
{
    public class AAI : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private Camera _cam;

        private float _dirTimer;

        protected virtual void Awake()
        {
            _cam = Camera.main;
            _rb = GetComponent<Rigidbody2D>();

            SetDir();
        }

        private void SetDir()
        {
            _dirTimer = 2f;
            _rb.linearVelocity = Random.insideUnitCircle.normalized * 4f;
        }

        private void Update()
        {
            _dirTimer -= Time.deltaTime;
            if (_dirTimer <= 0f)
            {
                SetDir();
            }

            var bounds = GameManager.CalculateBounds(_cam);
            if (transform.position.x > bounds.max.x) { transform.position = new(bounds.max.x, transform.position.y); SetDir(); }
            if (transform.position.x < bounds.min.x) { transform.position = new(bounds.min.x, transform.position.y); SetDir(); }
            if (transform.position.y > bounds.max.y) { transform.position = new(transform.position.x, bounds.max.y); SetDir(); }
            if (transform.position.y < bounds.min.y) { transform.position = new(transform.position.x, bounds.min.y); SetDir(); }
        }
    }
}
