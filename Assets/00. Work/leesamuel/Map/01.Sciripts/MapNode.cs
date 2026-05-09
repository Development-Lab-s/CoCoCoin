using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNode", menuName = "Map/NodeData")]
public class MapNode : ScriptableObject
{
    public string nodeID;
    public Vector2 position;
    public RoomType type;
    public int roomShapeType;
    public int mapType;
    public List<MapNode> neighbors = new List<MapNode>();
    public bool isCleared = false;
    public EnemyData enemyData;
}

public enum RoomType { Boss, Fight, Huge, Interaction, Shop, Spawn }