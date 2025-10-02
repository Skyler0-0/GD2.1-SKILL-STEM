using UnityEngine;
using UnityEngine.UIElements;

public class JumpingBlock : MonoBehaviour
{
    [SerializeField] private Vector3 gravityBegin = new Vector3 (0, -1, 0);
    [SerializeField] private Transform Block;
    [SerializeField] private Vector3 velocityBegin = new Vector3(0, 3, 0);
    private float yBegin;
    private Vector3 Velocity;
    private Vector3 gravity;

    [SerializeField]private float t = 0;
    enum State { ground, airborn};
    State myState = State.ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yBegin = Block.position.y;
        Velocity = velocityBegin;
    }

    // Update is called once per frame
    void Update()
    {
        Block.position += Velocity * Time.deltaTime;
        Velocity += gravity * Time.deltaTime;

        if (myState == State.ground )
        {
            Velocity = Vector3.zero;
            gravity = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                t = 0;
                myState = State.airborn;
                Velocity = velocityBegin;
                gravity = gravityBegin;
            }
        }

        if ( myState == State.airborn )
        {
            t += Time.deltaTime;
            if (Block.position.y < yBegin)
            {
                myState = State.ground;
                Velocity = Vector3.zero;
                gravity = Vector3.zero;
                Block.position = new Vector3(Block.position.x, yBegin, 0);
            }
            
        }
    }
}
