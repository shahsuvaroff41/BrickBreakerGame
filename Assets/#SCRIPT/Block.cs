using UnityEngine;

namespace _SCRIPT
{
    public class Block : MonoBehaviour
    {
        public Color[] colors;
        public int hp;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ball"))
            {
                hp--;
                if (colors.Length > 0 && hp > 0) { this.GetComponent<SpriteRenderer>().color = colors[ hp-1 ]; }
                if (hp == 0) { Destroy(this.gameObject); }
            }
        }
    }
}