using UnityEngine;
using System.Collections;

public class LEFTUP_Enemy : Enemy {

    public override void Enemy_Move()
    {
        Vector2 Direction = ChangeDirection(new Vector2(1, -1));
        transform.Translate(Direction * Time.deltaTime * speed);

        if (transform.position.x >= 5)
        {
            SetFalse(this.gameObject);
        }
    }
}
