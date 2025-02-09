using UnityEngine;

public class BotRotation : Character {
    private float rotationDelay; // temps avant de tourner
    private float nextRotationTime; // moment où la prochaine rotation doit se produire

    protected override void Start() {
        base.Start();
        SetRandomRotationDelay(); // délai aléatoire au début
    }

    private void Update() {

        if (Time.time >= nextRotationTime) {
            RotateBot();
            SetRandomRotationDelay(); //nouveau délai aléatoire
        }
    }

    private void SetRandomRotationDelay() {
        // délai aléatoire entre 1 et 5 secondes
        rotationDelay = Random.Range(1f, 5f);
        nextRotationTime = Time.time + rotationDelay; 
    }

    private void RotateBot() {
        
        int randomDirection = Random.Range(0, 4);

        switch (randomDirection) {
            case 0:
                transform.up = Vector2.down;
                break;
            case 1:
                transform.up = Vector2.down;
                break;
            case 2:
                transform.up = Vector2.left; 
                break;
            case 3:
                transform.up = Vector2.right; 
                break;
        }
    }
}
