using UnityEngine;
using System.Collections;
using System;

public class DOWNUP_Enemy : Enemy {

    public override void Enemy_Move()
    {
        Vector2 Direction = ChangeDirection(Vector2.up);
        transform.Translate(Direction * Time.deltaTime * speed);

        if (transform.position.y >= 5)
        {
            SetFalse(this.gameObject);
        }
    }
}
