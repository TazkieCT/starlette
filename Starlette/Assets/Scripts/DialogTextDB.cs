using System.Collections.Generic;
using UnityEngine;

public enum RoomID
{
    Room1,
    Room2,
    Room3
}

public enum DialogueID
{
    Dialogue1,
    Dialogue2,
    Dialogue3 
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
                        "Ini ruang mesin. Segalanya tampak stabil untuk saat ini.",
                        "Tapi aku mendeteksi getaran tak biasa..."
                        }
                    },
                    { 
                        DialogueID.Dialogue2, new List<string> {
                        "Perhatian! Terdapat lonjakan suhu di reaktor.",
                        "Segera keluar dari ruangan ini."
                        }
                    },
                }
            },
            {
                RoomID.Room2, new Dictionary<DialogueID, List<string>>
                {
                    {
                        DialogueID.Dialogue1, new List<string> {
                        "Ini ruang mesin. Segalanya tampak stabil untuk saat ini.",
                        "Tapi aku mendeteksi getaran tak biasa..."
                        }
                    },
                    {
                        DialogueID.Dialogue2, new List<string> {
                        "Perhatian! Terdapat lonjakan suhu di reaktor.",
                        "Segera keluar dari ruangan ini."
                        }
                    },
                }
            }
        };
    }

    public List<string> GetDialogueLines(RoomID room, DialogueID id)
    {
        if (dialogueDatabase.ContainsKey(room) && dialogueDatabase[room].ContainsKey(id))
            return dialogueDatabase[room][id];

        return new List<string> { "Dialogue not found." };
    }
}
