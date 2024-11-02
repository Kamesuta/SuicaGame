using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Colyseus;
using static Dissonity.Api;
using TMPro;

// You need to place the generated C# classes from running "npm run colyseus"
// inside the Unity project.

public class MyScript : MonoBehaviour
{
    ColyseusClient client;
    public ColyseusRoom<GameState> room;

    TextMeshProUGUI scoreText;

    async void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        
        Debug.Log("Starting Multiplayer");
        scoreText.text = "Starting Multiplayer";

        //\ Get necessary Discord data
        string instanceId = await GetSDKInstanceId();
        string userId = await GetUserId();
        string username = (await GetUser()).display_name;

        scoreText.text = $"Initiating {instanceId} {userId}";

        //\ Connect to matchmaking room
        // (This implementation can be improved, but this should do)
        client = new ColyseusClient("wss://1222460903975419914.discordsays.com/.proxy");
        var matchmakingRoom = await client.Create<MatchmakingState>("matchmaking", new Dictionary<string, object>{{ "instanceId", instanceId }});

        scoreText.text = $"Connecting {instanceId} {userId}";

        // Listen for matchmaking room instructions
        matchmakingRoom.OnMessage<Dictionary<string, object>>("matchmake", async data => {

            //\ Leave matchmaking room
            await matchmakingRoom.Leave();

            //? Room already exists
            if ((bool) data["exists"]) {

                //\ Join the existing activity room
                room = await client.JoinById<GameState>(instanceId, new Dictionary<string, object>{{ "userId", userId }, { "username", username }});

                // Client is now connected to the room!
                Debug.Log("Client is now connected to the room!");
                scoreText.text = "Client is now connected to the room!";
            }

            //? Doesn't exist
            else {

                //\ Create the activity room
                room = await client.Create<GameState>("game", new Dictionary<string, object>{{ "instanceId", instanceId }, { "userId", userId }, { "username", username }});

                // Client is now connected to the room!
                Debug.Log("Client is now connected to the new room!");
                scoreText.text = "Client is now connected to the new room!";
            }

            room.OnStateChange += (state, isFirstState) => {
                scoreText.text = string.Join("\n", state.players.Values.Cast<Player>().Select(player => $"{player.username}: {player.score}"));
                Debug.Log("State has changed!");
            };
        });
    }
}
