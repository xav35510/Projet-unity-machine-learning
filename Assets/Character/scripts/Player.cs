using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{   

    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 direction;

    private PlayerInput inputs;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moove();


    }

    void moove(){
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
