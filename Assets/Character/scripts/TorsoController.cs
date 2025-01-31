using UnityEngine;

public class torsoController : MonoBehaviour
{

    public Utile utile;
    public Animator torsoAnimation, legsAnimation;
    public PlayerMovement playerMovement;
    public float mouseAngle;
    public SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        getDirection();
        getState();
        directionTorso();
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
            torsoAnimation.SetFloat("state", 1);
        }
        else
        {
            torsoAnimation.SetFloat("state", 0);
        }
    }

    private void directionTorso()
    {
        if(mouseAngle < 1.5 && mouseAngle > -1.5)
        {
            sprite.flipX =true;
        }
        else
        {
            sprite.flipX =false;
        }

        if((mouseAngle > 0 && mouseAngle < 1) || mouseAngle > 2)
        {
            torsoAnimation.SetFloat("horizontal", 1);
            torsoAnimation.SetFloat("vertical", 0.5f);
            legsAnimation.SetFloat("horizontal", 1);
            legsAnimation.SetFloat("vertical", 0.5f);
        }
        if(mouseAngle > 1 && mouseAngle < 2)
        {
            torsoAnimation.SetFloat("horizontal", 0);
            torsoAnimation.SetFloat("vertical", 1);
            legsAnimation.SetFloat("horizontal", 0);
            legsAnimation.SetFloat("vertical", 1);
        }
        if(mouseAngle > -2 && mouseAngle < -1)
        {
            torsoAnimation.SetFloat("horizontal", 0);
            torsoAnimation.SetFloat("vertical", -1);
            legsAnimation.SetFloat("horizontal", 0);
            legsAnimation.SetFloat("vertical", -1);
        }
        if((mouseAngle > -1 && mouseAngle < 0) || mouseAngle < -2)
        {
            torsoAnimation.SetFloat("horizontal", 1);
            torsoAnimation.SetFloat("vertical", -0.5f);
            legsAnimation.SetFloat("horizontal", 1);
            legsAnimation.SetFloat("vertical", -0.5f);
        }
        
    }

}
