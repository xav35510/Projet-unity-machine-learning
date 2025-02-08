using UnityEngine;


public class Laser_Riffle : Weapon
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponDirection();
        spriteManager();
    }

    public override void shot()
    {
    }


    public override void reload()
    {
    }
}