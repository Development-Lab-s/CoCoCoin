using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    private int currentMapShapeIndex;
    private int currentMapType;
    [SerializeField]private GameObject linePrefab;
    private static bool isInitialized = false;
    private static int savedMapType = -1;
    private static int savedShapeIndex = -1;
    public List<MapNode> allNodes = new List<MapNode>();
    [SerializeField] private GameObject[] bossRoomPrefab;
    [SerializeField] private GameObject[] fightRoomPrefab;
    [SerializeField] private GameObject[] hugeRoomPrefab;
    [SerializeField] private GameObject[] interacitionRoomPrefab;
    [SerializeField] private GameObject[] shopRoomPrefab;
    [SerializeField] private GameObject[] spawnRoomPrefab;

    void Start()
    {
        currentMapShapeIndex = 0; //Random.Range(0,0);
        currentMapType = 0;//Random.Range(0,0);

        InitializeMapSettings();
        SetupMapData();
        GenerateMapVisuals();
        
    }
    void InitializeMapSettings()
    {
        if (!isInitialized)
        {
            savedMapType = 0;//Random.Range(0, 0);
            savedShapeIndex = 0;// Random.Range(0,0);
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
        }
    }
    void GenerateTypeAMap()
    {
        // 1. 노드 생성 (좌표는 유니티 유닛 기준, 중앙이 0,0)
        MapNode boss = CreateNode("Boss", 0, 5f, RoomType.Boss);         // 맨 위 긴 상자
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
        Debug.Log("BMap");
    }
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
        MapNode node = new MapNode
        {
            nodeID = id,
            position = new Vector2(x, y),
            type = type,
            roomShapeType = currentMapShapeIndex 
        };
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
}
