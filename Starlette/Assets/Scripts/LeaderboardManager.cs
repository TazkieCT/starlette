using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject leaderboardContent, userDataPrefab;

    private DatabaseReference db;
    private Dictionary<string, LeaderboardData> leaderboardEntries = new Dictionary<string, LeaderboardData>();

    void Start()
    {
        InitializeFirebase();
    }

    void InitializeFirebase()
    {
        db = FirebaseDatabase.DefaultInstance.GetReference("users");

        db.ChildAdded += OnUserAdded;
        db.ChildChanged += OnUserChanged;
    }

    void OnUserAdded(object sender, ChildChangedEventArgs args)
    {
        if(args.Snapshot.Exists)
        {
            AddUser(args.Snapshot);
        }
    }

    void OnUserChanged(object sender, ChildChangedEventArgs args)
    {
        if(args.Snapshot.Exists)
        {
            UpdateUser(args.Snapshot);
        }
    }

    void AddUser(DataSnapshot snapshot)
    {
        string username = snapshot.Key;
        int room = snapshot.HasChild("room")? int.Parse(snapshot.Child("room").Value.ToString()) : 0;
        int time = snapshot.HasChild("time")? int.Parse(snapshot.Child("time").Value.ToString()) : 0;

        if(!leaderboardEntries.ContainsKey(username))
        {
            leaderboardEntries[username] = new LeaderboardData(username, room, time);
            UpdateLeaderboardUI();
        }
    }

    void UpdateUser(DataSnapshot snapshot)
    {
        string username = snapshot.Key;
        int room = snapshot.HasChild("room")? int.Parse(snapshot.Child("room").Value.ToString()) : 0;
        int time = snapshot.HasChild("time")? int.Parse(snapshot.Child("time").Value.ToString()) : 0;

        leaderboardEntries[username] = new LeaderboardData(username, room, time);
        UpdateLeaderboardUI();
    }

    void UpdateLeaderboardUI()
    {
        foreach(Transform child in leaderboardContent.transform)
        {
            Destroy(child.gameObject);
        }

        List<LeaderboardData> sortedList = new List<LeaderboardData>(leaderboardEntries.Values);
        sortedList.Sort((a, b) =>
        {
            int roomComparison = b.room.CompareTo(a.room); // Descending room
            if(roomComparison != 0)
                return roomComparison;
            return a.time.CompareTo(b.time); // Ascending time
        });

        int rank = 1;

        foreach(LeaderboardData data in sortedList)
        {
            GameObject entry = Instantiate(userDataPrefab, leaderboardContent.transform);
            entry.transform.localScale = Vector3.one;

            if(rank % 2 == 0)
            {
                Image background = entry.GetComponent<Image>();
                background.color = new Color32(24, 7, 38, 255);
            }
            
            DataUI dataUI = entry.GetComponent<DataUI>();

            dataUI.rankText.text = rank.ToString();
            dataUI.usernameText.text = data.username;
            dataUI.roomText.text = data.room.ToString();
            dataUI.timeText.text = data.time + "s";

            rank++;
        }
    }
}

public class LeaderboardData
{
    public string username;
    public int room, time;

    public LeaderboardData(string username, int room, int time)
    {
        this.username = username;
        this.room = room;
        this.time = time;
    }
}