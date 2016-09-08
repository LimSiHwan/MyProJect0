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
            this.gameObject.SetActive(false);
            GameManager.instance.GameLoopingSet(GameSetting.GamePlaying);
        }
    }
}
