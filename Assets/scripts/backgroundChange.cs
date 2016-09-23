using UnityEngine;
using System.Collections;

public class backgroundChange : MonoBehaviour {

    public void backGroundEvent()
    {
        switch (GameManager.instance.stage)
        {
            case GameStage.Stage1:
                break;
            case GameStage.Stage2:
                Destroy(GameManager.instance.goTemp[0]);
                break;
            case GameStage.Stage3:
                Destroy(GameManager.instance.goTemp[1]);
                break;
            case GameStage.Stage4:
                Destroy(GameManager.instance.goTemp[2]);
                break;
            case GameStage.Stage5:
                Destroy(GameManager.instance.goTemp[3]);
                break;
        }
    }
}
