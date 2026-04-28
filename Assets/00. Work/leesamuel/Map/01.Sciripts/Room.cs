using UnityEngine;

public class Room : MonoBehaviour
{
    public MapNode myData;
    public void Setup(MapNode data)
    {
        myData = data;
        gameObject.name = "Room_" + data.nodeID;
        if (myData.isCleared)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = Color.gray;
        }
    }
}