using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{
    public static List<string> clearedNodeIDs;

    public static string saveMapId = null;
    private int currentMapShapeIndex;
    private int currentMapType;
    [SerializeField]private GameObject linePrefab;
    public static bool isInitialized = false;
    private static int savedMapType = -1;
    private static int savedShapeIndex = -1;
    public List<MapNode> allNodes = new List<MapNode>();
    [SerializeField] private GameObject[] bossRoomPrefab;
    [SerializeField] private GameObject[] fightRoomPrefab;
    [SerializeField] private GameObject[] hugeRoomPrefab;
    [SerializeField] private GameObject[] interacitionRoomPrefab;
    [SerializeField] private GameObject[] shopRoomPrefab;
    [SerializeField] private GameObject[] spawnRoomPrefab;
    
    [SerializeField] private List<EnemyData> enemyDataFloor1 = new List<EnemyData>();
    [SerializeField] private List<EnemyData> enemyDataFloor2 = new List<EnemyData>();
    [SerializeField] private List<EnemyData> enemyDataFloor3 = new List<EnemyData>();

    public static int currentFloor = 1;     
    public int maxFloor = 3;

    [Obsolete("Obsolete")]
    void Start()
    {   
        MapPlayer.Instance.isMoving = false;
        InitializeMapSettings();
        currentMapType = savedMapType;
        currentMapShapeIndex = savedShapeIndex;
        SetupMapData();
        GenerateMapVisuals();
        FloorUIController ui = FindObjectOfType<FloorUIController>();
        if (ui != null)
        {
            ui.ShowFloorUI(currentFloor);
        }
        

    }
    void InitializeMapSettings()
    {
        // static 변수는 게임이 꺼질 때까지 유지되므로, 처음 한 번만 실행되게 합니다.
        if (!isInitialized)
        {
            savedMapType = Random.Range(0, 3); // 0 또는 1
            savedShapeIndex = Random.Range(0, 3);
            clearedNodeIDs = new List<string>();
            isInitialized = true; // 이 변수를 true로 바꿔야 다음 씬 로드 때 랜덤이 안 돌아갑니다.
        }
    }

    void SetupMapData()
    {
        allNodes.Clear();

        // 현재 결정된 맵 타입에 따라 다른 배치 함수 실행
        switch (currentMapType)
        {
            case 0: GenerateTypeAMap(); break; 
            case 1: GenerateTypeBMap(); break; 
            case 2: GenerateTypeCMap(); break; 
        }
    }
    void GenerateTypeAMap()
    {
        // 1. 노드 생성 (좌표는 유니티 유닛 기준, 중앙이 0,0)
        MapNode boss = CreateNode("Boss", 0, 4f, RoomType.Boss);         // 맨 위 긴 상자
        MapNode interact = CreateNode("Interact", 0, 2f, RoomType.Interaction); // 중앙 위 느낌표
        MapNode huge = CreateNode("Huge", 0, -1f, RoomType.Huge);            // 중앙 큰 네모
        MapNode shopL = CreateNode("ShopL", -4f, -1f, RoomType.Shop);        // 왼쪽 노란 네모
        MapNode shopR = CreateNode("ShopR", 4f, -1f, RoomType.Shop);         // 오른쪽 노란 네모
        MapNode spawn = CreateNode("Spawn", 0, -4f, RoomType.Spawn);     // 맨 아래 원형

        // 전투방들 (모서리 배치)
        MapNode fTL = CreateNode("FTL", -4f, 2f, RoomType.Fight);
        MapNode fTR = CreateNode("FTR", 4f, 2f, RoomType.Fight);
        MapNode fBL = CreateNode("FBL", -4f, -4f, RoomType.Fight);
        MapNode fBR = CreateNode("FBR", 4f, -4f, RoomType.Fight);

        // 2. 연결 관계 설정 (이미지의 선 그대로 연결)
        Connect(boss, fTL); Connect(boss, fTR);     // 보스방은 양쪽 위 전투방과 연결
        Connect(interact, huge); // 상호작용방은 아래 연결

        Connect(huge, shopL); Connect(huge, shopR); // 중앙방은 좌우 상점과 연결

        Connect(shopL, fTL); Connect(shopL, fBL);   // 왼쪽 상점은 위아래 전투방과 연결
        Connect(shopR, fTR); Connect(shopR, fBR);   // 오른쪽 상점은 위아래 전투방과 연결

        Connect(spawn, fBL); Connect(spawn, fBR);   // 스폰방은 양쪽 아래 전투방과 연결
    }
    void GenerateTypeBMap()
    {
        // 1. 노드 생성 (이미지 구도 기준 좌표 설정)
        MapNode boss = CreateNode("Boss", 0f, 4f, RoomType.Boss);
        MapNode shop = CreateNode("Shop", 0f, 2.3f, RoomType.Shop); // 상단 중앙 상점

        // 중앙 거대 방
        MapNode huge = CreateNode("Huge", 0f, 0f, RoomType.Huge);

        // 중간층 전투 방 (좌, 우)
        MapNode fightML = CreateNode("FML", -4f, 0f, RoomType.Fight);
        MapNode fightMR = CreateNode("FMR", 4f, 0f, RoomType.Fight);

        // 상층 전투 방 (좌, 우)
        MapNode fightTL = CreateNode("FTL", -3.5f, 3f, RoomType.Fight);
        MapNode fightTR = CreateNode("FTR", 3.5f, 3f, RoomType.Fight);

        // 하단 방사형 배치 (상호작용 2개 + 스폰)
        MapNode interactL = CreateNode("InteractL", -4f, -3f, RoomType.Interaction);
        MapNode interactR = CreateNode("InteractR", 4f, -3f, RoomType.Interaction);
        MapNode spawn = CreateNode("Spawn", 0f, -4f, RoomType.Spawn);

        // 2. 연결 관계 설정 (이미지의 선 참조)

        // 보스 - 상점 연결
        Connect(boss, shop);

        // 상점 - 상단 전투방들 연결
        Connect(shop, fightTL);
        Connect(shop, fightTR);

        // 상단 전투방 - 중간 전투방 연결 (세로선)
        Connect(fightTL, fightML);
        Connect(fightTR, fightMR);

        // 중간 전투방 - 중앙 거대 방 연결 (가로선)
        Connect(fightML, huge);
        Connect(fightMR, huge);

        // 중앙 거대 방 - 하단 3개 방 방사형 연결
        Connect(huge, interactL);
        Connect(huge, interactR);
        Connect(huge, spawn);

        // 하단 스폰 - 상호작용 연결 (이미지 하단 가로줄이 있다면 추가)
        // Connect(spawn, interactL);
        // Connect(spawn, interactR);
    }
    void GenerateTypeCMap()
    {
        // 1. 노드 생성 (이미지 C 구도 기준)
        MapNode boss = CreateNode("Boss", 0f, 4f, RoomType.Boss);

        // 상단 전투방 2개
        MapNode fightTL = CreateNode("FTL", -3f, 2.5f, RoomType.Fight);
        MapNode fightTR = CreateNode("FTR", 3f, 2.5f, RoomType.Fight);

        // 상점 (중앙 상단)
        MapNode shop = CreateNode("Shop", 0f, 1.5f, RoomType.Shop);

        // 중앙 거대 방 (육각형)
        MapNode huge = CreateNode("Huge", 0f, -1f, RoomType.Huge);

        // 좌우 상호작용 방 (!)
        MapNode interactL = CreateNode("InteractL", -6f, -1f, RoomType.Interaction);
        MapNode interactR = CreateNode("InteractR", 6f, -1f, RoomType.Interaction);

        // 하단 전투방 2개
        MapNode fightBL = CreateNode("FBL", -3f, -3f, RoomType.Fight);
        MapNode fightBR = CreateNode("FBR", 3f, -3f, RoomType.Fight);

        // 하단 스폰 방 (원형)
        MapNode spawn = CreateNode("Spawn", 0f, -4f, RoomType.Spawn);

        // 2. 연결 관계 설정 (이미지 선 참조)

        // 보스 - 상단 전투방들
        Connect(boss, fightTL);
        Connect(boss, fightTR);

        // 상단 전투방들 - 상점
        Connect(fightTL, shop);
        Connect(fightTR, shop);

        // 상점 - 중앙 거대 방
        Connect(shop, huge);

        // 중앙 거대 방 - 좌우 상호작용 방
        Connect(huge, interactL);
        Connect(huge, interactR);

        // 중앙 거대 방 - 하단 전투방들
        Connect(huge, fightBL);
        Connect(huge, fightBR);

        // 하단 전투방들 - 스폰 방
        Connect(fightBL, spawn);
        Connect(fightBR, spawn);
    }
    [Obsolete("Obsolete")]
    void GenerateMapVisuals()
    {
        foreach (MapNode node in allNodes)
        {
            GameObject[] targetArray = GetArrayByType(node.type);
            GameObject prefabToSpawn = targetArray[savedShapeIndex];

            GameObject roomGo = Instantiate(prefabToSpawn, node.position, Quaternion.identity);

            Room roomScript = roomGo.GetComponent<Room>();
            if (roomScript != null)
            {
                roomScript.Setup(node);
            }
        }
        DrawMapLines();
        MapPlayer player = FindObjectOfType<MapPlayer>();
        if (player != null)
        {
            // spawn 노드를 찾아서 배치 (ID가 "Spawn"인 노드)
            MapNode spawnNode = allNodes.Find(n => saveMapId != null ? n.nodeID == saveMapId : n.nodeID == "Spawn");
            if (spawnNode != null)
            {
                player.currentNode = spawnNode;
                player.transform.position = new Vector3(spawnNode.position.x, spawnNode.position.y, -0.5f);
            }
        }

    }
    GameObject[] GetArrayByType(RoomType type)
    {
        switch (type)
        {
            case RoomType.Boss: return bossRoomPrefab;
            case RoomType.Fight: return fightRoomPrefab;
            case RoomType.Huge: return hugeRoomPrefab;
            case RoomType.Interaction: return interacitionRoomPrefab;
            case RoomType.Shop: return shopRoomPrefab;
            case RoomType.Spawn: return spawnRoomPrefab;
            default: return fightRoomPrefab;
        }
    }
    MapNode CreateNode(string id, float x, float y, RoomType type)
    {
        MapNode node = ScriptableObject.CreateInstance<MapNode>();
        node.nodeID = id;
        node.position = new Vector2(x, y);
        node.type = type;
        node.mapType = savedMapType;
        node.roomShapeType = savedShapeIndex;
        List<EnemyData> targetList = null;
        switch (currentFloor)
        {
            case 1:
                targetList = enemyDataFloor1;
                break;
            case 2:
                targetList = enemyDataFloor2;
                break;
            case 3:
                targetList = enemyDataFloor3;
                break;
            default:
                targetList = enemyDataFloor1;
                break;
        }
        node.enemyData = targetList[Random.Range(0, targetList.Count)];

        // [수정] 스폰룸이거나 이미 클리어 리스트에 있다면 true
        if (type == RoomType.Spawn || clearedNodeIDs.Contains(id))
        {
            node.isCleared = true;
        }
        else
        {
            node.isCleared = false;
        }

        allNodes.Add(node);
        return node;
    }
    void DrawMapLines()
    {
        HashSet<string> drawnConnections = new HashSet<string>();

        foreach (var node in allNodes)
        {
            foreach (var neighbor in node.neighbors)
            {
                // 중복 선 그리기 방지 (A-B와 B-A는 같은 선)
                string connectionKey = string.Compare(node.nodeID, neighbor.nodeID) < 0
                    ? node.nodeID + neighbor.nodeID
                    : neighbor.nodeID + node.nodeID;

                if (!drawnConnections.Contains(connectionKey))
                {
                    GameObject line = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, transform);
                    LineRenderer lr = line.GetComponent<LineRenderer>();
                    lr.SetPosition(0, node.position);
                    lr.SetPosition(1, neighbor.position);
                    drawnConnections.Add(connectionKey);
                }
            }
        }
    }
    void Connect(MapNode a, MapNode b)
    {
        if (!a.neighbors.Contains(b)) a.neighbors.Add(b);
        if (!b.neighbors.Contains(a)) b.neighbors.Add(a);
    }

    public void OnBossCleared()
    {
        if (currentFloor < maxFloor)
        {
            // 다음 층으로 진행
            currentFloor++;
            Debug.Log($"{currentFloor}층으로 이동합니다.");

            // 맵 데이터 초기화 (클리어 기록 삭제)
            clearedNodeIDs.Clear();
            isInitialized = false; // 새로운 맵 타입을 정하기 위해 초기화

            // 현재 맵 씬을 다시 로드 (그러면 Start가 실행되며 새 맵이 생성됨)
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }
        else
        {
            // 마지막 층 보스를 깼다면 엔딩으로
            Debug.Log("축하합니다! 모든 층을 클리어하여 엔딩 씬으로 이동합니다.");
            //UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
        }
    }
}
