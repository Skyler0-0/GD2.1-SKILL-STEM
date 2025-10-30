using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    [SerializeField] float vbegin = 4;
    [SerializeField] float g = -5;
    Animator animator;
    enum State { running, jumping };
    State myState = State.running;

    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    float tmax = 0.867f;
    float t = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (myState == State.running)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myState = State.jumping;
                t = 0;
                g = -2 * vbegin / tmax;
                velocity = new Vector3(0, vbegin, 0);
                acceleration = new Vector3(0, g, 0);
                animator.Play("jump");
            }
        }
        else if (myState == State.jumping)
        {
            t += Time.deltaTime;
            if (t >= tmax)
            {
                myState = State.running;
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
                animator.Play("run");
            }
        }
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}