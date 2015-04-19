using UnityEngine;
using System.Collections;

public class GameState {

	protected GameState() {}
	private static GameState _instance = null;

	private bool _isGasAtomized;
	private GameObject _player;

	private float _pixelLevel;
	private float _pixelStep;

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
    	_pixelStep = 0.0f;
    }

    public void StartGame() {
    	_player = GameObject.Find("Player");
    	_player.GetComponent<Move>().enabled = true;
    	_player.GetComponent<MouseLook>().enabled = true;

    	_pixelStep = 2.0f;
    }

    public void GameOver(bool isWin) {
        if (isWin) {
            Debug.Log("win");
        } else {
            this.Init();
            Application.LoadLevel("EmptyScene");
        }
    }

    public void Restart() {
        this.Init();
        Application.LoadLevel(Application.loadedLevel);
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

    public float PixelStep {
    	get {
            return _pixelStep;
        }
        set {
            _pixelStep = value;
        }	
    }

}
