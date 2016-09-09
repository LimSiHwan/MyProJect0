using UnityEngine;
using System.Collections;

public class dotBlue : MonoBehaviour {
    
    const int dotSpeed = 3;
    
    void Update()
    {
        transform.Rotate(Vector3.forward * dotSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(GameManager.instance.gameSetting != GameSetting.GamePause && GameManager.instance.gameSetting != GameSetting.GameSet)
            {
                GameManager.instance.GameLoopingSet(GameSetting.GamePlaying);
                this.gameObject.SetActive(false);
            }
        }
    }
}
