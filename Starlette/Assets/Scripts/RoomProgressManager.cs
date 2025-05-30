using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomProgressManager : MonoBehaviour
{
    public static RoomProgressManager Instance;
    public List<RoomProgressData> allRooms = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (RoomID id in System.Enum.GetValues(typeof(RoomID)))
            {
                allRooms.Add(new RoomProgressData
                {
                    roomID = id,
                    progress = 0f,
                    unfinishedPuzzles = new List<string>(),
                    timeSpent = 0f,
                    totalPuzzles = 0
                });
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartRoom(RoomID room)
    {
        var data = GetRoomData(room);
        data.startTime = Time.time;
    }

    public void EndRoom(RoomID room)
    {
        var data = GetRoomData(room);
        data.timeSpent += Time.time - data.startTime;
        data.startTime = 0f;
    }

    public void RegisterPuzzle(RoomID room, string puzzleID)
    {
        var data = GetRoomData(room);
        if (!data.unfinishedPuzzles.Contains(puzzleID))
        {
            data.unfinishedPuzzles.Add(puzzleID);
            data.totalPuzzles++;
        }
        UpdateRoomProgress(room);
    }

    public void MarkPuzzleFinished(RoomID room, string puzzleID)
    {
        var data = GetRoomData(room);
        if (data.unfinishedPuzzles.Contains(puzzleID))
        {
            data.unfinishedPuzzles.Remove(puzzleID);
            UpdateRoomProgress(room);
        }
    }

    private void UpdateRoomProgress(RoomID room)
    {
        var data = GetRoomData(room);
        int puzzlesLeft = data.unfinishedPuzzles.Count;
        int total = Mathf.Max(data.totalPuzzles, 1); // hindari bagi nol
        data.progress = 100f * (total - puzzlesLeft) / total;
    }

    public RoomProgressData GetRoomData(RoomID room)
    {
        return allRooms.Find(r => r.roomID == room);
    }

    public float GetTotalProgress()
    {
        float total = 0f;
        foreach (var room in allRooms)
        {
            total += room.progress;
        }
        return total / allRooms.Count;
    }
}

