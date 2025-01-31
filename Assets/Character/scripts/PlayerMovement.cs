using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character
{   
    private float speed = 4f; // vitesse du personnage
    private Vector2 direction; // vecteur de direction du personnage
    float previousMouseWheel = 0; // sens de la molette précédant
    int selectedWeapon = 0; //arme courante sélectionnée avec la molette
    private List<Weapon> weapons; //liste des armes que possède le joueur

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


        //capture le sens de la molette et change d'arme courante en conséquence
        float newMouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if(newMouseWheel != previousMouseWheel){
            switchWeapon();
        }
        previousMouseWheel = newMouseWheel;

        checkWeaponIndex(); //

    }

    //getter
    public bool getIsMoving() 
    {
        return isMoving;
    }
    public Vector2 getDirection()
    {
        return direction;
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime); 
    }

    protected override void Attack(){
        // TODO

    }

    private void switchWeapon(){
        /// change d'arme dans la liste des armes dans le sens de la molette
        if(previousMouseWheel > 0){
            selectedWeapon++;
        }
        else if(previousMouseWheel < 0) {
            selectedWeapon--;
        }
        selectedWeapon %= 5; // TODO : changer 5 par weapons.Count
        print(selectedWeapon);
    }

    private void checkWeaponIndex(){
        /// vérifie si une touche numérique est pressée et change l'arme sélectionnée en fonction
        /// 
        for (int i = 0; i <= 9; i++) {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i))){
                if(i != selectedWeapon && i < 5){ // TODO : changer 5 par weapons.Count
                    selectedWeapon = i;
                    print(selectedWeapon);
                }
            }
        }
    }
}
