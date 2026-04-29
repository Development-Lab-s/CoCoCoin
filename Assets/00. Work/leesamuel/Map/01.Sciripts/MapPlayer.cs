using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    public static MapPlayer Instance; // 어디서든 접근 가능하게 싱글톤 설정
    public MapNode currentNode;      // 플레이어가 현재 서 있는 방 데이터

    public float moveSpeed = 8f;
    private bool isMoving = false;

    void Awake()
    {
        Instance = this;
    }

    public void MoveTo(MapNode targetNode, Room targetRoomScript)
    {
        if (isMoving) return;
        {
            // 1. 경로 탐색 (BFS 알고리즘 사용)
            List<MapNode> path = FindPath(currentNode, targetNode);

            if (path != null && path.Count > 0)
            {
                StartCoroutine(FollowPathRoutine(path, targetRoomScript));
            }
            else
            {
                Debug.Log("연결된 경로가 없거나 중간 방이 클리어되지 않았습니다.");
            }
        }
    }

    private bool CheckNeighborsRecursive(MapNode current, MapNode target, HashSet<MapNode> visited)
    {
        visited.Add(current);

        foreach (var neighbor in current.neighbors)
        {
            if (neighbor == target) return true; // 길 찾음!

            // 아직 방문하지 않았고, '클리어된 방'이라면 그 방의 이웃도 조사함
            if (!visited.Contains(neighbor) && neighbor.isCleared)
            {
                if (CheckNeighborsRecursive(neighbor, target, visited)) return true;
            }
        }
        return false;
    }
    private IEnumerator FollowPathRoutine(List<MapNode> path, Room targetRoomScript)
    {
        isMoving = true;

        foreach (MapNode nextNode in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(nextNode.position.x, nextNode.position.y, transform.position.z);

            float distance = Vector3.Distance(startPos, endPos);
            float elapsed = 0f;
            float duration = distance / moveSpeed;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                // 약간의 가감속을 주면 더 자연스럽습니다.
                t = t * t * (3f - 2f * t);
                transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }

            transform.position = endPos;
            currentNode = nextNode; // 현재 위치 업데이트
        }

        isMoving = false;
        targetRoomScript.OnPlayerEnter();
    }

    // 너비 우선 탐색(BFS)으로 최단 경로 찾기
    private List<MapNode> FindPath(MapNode start, MapNode target)
    {
        Queue<List<MapNode>> queue = new Queue<List<MapNode>>();
        HashSet<MapNode> visited = new HashSet<MapNode>();

        queue.Enqueue(new List<MapNode> { start });
        visited.Add(start);

        while (queue.Count > 0)
        {
            List<MapNode> currentPath = queue.Dequeue();
            MapNode lastNode = currentPath[currentPath.Count - 1];

            if (lastNode == target)
            {
                // 시작 노드는 이미 서 있는 곳이므로 제외하고 경로 반환
                currentPath.RemoveAt(0);
                return currentPath;
            }

            foreach (MapNode neighbor in lastNode.neighbors)
            {
                // 타겟이거나, 이미 클리어된 방인 경우에만 경로로 인정
                if (!visited.Contains(neighbor) && (neighbor == target || neighbor.isCleared))
                {
                    visited.Add(neighbor);
                    List<MapNode> newPath = new List<MapNode>(currentPath);
                    newPath.Add(neighbor);
                    queue.Enqueue(newPath);
                }
            }
        }
        return null; // 경로 없음
    }
}
