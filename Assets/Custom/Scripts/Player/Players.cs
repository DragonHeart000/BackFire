using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Players : NetworkBehaviour{

    public static ArrayList players = new ArrayList();
    private static bool firstConnect = true;

    private static GameObject firstPlayer;
    private static GameObject secondPlayer;

	void Update () {
        //remove disconected players
		if (players.Contains(null))
        {
            players.Remove(null);
        }
	}

    public static void addPlayer(GameObject toAdd)
    {
        //First connect is host so will never need to change.
        if (firstConnect)
        {
            firstPlayer = toAdd;
            firstConnect = false;
        } else
        {
            secondPlayer = toAdd;
            firstPlayer.GetComponent<PlayerShoot>().setOpponent(secondPlayer);
            secondPlayer.GetComponent<PlayerShoot>().setOpponent(firstPlayer);
        }
        players.Add(toAdd);
    }

    public static ArrayList getPlayers()
    {
        return players;
    }
}
