using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourGameJam.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2 _mov;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _mov * 2f;
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>();
        }
    }
}
