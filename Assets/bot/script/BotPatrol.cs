using System;
using UnityEngine;

public class BotMovement : Character
{   
    public float speed = 2f; // Vitesse du personnage

    public Transform[] waypoints; // Liste des waypoints

    public Transform player;
    private Transform target;
    private int targetIndex = 0;
    

    protected override void Start()
    {
        base.Start(); 
        target = waypoints[0]; 
        
    }

    private void FixedUpdate() {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        // si le joueur est proche, il devient la cible
        if (distanceToPlayer < 2f)
            target = player;
        else if (Vector2.Distance(transform.position, target.position) < 0.2f && target != player) // sinon si il atteint un waypoint, on passe au suivant
        {
            targetIndex = (targetIndex + 1) % waypoints.Length;
            target = waypoints[targetIndex];
        }

        // déterminer la meilleure direction (horizontale ou vertiale)
        float deltaX = target.position.x - transform.position.x;
        float deltaY = target.position.y - transform.position.y;
        
        Vector2 direction = Mathf.Abs(deltaX) > Mathf.Abs(deltaY) 
            ? new Vector2(Mathf.Sign(deltaX), 0)  // (-1,0) ou (1,0)
            : new Vector2(0, Mathf.Sign(deltaY)); // (0,-1) ou (0,1)


        // on applique le déplacement dans la meilleur direction
        body.MovePosition(body.position + speed * Time.fixedDeltaTime * direction);
    }



}
