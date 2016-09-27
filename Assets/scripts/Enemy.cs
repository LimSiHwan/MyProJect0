using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour{
    
    public static float speed = 3;
    Vector2 DirectionPos;

    int randomPos;

    public Vector2 ChangeDirection(Vector2 Dir)
    {
        DirectionPos = Dir;
        return DirectionPos;
    }
    public void SetFalse(GameObject BlackObj)
    {
        BlackObj.SetActive(false);
    }
    void Update()
    {
        Enemy_Move();
    }
    abstract public void Enemy_Move();
    
}
