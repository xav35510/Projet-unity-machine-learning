using UnityEngine;

public class BotRaycast : Character {
    public float rayDistance = 3f; // distance du rayon
    public Transform targetTransform; // la cible

    protected override void Start()
    {
        base.Start(); 
        
    }

    private void FixedUpdate() {
        RaycastHit2D hit;

        // Débogage : affiche le rayon sous forme de ligne rouge dans la scène
        Debug.DrawRay(transform.position, transform.up  * rayDistance, Color.red);

        // raycast en vers la droite
        hit = Physics2D.Raycast(transform.position, transform.up , rayDistance);

        // si un objet est détecté
        if (hit.collider != null) {
            if (hit.collider.transform == targetTransform) {
                print("Objet touché : " + hit.collider.name);
            }
        }
    }

    public override bool getIsMoving()
    {
        return true;
    }
}
