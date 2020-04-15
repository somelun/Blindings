using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]

public class BlindingShader : MonoBehaviour 
{
    public Shader shader;
	[Range(0, 1)] public float verts_force = 0.0f;
	[Range(0, 1)] public float verts_force_2 = 0.0f;
	[Range(-3, 20)] public float contrast = 0.0f;
	[Range(-200, 200)] public float brightness = 0.0f;
	public Color scanlineColor = Color.white;
	
    private Material _material;

    private float pixelStep;

    protected Material material {
        get {
            if(_material == null) {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if(shader == null) {
			return;
		}
		
        Material mat = material;
		mat.SetFloat("_Contrast", contrast);
		mat.SetFloat("_Br", brightness);
        mat.SetFloat("_Pixelization", GameState.Instance.PixelLevel);
        Graphics.Blit(source, destination, mat);

        if (GameState.Instance.PixelLevel < 256.0f) {
            GameState.Instance.PixelStep = 0.5f;
        } else if (GameState.Instance.PixelStep > 0.0f) {
            GameState.Instance.PixelStep = 2.0f;
        }

        if (GameState.Instance.PixelLevel > 30.0f) {
            GameState.Instance.PixelLevel -= GameState.Instance.PixelStep;
        }
    }

    void OnDisable() {
        if(_material) {
            DestroyImmediate(_material);
		}
    }
}
