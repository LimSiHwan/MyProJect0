using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameSetting
{
    GameInit,
    GameStart,
    GamePause,
    GamePlaying,
    GameSet
}

public class GameManager : MonoBehaviour{

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("cSingleton == null");

            return _instance;
        }
    }
    
    void Awake()
    {
        _instance = this;
    }
    const int StartPosX = 0;
    const int StartPosY = 0;

    public GameObject MainCam;
    public GameObject Background;
    public GameObject tile;
    public GameObject Player;

    public GameSetting gameSetting;


    GameObject dotBlueTemp; //dotblue를 담는 부모오브젝트

    Vector2[] dotBluePosition =
    {
        new Vector2(0,0),
        new Vector2(1,0),
        new Vector2(-1,0),
        new Vector2(1,1),
        new Vector2(-1,-1),
        new Vector2(0,1),
        new Vector2(0,-1),
        new Vector2(-1,1),
        new Vector2(1,-1)
    };

    List<int> randomList = new List<int>();
    int dotBluePositionRandom = 0;
    bool playingFirst = false;

    int NextPosition;
    int NextPositionTemp;

    void Start ()
    {
        if(gameSetting == GameSetting.GameInit)
            init();
	}
    void init()
    {
        GameObject goTemp = Instantiate(Background) as GameObject;
        GameObject goTemp_tile = Instantiate(tile) as GameObject;
        dotBlueTemp = Instantiate(Resources.Load("dotBlueTemp")) as GameObject;

        goTemp.transform.parent = MainCam.gameObject.transform;
        goTemp_tile.transform.parent = goTemp.transform;
        dotBlueTemp.transform.parent = MainCam.gameObject.transform;

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
                StartCoroutine(gamePlaying());
                break;
            case GameSetting.GameSet:
                gameSet();
                break;
            case GameSetting.GamePause:
                gamePause();
                break;
        }
    }
    private int RandomFunction(int preRandom)
    {
        for(int i = 0; i < 9; i++)
        {
            randomList.Add(i);
        }
        randomList.Remove(preRandom);
        int nextRandom = Random.Range(randomList[0], randomList[randomList.Count - 1]);
        return nextRandom;
    }
    void gameStart()
    {
        Debug.Log("=====게임 시작=======");

        ObjectPool.DotBlueCapacity = 1;
        ObjectPool.CreateObject("dotBlue", dotBlueTemp);
        dotBluePositionRandom = RandomFunction(Random.Range(0, 9));
        ObjectPool.Instantiate("dotBlue", dotBluePosition[dotBluePositionRandom], Quaternion.identity);
        playingFirst = true;
    }
    IEnumerator gamePlaying()
    {
        Debug.Log("======게임 실행중========");
        yield return new WaitForSeconds(0.5f);
        if (playingFirst)
            NextPosition = RandomFunction(dotBluePositionRandom);
        else
            NextPosition = RandomFunction(NextPositionTemp);

        NextPositionTemp = NextPosition;
        ObjectPool.Instantiate("dotBlue", dotBluePosition[NextPosition], Quaternion.identity);
    }
    void gameSet()
    {

    }

    void gamePause()
    {

    }
}
