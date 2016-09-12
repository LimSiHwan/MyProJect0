﻿using UnityEngine;
using System.Collections;
using System;

public class RIGHTLEFT_Enemy : Enemy {

    public override void Enemy_Move()
    {
        Vector2 Direction = ChangeDirection(Vector2.left);
        transform.Translate(Direction * Time.deltaTime * speed);

        if (transform.position.x <= -3)
        {
            SetFalse(this.gameObject);
        }
    }
}
