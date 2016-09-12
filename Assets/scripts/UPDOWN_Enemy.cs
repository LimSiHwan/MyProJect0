using UnityEngine;
using System.Collections;
using System;

public class UPDOWN_Enemy : Enemy {
    
    public override void Enemy_Move()
    {
        Vector2 Direction = ChangeDirection(Vector2.down);
        transform.Translate(Direction * Time.deltaTime * speed);
        
        if(transform.position.y <= -3)
        {
            SetFalse(this.gameObject);
        }
    }
}
