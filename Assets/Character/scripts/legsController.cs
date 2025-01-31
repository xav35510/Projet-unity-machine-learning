using UnityEngine;
using System.Collections;

public class legsController : MonoBehaviour
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
            legsAnimation.SetFloat("horizontal", 1);
        }
        if(playerMovement.getDirection().x < 0)
        {
            legsAnimation.SetFloat("horizontal", 0);
        }
        if(playerMovement.getDirection().y < 0)
        {
            legsAnimation.SetFloat("vertical", -1);
        }
        if(playerMovement.getDirection().y < 0)
        {
            legsAnimation.SetFloat("vertical", -0.5f);
        }
        
    }

}
