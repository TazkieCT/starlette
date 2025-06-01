using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomProgressManager : MonoBehaviour
{
    public static RoomProgressManager Instance;
    public List<RoomProgressData> allRooms = new();
    float totalTimeOfGame;
    float sessionStartTime;
    bool isTrackingTime = true;
    private void Awake()
    {

        totalTimeOfGame = 0f;
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
           sessionStartTime = Time.time;
        totalTimeOfGame = PlayerPrefs.GetFloat("TotalPlayTime", 0f);
    }
    void Update()
    {
         if (isTrackingTime)
        {
            totalTimeOfGame += Time.deltaTime;
        }
    }

    public void OnPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SavePlayTime();
        }
        else
        {
            sessionStartTime = Time.time;
        }
    }

    public void OnQuit()
    {
        isTrackingTime = false;
        SavePlayTime();
    }

    private void SavePlayTime()
    {
        PlayerPrefs.SetFloat("TotalPlayTime", totalTimeOfGame);
        PlayerPrefs.Save();
        Debug.Log(totalTimeOfGame);
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
        // data.startTime = 0f;
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

    public float GetTotalTime()
    {
        float total = 0f;
        foreach (var room in allRooms)
        {
            total += room.timeSpent;
        }
        return total;
    }

}

