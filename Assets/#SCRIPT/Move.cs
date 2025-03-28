using UnityEngine;

namespace _SCRIPT
{
    public class Move : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            var speedX = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.Translate(speedX, 0, 0);
            var xlimit = Mathf.Clamp(transform.position.x, -7.76f, 7.76f);
            transform.position = new Vector2(xlimit, transform.position.y);
        }
    }
}