using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GameController : MonoBehaviour {

    float h;
    float v;

    bool Moves;

    Vector2 startPos;
    Vector2 currentPos;

    int touchCount;
    
    void Start()
    {
        Moves = false;
        startPos = transform.position;
    }

	void Update ()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //hori 가로 veri 세로.
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            Moves = true;

        if (Moves)
        {

            if(GameManager.instance.gameSetting == GameSetting.GamePlaying)
                PlayerMove(h, v);
        }
        
	}
    void PlayerMove(float h, float v)
    {
    #if UNITY_EDITOR
   
        if (h == -1) //가로
        {
            if(transform.position.x >= startPos.x)
            {
                transform.DOMoveX(transform.position.x - 1, 0.1f);
                Moves = false;
            }
        }
        if (h == 1) //가로
        {
            if(transform.position.x <= startPos.x)
            {
                transform.DOMoveX(transform.position.x + 1, 0.1f);
                Moves = false;
            }
        }
        if(v == 1)
        {
            if(transform.position.y <= startPos.y)
            {
                transform.DOMoveY(transform.position.y + 1, 0.1f);
                Moves = false;
            }
        }
        if(v == -1)
        {
            if(transform.position.y >= startPos.y)
            {
                transform.DOMoveY(transform.position.y - 1, 0.1f);
                Moves = false;
            }
        }
#endif
#if UNITY_ANDROID

#endif
    }
}
