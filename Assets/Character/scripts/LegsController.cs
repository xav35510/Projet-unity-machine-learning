using UnityEngine;
using System.Collections;

public class LegsController : MonoBehaviour
{

    public Utile utile;
    public Animator legsAnimation;
    public PlayerMovement playerMovement;
    public SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        getDirection();
        getState();
        directionTorso();
    }


    //récupère les déplacements du personnages pour faire tourner les jambes
    private void getDirection()
    {
        
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

    private void directionTorso()
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
            legsAnimation.SetFloat("verticalMovement", 1);
        }
        else if(playerMovement.getDirection().y > 0)
        {
            legsAnimation.SetFloat("verticalMovement", -1);
        }
        else
        {
            legsAnimation.SetFloat("verticalMovement", 0);
        }
        
    }


}
