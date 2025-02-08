using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponController : WeaponController
{

    public Utile utile;

    float previousMouseWheel = 0; // sens de la molette précédant
    int selectedWeapon = 0; //arme courante sélectionnée avec la molette
    private List<Weapon> weapons; //liste des armes que possède le joueur

    private Vector3 mousePos;

    public Vector3 weaponSelectedRotation;
    public Transform playerPosition;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculWeaponDirection();

        //capture le sens de la molette et change d'arme courante en conséquence
        float newMouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if(newMouseWheel != previousMouseWheel){
            switchWeapon();
        }
        previousMouseWheel = newMouseWheel;

        checkWeaponIndex(); //
    }

    private void CalculWeaponDirection()
    {
        mousePos = utile.getMousePos();
        weaponSelectedRotation = new Vector3(0,0,Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg);
    }

    public override Vector3 getWeaponRotation()  
    {
        return weaponSelectedRotation;
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
    }

    private void checkWeaponIndex(){
        /// vérifie si une touche numérique est pressée et change l'arme sélectionnée en fonction
        /// 
        for (int i = 0; i <= 9; i++) {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i))){
                if(i != selectedWeapon && i < 5){ // TODO : changer 5 par weapons.Count
                    selectedWeapon = i;
                }
            }
        }
    }
}
