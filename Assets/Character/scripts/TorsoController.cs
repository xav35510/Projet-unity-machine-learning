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
    if((mouseAngle >= -0.375f && mouseAngle < 0.375f)) // Droite
    {
        torsoAnimation.SetFloat("horizontal", 1);
        torsoAnimation.SetFloat("vertical", 0);
        legsAnimation.SetFloat("horizontal", 1);
        legsAnimation.SetFloat("vertical", 0);
    }
    else if(mouseAngle >= 0.375f && mouseAngle < 1.125f) // Haut-Droite
    {
        torsoAnimation.SetFloat("horizontal", 0.75f);
        torsoAnimation.SetFloat("vertical", 0.75f);
        legsAnimation.SetFloat("horizontal", 0.75f);
        legsAnimation.SetFloat("vertical", 0.75f);
    }
    else if(mouseAngle >= 1.125f && mouseAngle < 1.875f) // Haut
    {
        torsoAnimation.SetFloat("horizontal", 0);
        torsoAnimation.SetFloat("vertical", 1);
        legsAnimation.SetFloat("horizontal", 0);
        legsAnimation.SetFloat("vertical", 1);
    }
    else if(mouseAngle >= 1.875f && mouseAngle < 2.625f) // Haut-Gauche
    {
        torsoAnimation.SetFloat("horizontal", -0.75f);
        torsoAnimation.SetFloat("vertical", 0.75f);
        legsAnimation.SetFloat("horizontal", -0.75f);
        legsAnimation.SetFloat("vertical", 0.75f);
    }
    else if((mouseAngle >= 2.625f && mouseAngle <= 3.0f) || (mouseAngle >= -3.0f && mouseAngle < -2.625f)) // Gauche
    {
        torsoAnimation.SetFloat("horizontal", -1);
        torsoAnimation.SetFloat("vertical", 0);
        legsAnimation.SetFloat("horizontal", -1);
        legsAnimation.SetFloat("vertical", 0);
    }
    else if(mouseAngle >= -2.625f && mouseAngle < -1.875f) // Bas-Gauche
    {
        torsoAnimation.SetFloat("horizontal", -0.75f);
        torsoAnimation.SetFloat("vertical", -0.75f);
        legsAnimation.SetFloat("horizontal", -0.75f);
        legsAnimation.SetFloat("vertical", -0.75f);
    }
    else if(mouseAngle >= -1.875f && mouseAngle < -1.125f) // Bas
    {
        torsoAnimation.SetFloat("horizontal", 0);
        torsoAnimation.SetFloat("vertical", -1);
        legsAnimation.SetFloat("horizontal", 0);
        legsAnimation.SetFloat("vertical", -1);
    }
    else if(mouseAngle >= -1.125f && mouseAngle < -0.375f) // Bas-Droite
    {
        torsoAnimation.SetFloat("horizontal", 0.75f);
        torsoAnimation.SetFloat("vertical", -0.75f);
        legsAnimation.SetFloat("horizontal", 0.75f);
        legsAnimation.SetFloat("vertical", -0.75f);
    }
    }

}
