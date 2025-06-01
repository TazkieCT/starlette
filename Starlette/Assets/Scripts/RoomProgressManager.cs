using Firebase.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomProgressManager : MonoBehaviour
{
    public static RoomProgressManager Instance;
    public List<RoomProgressData> allRooms = new();
    private HashSet<RoomID> uploadedRooms = new(); //Bikin ini biar tidak push ke db (room yang sama) berkali-kali

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
        int total = Mathf.Max(data.totalPuzzles, 1);
        data.progress = 100f * (total - puzzlesLeft) / total;

        if (data.progress >= 100f && !uploadedRooms.Contains(room))
        {
            uploadedRooms.Add(room);
            PushRoomDataToFirebase(data);
        }
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

    public void PushRoomDataToFirebase(RoomProgressData data)
    {
        //string username = PlayerPrefs.GetString("Username", "Guest");

        //if (string.IsNullOrEmpty(username) || username == "Guest")
        //{
        //    Debug.LogWarning("No valid username found. Skipping upload.");
        //    return;
        //}

        string username = "DummyUser123";

        string roomName = data.roomID.ToString();

        FirebaseManager.Instance.DBReference
            .Child("roomProgress")
            .Child(username)
            .Child(roomName)
            .SetRawJsonValueAsync(JsonUtility.ToJson(new RoomUploadPayload
            {
                room = roomName,
                time = data.timeSpent,
                timestamp = System.DateTime.UtcNow.ToString("o")
            }))
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                    Debug.Log($"Room {roomName} progress pushed for user {username}");
                else
                    Debug.LogError("Failed to upload progress: " + task.Exception);
            });
    }

    [System.Serializable]
    public class RoomUploadPayload
    {
        public string room;
        public float time;
        public string timestamp;
    }

}

