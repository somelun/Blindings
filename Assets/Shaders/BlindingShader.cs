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

    private float pixelLevel;
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

    private void Start() {
        pixelLevel = 256.0f;
        pixelStep = 0.0f;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if(shader == null) {
			return;
		}
		
        Material mat = material;
		mat.SetFloat("_Contrast", contrast);
		mat.SetFloat("_Br", brightness);
        mat.SetFloat("_Pixelization", pixelLevel);
        Graphics.Blit(source, destination, mat);

        if (pixelLevel > 256) {
            pixelStep = 0.2f;
        }

        if (pixelLevel > 48) {
            pixelLevel -= pixelStep;
        }
    }

    void OnDisable() {
        if(_material) {
            DestroyImmediate(_material);
		}
    }
}
