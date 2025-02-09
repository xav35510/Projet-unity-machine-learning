using UnityEngine;

public class PlayerMovement : Character
{
    public float speed = 7f; // vitesse du personnage
    private Vector2 direction; // vecteur de direction du personnage

    private bool isMoving; //utile

    private void Update()
    {   
        //capture les déplacement du joueur
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        if (direction.magnitude > 0)
        {
            direction.Normalize(); // normalise le vecteur pour éviter les accélérations
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }

    //getter
    public override bool getIsMoving() 
    {
        return isMoving;
    }
    public Vector2 getDirection()
    {
        return direction;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime); 
    }
}
