using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnManager :MonoBehaviour{

    Button gameStartBtn;

    void Start()
    {
        gameStartBtn = this.gameObject.transform.FindChild("playGame").GetComponent<Button>();
        gameStartBtn.onClick.AddListener(GameStart); //게임시작버튼
    }
    public void GameStart()
    {
        GameManager.instance.gameSetting = GameSetting.GamePlaying;
        GameManager.instance.GameLoopingSet(GameSetting.GameStart);
    }
}
