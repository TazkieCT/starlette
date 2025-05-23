using System.Collections.Generic;
using UnityEngine;

public enum RoomID
{
    Room1,
    Room2,
    Room3,
    Room4,
    Room5,
    Room6,
    Puzzle1,
    Puzzle2,
    Puzzle3,
    Puzzle4,
    Status
}

public enum DialogueID
{
    Dialogue1,
    Dialogue2,
    Dialogue3,
    Dialogue4,
    Dialogue5,
    Dialogue6,
    Success,
    Failed,
}

[CreateAssetMenu(fileName = "DialogTextDB", menuName = "Dialogue/Dialog Text Database")]
public class DialogTextDB : ScriptableObject
{
    private Dictionary<RoomID, Dictionary<DialogueID, List<string>>> dialogueDatabase;

    private void OnEnable()
    {
        dialogueDatabase = new Dictionary<RoomID, Dictionary<DialogueID, List<string>>>
        {
            {
                RoomID.Room1, new Dictionary<DialogueID, List<string>>
                {
                    { 
                        DialogueID.Dialogue1, new List<string> {
                        "Hey Hey This is testing for dialogue room 1",
                        "GG lah tessting tesring testring"
                        }
                    },
                    { 
                        DialogueID.Dialogue2, new List<string> {
                        "",
                        ""
                        }
                    },
                }
            },
            {
                RoomID.Room2, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "",
                        ""
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "",
                        ""
                        }
                    },
                }
            },
            {
                RoomID.Room3, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "",
                        ""
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "",
                        ""
                        }
                    },
                }
            },
            {
                RoomID.Room4, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "This place... it doesn’t feel like the others. It’s too quiet.",
                        "Why would a room like this have so many branching paths? Where do they all lead?"
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "These lights… why do they feel familiar?",
                        "Something’s pulling at me… like I’ve been here before. But I know I haven’t."
                        }
                    },
                }
            },
            {
                RoomID.Room5, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "This humming... it’s inside my head.",
                        "I’ve been here. I know this rhythm. But that’s impossible."
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "What is this? Why do I remember things that never happened?",
                        "My head... it’s splitting. These memories they aren't mine."
                        }
                    },
                    {
                        DialogueID.Dialogue3, new List<string> {
                        "This room is doing something to me and I need to know why.",
                        "I need to go to the core control room.."
                        }
                    },
                }
            },
            {
                RoomID.Room6, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "Where is everyone…?",
                        "What happened to them... what happened to me?"
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "This was the room we used to gather.",
                        "They were right here. They were alive.",
                        }
                    },
                }
            },
            {
                RoomID.Status, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "This isn’t working. I need to find another clue.",
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "Something’s off. I’ll come back to this.",
                        }
                    },
                    {
                        DialogueID.Dialogue3, new List<string> {
                        "No response... Maybe I missed something.",
                        }
                    },
                }
            },
        };
    }

    public List<string> GetDialogueLines(RoomID room, DialogueID id)
    {
        if (dialogueDatabase.ContainsKey(room) && dialogueDatabase[room].ContainsKey(id))
            return dialogueDatabase[room][id];

        return new List<string> { "Dialogue not found." };
    }
}
