
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float aggroRange = 5f;
    public float speed = 2f;
    public float jumpCooldown = 2f;
    public float jumpForce = 5f;

    public Animations animations;

    private float lastJump;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null) return;

        if (Vector2.Distance(player.transform.position, transform.position) < aggroRange)
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);

                if (animator != null && animations.goLeft != null)
                {
                    animator.Play(animations.goLeft.name);
                }
            }
            else
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);

                if (animator != null && animations.goRight != null)
                {
                    animator.Play(animations.goRight.name);
                }
            }

            if (Time.time > lastJump + jumpCooldown)
            {
                lastJump = Time.time;

                if (rb != null)
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }
        else
        {
            if (animator != null)
            {
                animator.Play("Idle");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerScript = collision.collider.GetComponent<PlayerController>();

        if (playerScript != null)
        {
            playerScript.Die();
        }
    }

    [System.Serializable]
    public struct Animations
    {
        public AnimationClip goLeft;
        public AnimationClip goRight;
    }
}
