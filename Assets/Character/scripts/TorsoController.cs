using UnityEngine;

public class torsoController : MonoBehaviour
{

    public Utile utile;
    public Animator torsoAnimation, legsAnimation;
    public PlayerMovement playerMovement;
    public float mouseAngle;
    public SpriteRenderer sprite;
    private float startingFrame;
    private int animationState, previousAnimationState;

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
        previousAnimationState = animationState;

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
        animationState = 1;
        torsoAnimation.SetFloat("horizontal", 1);
        torsoAnimation.SetFloat("vertical", 0);
    }
    else if(mouseAngle > 0.25f && mouseAngle < 0.75f) // Droite-Haut-Droite
    {
        animationState = 2;
        torsoAnimation.SetFloat("horizontal", 0.875f );
        torsoAnimation.SetFloat("vertical", 0.5f );
    }
    else if(mouseAngle > 0.75f && mouseAngle < 1.25f) // Haut-Droite
    {
        animationState = 3;
        torsoAnimation.SetFloat("horizontal", 0.5f );
        torsoAnimation.SetFloat("vertical", 0.875f );
    }
    else if(mouseAngle > 1.125f && mouseAngle < 1.75f) // Haut
    {
        animationState = 4;
        torsoAnimation.SetFloat("horizontal", 0 );
        torsoAnimation.SetFloat("vertical", 1 );
    }
    else if(mouseAngle > 1.75f && mouseAngle < 2.25f) // Haut-Gauche
    {
        animationState = 5;
        torsoAnimation.SetFloat("horizontal", -0.5f);
        torsoAnimation.SetFloat("vertical", 0.875f);
    }
    else if(mouseAngle > 2.25f && mouseAngle < 2.75f) // Gauche-Haut-Gauche
    {
        animationState = 6;
        torsoAnimation.SetFloat("horizontal", -0.875f);
        torsoAnimation.SetFloat("vertical", 0.5f);
    }
    else if(mouseAngle > 2.75f || mouseAngle < -2.75f) // Gauche
    {
        animationState = 7;
        torsoAnimation.SetFloat("horizontal", -1);
        torsoAnimation.SetFloat("vertical", 0);
    }
    else if(mouseAngle > -2.75f && mouseAngle < -2.25) // Gauche-Bas-Gauche
    {
        animationState = 8;
        torsoAnimation.SetFloat("horizontal", -0.875f);
        torsoAnimation.SetFloat("vertical", -0.5f);
    }
    else if(mouseAngle > -2.25f && mouseAngle < -1.75f) // Bas-Gauche
    {
        animationState = 9;
        torsoAnimation.SetFloat("horizontal", -0.5f);
        torsoAnimation.SetFloat("vertical", -0.875f);
    }
    else if(mouseAngle >= -1.75f && mouseAngle < -1.25f) // Bas
    {
        animationState = 10;
        torsoAnimation.SetFloat("horizontal", 0);
        torsoAnimation.SetFloat("vertical", -1);
    }
    else if(mouseAngle > -1.25f && mouseAngle < -0.75f) // Bas-Droite
    {
        animationState = 11;
        torsoAnimation.SetFloat("horizontal", 0.5f);
        torsoAnimation.SetFloat("vertical", -0.866f);
    }
    else if(mouseAngle >= -0.75f && mouseAngle < -0.25f) // Droite-Bas-Droite
    {
        animationState = 12;
        torsoAnimation.SetFloat("horizontal", 0.875f);
        torsoAnimation.SetFloat("vertical", -0.5f);
    }

    if(animationState != previousAnimationState)
    {
        AnimatorStateInfo info = legsAnimation.GetCurrentAnimatorStateInfo(0);
        startingFrame = info.normalizedTime % 1f;
        torsoAnimation.Play(info.shortNameHash, -1 , startingFrame);
    }
    }

}
