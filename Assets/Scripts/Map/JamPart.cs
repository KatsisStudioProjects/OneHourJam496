﻿using OneHourGameJam.Manager;
using System.Collections;
using UnityEngine;

namespace OneHourGameJam.Map
{
    public class JamPart : MonoBehaviour
    {
        [SerializeField]
        private Sprite _explosion;

        private Collider2D _coll;
        private SpriteRenderer _sr;

        private Camera _cam;

        private void Awake()
        {
            _coll = GetComponent<Collider2D>();
            _sr = GetComponent<SpriteRenderer>();
            _cam = Camera.main;
        }

        private void Start()
        {
            GameManager.Instance.Register();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.Remove();
            StartCoroutine(Explode());
        }

        private IEnumerator Explode()
        {
            _coll.enabled = false;
            _sr.sprite = _explosion;
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
}
