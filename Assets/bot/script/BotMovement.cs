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

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        body.MovePosition(body.position + speed * Time.fixedDeltaTime * direction);

        // si le joueur s'approche du bot, il le suit
        if(Vector2.Distance(transform.position, player.position) < 2f){
            target = player; 
        }

        // si le bot est arrivé au waypoint
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            targetIndex = (targetIndex + 1) % waypoints.Length; 
            target = waypoints[targetIndex];
        }
    }
}
