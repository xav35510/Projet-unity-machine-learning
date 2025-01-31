using UnityEngine;

public class Player : Character
{   
    private float speed = 4f; // vitesse du personnage
    private Vector2 direction; // vecteur de direction du personnage

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        if (direction.magnitude > 0)
        {
            direction.Normalize();
        }
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
    }

    protected override void Attack(){
        // TODO

    }
}
