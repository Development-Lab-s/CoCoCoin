using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Room : MonoBehaviour
{
    public MapNode myData;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private CurrentEnemySetting enemySetting;

    [Obsolete("Obsolete")]
    private void OnMouseDown()
    {
        if (MapPlayer.Instance != null)
        {
            MapPlayer.Instance.MoveTo(myData, this);
        }
    }

    public void Setup(MapNode data)
    {
        myData = data;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    // 플레이어가 이 방에 도착했을 때 호출될 함수
    [Obsolete("Obsolete")]
    public void OnPlayerEnter()
    {
        if (myData.isCleared)
        {
            Debug.Log("이미 클리어한 방입니다.");
            MapPlayer.Instance.isMoving = false;
            return;
        }

        // 방 종류에 따른 반응
        switch (myData.type)
        {
            case RoomType.Fight:
                enemySetting.Data = myData.enemyData;
                _ = SceneManageHandler.instance.MoveScene(3);
                SetCleared();
                break;

            case RoomType.Shop:
                Debug.Log("상점에 입장했습니다. 물건을 구매하세요.");
                // 상점 UI 띄우기 로직
                _=SceneManageHandler.instance.MoveScene(2);
                SetCleared();
                break;

            case RoomType.Interaction:
                Debug.Log("신비한 비석을 발견했습니다.");
                _=SceneManageHandler.instance.MoveScene(8);
                SetCleared();
                break;

            case RoomType.Boss:
                enemySetting.Data = myData.enemyData;
                _ = SceneManageHandler.instance.MoveScene(3);
                MapManager mapMgr = FindObjectOfType<MapManager>();
                if (mapMgr != null)
                {
                    mapMgr.OnBossCleared();
                }
                break;;

            case RoomType.Huge:
                Debug.Log("넓은 방에 들어왔습니다.");
                MapPlayer.Instance.isMoving = false;
                break;
        }
        MapManager.saveMapId = myData.nodeID;
    }

    // 방을 클리어 상태로 만들고 시각 효과 적용
    public void SetCleared()
    {
        myData.isCleared = true;
        if (!MapManager.clearedNodeIDs.Contains(myData.nodeID))
        {
            MapManager.clearedNodeIDs.Add(myData.nodeID);
        }
        UpdateVisual();
    }

    // 시각적 업데이트 (클리어 시 어둡게)
    private void UpdateVisual()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        {
            // [수정] 클리어 상태이면서, 스폰룸이 아닐 때만 색을 어둡게 변경
            if (myData.isCleared && myData.type != RoomType.Spawn)
            {
                spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
            }
        }
    }
    
}