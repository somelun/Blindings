Shader "Custom/BlindingShader" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
		_Contrast("Contrast", Float) = 0
		_Br("Brightness", Float) = 0
		_Pixelization("Pixelization", Float) = 0
    }

    SubShader {
        Pass {
            ZTest Always Cull Off ZWrite Off Fog { Mode off }

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "UnityCG.cginc"
            #pragma target 3.0

            struct vert_out {
                float4 pos      : POSITION;
                float2 uv       : TEXCOORD0;
				float4 scr_pos  : TEXCOORD1;
            };

            uniform sampler2D _MainTex;
			uniform float _Contrast;
			uniform float _Br;
			uniform float _Pixelization;

            vert_out vert(appdata_base v) {
                vert_out o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
				o.scr_pos = ComputeScreenPos(o.pos);
                return o;
            }
			
			half4 frag(vert_out i): COLOR {
				float2 uv = i.uv;
				
				// pixelesation
				float2 pixel_resolution = float2(_Pixelization, _Pixelization * _ScreenParams.y / _ScreenParams.x);
				uv = floor(uv * pixel_resolution) / pixel_resolution;
				
                half4 color = tex2D(_MainTex, uv);
				
				float2 ps = i.scr_pos.xy * _ScreenParams.xy / i.scr_pos.w;
				
				// brightness + contrast
				color += (_Br / 255);
				color = color - _Contrast * (color - 1.0) * color *(color - 0.5);
				
				// a little bit greener
				color *= float4(0.95, 1.13, 0.95, 1.0);
					
				return color;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
