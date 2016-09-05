using UnityEngine;
using System.Collections;

public enum GameSetting
{
    GameInit,
    GameStart,
    GamePause,
    GamePlaying,
    GameSet
}

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }
    
    const int StartPosX = 0;
    const int StartPosY = 0;

    public GameObject MainCam;
    public GameObject Background;
    public GameObject tile;
    public GameObject Player;

    public GameSetting gameSetting;

	void Start ()
    {
        if(gameSetting == GameSetting.GameInit)
            init();
	}
    void init()
    {
        GameObject goTemp = Instantiate(Background) as GameObject;
        GameObject goTemp_tile = Instantiate(tile) as GameObject;
        goTemp.transform.parent = MainCam.gameObject.transform;
        goTemp_tile.transform.parent = goTemp.transform;
        Player = Instantiate(Player, new Vector2(StartPosX, StartPosY), Quaternion.identity) as GameObject;
        Player.AddComponent<GameController>();
    }
    public void GameLoopingSet(GameSetting gameSetting)
    {
        switch (gameSetting)
        {
            case GameSetting.GameInit:
                init();
                break;
            case GameSetting.GameStart:
                gameStart();
                break;
            case GameSetting.GamePlaying:
                break;
            case GameSetting.GameSet:
                break;
            case GameSetting.GamePause:
                break;
        }
    }
    void gameStart()
    {
        Debug.Log("=====게임 시작=======");
    }
}
