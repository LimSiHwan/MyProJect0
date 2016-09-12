using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
    public GameObject UICam;

    GameObject goTemp;
    GameObject mainBackGroundObj;
    public GameSetting gameSetting;


    GameObject dotBlueTemp; //dotblue를 담는 부모오브젝트
    GameObject dotBlackTemp; //dotblack을 담는 부모오브젝트

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

    string[] BlackPos = { "UP", "DOWN", "RIGHT", "LEFT" };
    float spawnDelayTime;
    public float SpawnDelayTime
    {
        get
        {
            return spawnDelayTime;
        }
        set
        {
            spawnDelayTime = value;
        }
    }
    void Start ()
    {
        if(gameSetting == GameSetting.GameInit)
            init();
	}
    void init()
    {
        goTemp = Instantiate(Background) as GameObject; //뒷 배경 생성
        mainBackGroundObj = Instantiate(Resources.Load("mainBackground")) as GameObject;
        mainBackGroundObj.transform.SetParent(UICam.transform);
        mainBackGroundObj.transform.localScale = new Vector3(1, 1, 1);
        mainBackGroundObj.transform.localPosition = new Vector3(-10, -1, 0);
        mainBackGroundObj.AddComponent<BtnManager>();
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
        mainBackGroundObj.SetActive(false);

        GameObject Score = Instantiate(Resources.Load("Score")) as GameObject;
        Score.transform.SetParent(UICam.transform);
        Score.transform.localScale = new Vector3(1, 1, 1);
        Score.transform.localPosition = new Vector3(0, 504, 0);

        GameObject goTemp_tile = Instantiate(tile) as GameObject;
        dotBlueTemp = Instantiate(Resources.Load("dotBlueTemp")) as GameObject;
        dotBlackTemp = Instantiate(Resources.Load("dotBlackTemp")) as GameObject;

        goTemp.transform.parent = MainCam.gameObject.transform;
        goTemp_tile.transform.parent = goTemp.transform;
        dotBlueTemp.transform.parent = MainCam.gameObject.transform;
        dotBlackTemp.transform.parent = MainCam.gameObject.transform;

        Player = Instantiate(Player, new Vector2(StartPosX, StartPosY), Quaternion.identity) as GameObject;
        Player.AddComponent<GameController>();

        ObjectPool.DotBlueCapacity = 1;
        ObjectPool.CreateObject("dotBlue", dotBlueTemp);

        ObjectPool.DotBlackCapacity = 10;
        ObjectPool.CreateBlackObject("UPDOWN_Enemy", dotBlackTemp);
        ObjectPool.CreateBlackObject("DOWNUP_Enemy", dotBlackTemp);
        ObjectPool.CreateBlackObject("RIGHTLEFT_Enemy", dotBlackTemp);
        ObjectPool.CreateBlackObject("LEFTRIGHT_Enemy", dotBlackTemp);

        SpawnDelayTime = 1.0f;
        StartCoroutine(blackSpawn());
        playingFirst = true;
        dotBluePositionRandom = RandomFunction(Random.Range(0, 9));

        GameLoopingSet(GameSetting.GamePlaying);
    }
    public IEnumerator gamePlaying()
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
    IEnumerator blackSpawn()
    {
        yield return new WaitForSeconds(SpawnDelayTime);
        string blackPos = BlackPos[Random.Range(0, 4)];
        switch (blackPos)
        {
            case "UP":
                ObjectPool.Instantiate("DOWNUP_Enemy", new Vector2(Random.Range(-1, 2), -3), Quaternion.identity);
                break;
            case "DOWN":
                ObjectPool.Instantiate("UPDOWN_Enemy", new Vector2(Random.Range(-1, 2), 3), Quaternion.identity);
                break;
            case "RIGHT":
                ObjectPool.Instantiate("RIGHTLEFT_Enemy", new Vector2(3, Random.Range(-1, 2)), Quaternion.identity);
                break;
            case "LEFT":
                ObjectPool.Instantiate("LEFTRIGHT_Enemy", new Vector2(-3, Random.Range(-1,2)), Quaternion.identity);
                break;
        }
        StartCoroutine(blackSpawn());
    }
    void gameSet()
    {

    }

    void gamePause()
    {

    }
}
