using System.Collections.Generic;
using UnityEngine;

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
                        "Where is everyone...? Why am I the only one here?",
                        "No signal� figures. Whatever happened, we�re way too far out.",
                        "I need to find another way. Maybe there's something still working around here.",
                        }
                    },
                    { 
                        DialogueID.Dialogue2, new List<string> {
                        "These mechanisms... they�ve been completely torn apart. What the hell happened here?",
                        "An AI assistant? Maybe you're the only help I�ve got right now..."
                        }
                    },
                    {
                        DialogueID.Success, new List<string> {
                        "Alright... something's working again. One step at a time. Let�s keep moving.",
                        }
                    },
                }
            },
            {
                RoomID.Room2Part1, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "The air�s thin... I need to move fast.",
                        "These systems... they�re linked. One mistake could throw off the whole thing.",
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "Come on, think. I�ve never done this before, but someone has to try.",
                        }
                    },
                    {
                        DialogueID.Success, new List<string> {
                        "That should do it. Wait... what�s that on the floor?",
                        }
                    },
                    {
                        DialogueID.Dialogue3, new List<string> {
                        "This message... it's corrupted. Someone tried to say something.",
                        }
                    },
                    {
                        DialogueID.Dialogue4, new List<string> {
                        "Why does everything feel... off? I need to find out what happened here.",
                        }
                    },
                }
            },
            {
                RoomID.Room3, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "Four doors. One central system. And that feeling again...",
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "Why do I feel like I�ve done this before? I know I haven�t... have I?",
                        }
                    },
                    {
                        DialogueID.Success, new List<string> {
                        "Damn it. It�s like this room is trying to trap me.",
                        }
                    },
                    {
                        DialogueID.Dialogue3, new List<string> {
                        "Okay. Progress. But that chill in my spine isn�t going away.",
                        }
                    },
                    {
                        DialogueID.Dialogue4, new List<string> {
                        "Let�s see what�s next.",
                        }
                    },
                }
            },
            {
                RoomID.Room4, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "That sound... it�s heavier here. Like something deeper is going on.",
                        "These paths... different colors, different directions. Is this some kind of test?",
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "What the...? My reflection... is late. This isn�t just my mind playing tricks.",
                        }
                    },
                    {
                        DialogueID.Dialogue3, new List<string> { //Saat lagi puzzle
                        "These system logs� referencing things that haven�t happened yet? How is that even possible?",
                        }
                    },
                    {
                        DialogueID.Dialogue4, new List<string> {
                        "Hey�wait! What happened to you...? No... they�re not real. They can't be real.",
                        }
                    },
                    {
                        DialogueID.Dialogue5, new List<string> {
                        "Hold on... this wall�it doesn�t match. Something�s hidden here.",
                        "Whatever�s on the other side� I need to know. I can�t stop now.",
                        }
                    },
                }
            },
            {
                RoomID.Room5, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "Everything in here... it�s looping. Like it�s alive and stuck in its own memory.",
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "No, no... I�ve seen this. I�ve walked this path before. Haven�t I?",
                        "There�s something wrong in my mind. Like I�m sharing space with... with someone else.",
                        "Those aren�t reflections. They're echoes. Versions of me that never made it out?"
                        }
                    },
                    {
                        DialogueID.Success, new List<string> {
                        "Damn it. It�s like this room is trying to trap me.",
                        }
                    },
                    {
                        DialogueID.Dialogue3, new List<string> {
                        "These inputs... they�re mimicking past events. This isn�t just a loop�it�s a memory trap.",
                        "Okay... focus. Code is real. Code is real.",
                        }
                    },
                    {
                        DialogueID.Dialogue4, new List<string> { //Text To Choose Decision
                        "The capsule... it�s active. I could leave. I could just�go home.",
                        "But� if I go now, I may never know what happened. Why everyone�s gone. Why I�m still here.",
                        "This might be my only chance to find the truth.",
                        }
                    },
                    {
                        DialogueID.Dialogue5, new List<string> { // Ending 2 (BAD ENDING)
                        "I�ve seen enough. I can�t take this anymore... maybe it�s better not knowing.",
                        }
                    },
                    {
                        DialogueID.Dialogue6, new List<string> { // Ending 1 (GOOD ENDING)
                        "No. I need answers. I owe them that much.",
                        }
                    },
                }
            },
            {
                RoomID.Room6, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "This was the room we used to gather... where we shared stories, laughed�",
                        "They were just here. It�s like they vanished mid-sentence."
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "All the pieces from before... they�re here. Everything connects.",
                        }
                    },
                    {
                        DialogueID.Success, new List<string> {
                        "I remember this moment... we were happy. They were real.",
                        }
                    },
                    {
                        DialogueID.Dialogue3, new List<string> {
                        "The seventh room. That�s where this ends. Or maybe� where it all began.",
                        "I need to know the truth. No more running.",
                        }
                    },
                }
            },
            {
                RoomID.Status, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "This isn�t working. I need to find another clue.",
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "Something�s off. I�ll come back to this.",
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
