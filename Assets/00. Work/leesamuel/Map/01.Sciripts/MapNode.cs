using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapNode", menuName = "Scriptable Objects/MapNode")]
[System.Serializable]
public class MapNode // 각 방의 정보를 담는 클래스
{
    public string nodeID;           // 방의 고유 ID
    public Vector2 position;    // 맵에서의 위치
    public RoomType type;           // 방의 종류 등
    public int roomShapeType;
    public List<MapNode> neighbors = new List<MapNode>(); // 연결된 이웃들
    public bool isCleared = false;  // 클리어 여부
}

public enum RoomType { Boss, Fight, Huge, Interaction, Shop, Spawn }

