using UnityEngine;
using System.Collections;

public class LegsController : MonoBehaviour
{

    public Utile utile;
    public Animator legsAnimation;
    public PlayerMovement playerMovement;
    public SpriteRenderer sprite;
    public float mouseAngle;

    // Update is called once per frame
    void Update()
    {
        getState();
        getDirection();
        if(playerMovement.getIsMoving())
        {
            directionRunLegs();
        }
        else
        {
            directionIdleLegs();
        }
    }

    //récupère l'emplacement de la souris pour faire tourner le personnage
    private void getDirection()
    {
        mouseAngle = utile.getMouseAngle();
    }

    //récupère l'info de si le joueur bouge ou pas (idle ou run)
    private void getState()
    {
        if(playerMovement.getIsMoving())
        {
            legsAnimation.SetFloat("state", 1);
        }
        else
        {
            legsAnimation.SetFloat("state", 0);
        }
    }

    private void directionRunLegs()
    {
        if(playerMovement.getDirection().x > 0)
        {
            legsAnimation.SetFloat("horizontalMovement", 1);
            sprite.flipX = true;
        }
        else if(playerMovement.getDirection().x < 0)
        {
            legsAnimation.SetFloat("horizontalMovement", -1);
            sprite.flipX = false;
        }
        else
        {
            legsAnimation.SetFloat("horizontalMovement", 0);
            sprite.flipX = false;
        }

        if(playerMovement.getDirection().y < 0)
        {
            legsAnimation.SetFloat("verticalMovement", -1);
        }
        else if(playerMovement.getDirection().y > 0)
        {
            legsAnimation.SetFloat("verticalMovement", 1);
        }
        else
        {
            legsAnimation.SetFloat("verticalMovement", 0);
        }
        
    }

    private void directionIdleLegs()
    {

        if(mouseAngle < 1.5 && mouseAngle > -1.5)
        {
            sprite.flipX =true;
        }
        else
        {
            sprite.flipX =false;
        }
    if((mouseAngle > -0.25f && mouseAngle < 0.25f)) // Droite
    {
        legsAnimation.SetFloat("horizontal", 1);
        legsAnimation.SetFloat("vertical", 0);
    }
    else if(mouseAngle > 0.25f && mouseAngle < 0.75f) // Droite-Haut-Droite
    {
        legsAnimation.SetFloat("horizontal", 0.875f );
        legsAnimation.SetFloat("vertical", 0.5f );
    }
    else if(mouseAngle > 0.75f && mouseAngle < 1.25f) // Haut-Droite
    {
        legsAnimation.SetFloat("horizontal", 0.5f );
        legsAnimation.SetFloat("vertical", 0.875f );
    }
    else if(mouseAngle > 1.125f && mouseAngle < 1.75f) // Haut
    {
        legsAnimation.SetFloat("horizontal", 0 );
        legsAnimation.SetFloat("vertical", 1 );
    }
    else if(mouseAngle > 1.75f && mouseAngle < 2.25f) // Haut-Gauche
    {
        legsAnimation.SetFloat("horizontal", -0.5f);
        legsAnimation.SetFloat("vertical", 0.875f);
    }
    else if(mouseAngle > 2.25f && mouseAngle < 2.75f) // Gauche-Haut-Gauche
    {
        legsAnimation.SetFloat("horizontal", -0.875f);
        legsAnimation.SetFloat("vertical", 0.5f);
    }
    else if(mouseAngle > 2.75f || mouseAngle < -2.75f) // Gauche
    {
        legsAnimation.SetFloat("horizontal", -1);
        legsAnimation.SetFloat("vertical", 0);
    }
    else if(mouseAngle > -2.75f && mouseAngle < -2.25) // Gauche-Bas-Gauche
    {
        legsAnimation.SetFloat("horizontal", -0.875f);
        legsAnimation.SetFloat("vertical", -0.5f);
    }
    else if(mouseAngle > -2.25f && mouseAngle < -1.75f) // Bas-Gauche
    {
        legsAnimation.SetFloat("horizontal", -0.5f);
        legsAnimation.SetFloat("vertical", -0.875f);
    }
    else if(mouseAngle >= -1.75f && mouseAngle < -1.25f) // Bas
    {
        legsAnimation.SetFloat("horizontal", 0);
        legsAnimation.SetFloat("vertical", -1);
    }
    else if(mouseAngle > -1.25f && mouseAngle < -0.75f) // Bas-Droite
    {
        legsAnimation.SetFloat("horizontal", 0.5f);
        legsAnimation.SetFloat("vertical", -0.866f);
    }
    else if(mouseAngle >= -0.75f && mouseAngle < -0.25f) // Droite-Bas-Droite
    {
        legsAnimation.SetFloat("horizontal", 0.875f);
        legsAnimation.SetFloat("vertical", -0.5f);
    }
    }


}
