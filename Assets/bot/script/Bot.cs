using UnityEngine;

public class Bot : Character
{   
    private float speed = 3f; // vitesse du personnage
    private Vector2 direction; // vecteur de direction du personnage

    private void Update()
    {
           
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        
    }

    protected override void Attack(){
        // TODO

    }
}
