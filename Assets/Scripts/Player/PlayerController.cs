using OneHourGameJam.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourGameJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2 _mov;
        private Camera _cam;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cam = Camera.main;
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _mov * 2f;
            var bounds = GameManager.CalculateBounds(_cam);
            if (transform.position.x > bounds.max.x) transform.position = new(bounds.max.x, transform.position.y);
            if (transform.position.x < bounds.min.x) transform.position = new(bounds.min.x, transform.position.y);
            if (transform.position.y > bounds.max.y) transform.position = new(transform.position.x, bounds.max.y);
            if (transform.position.y < bounds.min.y) transform.position = new(transform.position.x, bounds.min.y);
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>();
        }
    }
}
