using UnityEngine;

public abstract class Character : MonoBehaviour
{
    
    protected Rigidbody2D body;

    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    protected abstract void Move();
    protected abstract void Attack();
}
