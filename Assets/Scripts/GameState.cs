using UnityEngine;
using System.Collections;

public class GameState {

	protected GameState() {}
	private static GameState _instance = null;

	private float _pixelLevel;
	private bool _isGasAtomized;
	private GameObject _player;

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
    	_pixelLevel = 1024.0f;
    }

    public void StartGame() {
    	_player = GameObject.Find("Player");

    	_player.GetComponent<Move>().enabled = true;
    	_player.GetComponent<MouseLook>().enabled = true;
    }

    public bool isGasAtomized {
    	get {
            return _isGasAtomized;
        }
        set {
            _isGasAtomized = value;
        }
    }

    public float PixelLevel {
    	get {
            return _pixelLevel;
        }
        set {
            _pixelLevel = value;
        }	
    }
}
