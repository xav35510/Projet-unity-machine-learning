using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public Transform weaponRotation;
    public Character owner;
    public WeaponController weaponController;
    public SpriteRenderer sprite;

    public Animator weaponAnimator;

    public abstract void shot();
    public abstract void reload();
    
    public void weaponDirection()
    {
        weaponRotation.eulerAngles = weaponController.getWeaponRotation();
    }

    public void spriteManager()
    {
        if(weaponController.getWeaponRotation().z < 90 && weaponController.getWeaponRotation().z > -90)
        {
            sprite.flipY = false;
        }
        else
        {
            sprite.flipY = true;
        }

        if(weaponController.getWeaponRotation().z > 14.3 && weaponController.getWeaponRotation().z < 157.5)
        {
            sprite.sortingOrder = -2;
        }
        else
        {
            sprite.sortingOrder = 2;
        }

        if(owner.getIsMoving())
        {
            weaponAnimator.SetBool("isRunning", true);
        }
        else
        {
            weaponAnimator.SetBool("isRunning", false);
        }

    }

} 
