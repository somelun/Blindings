using UnityEngine;
using System.Collections;

public class GameState {

	protected GameState() {}
	private static GameState _instance = null;

	private bool _isGasAtomized;

	public GameObject player;

	public static GameState Instance { 
		get {
        	if(GameState._instance == null) {
        		GameState._instance = new GameState();
        		GameState._instance.Init();
        	}
        	return GameState._instance;
    	}
    }

    private void Init() {
    	_isGasAtomized = false;
    }

    public bool isGasAtomized {
    	get {
            return _isGasAtomized;
        }
        set {
            _isGasAtomized = value;
        }
    }

    public void StartGame() {
    	player = GameObject.Find("Player");

    	player.GetComponent<Move>().enabled = true;
    	player.GetComponent<MouseLook>().enabled = true;
    }
}
