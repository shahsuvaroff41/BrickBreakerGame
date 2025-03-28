using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _SCRIPT
{
    public class Bounche : MonoBehaviour
    {
        public Rigidbody2D ball;
        public float speedH, speedV;

        private void Start()
        {
        }
        private void Update()
        {
            switch (Input.anyKey)
            {
                case true:
                    ball.linearVelocity = new Vector2(0, -speedV);
                    this.enabled = false;
                    break;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("block") || collision.gameObject.CompareTag("Player"))
            {
                var clr = collision.gameObject.GetComponent<SpriteRenderer>().color;
                this.GetComponent<TrailRenderer>().material.color = clr;
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                var d = collision.gameObject.transform.position.x - transform.position.x;
                if (d > 0)
                {
                    ball.linearVelocity = new Vector2(-speedH + (1.12f - d) * speedH / 1.12f, ball.linearVelocity.y);
                }
                if (d < 0)
                {
                    ball.linearVelocity = new Vector2(speedH - (1.12f + d) * speedH / 1.12f, ball.linearVelocity.y);
                }
            }
        }
        private IEnumerator OnTriggerEnter2D(Collider2D collision)
        {
            // ReSharper disable once InvertIf
            if (collision.gameObject.CompareTag("end"))
            {
                yield return new WaitForSeconds(2);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}