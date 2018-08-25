Shader "Azert2k/Vertex/ToonCubeMap/OptimizedClassicOutline" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (.002, 0.06)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" { }
		_ToonShade ("ToonShader Cubemap(RGB)", CUBE) = "" { Texgen CubeNormal }
	}
	
	CGINCLUDE
	#include "UnityCG.cginc"
	
	struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : POSITION;
		fixed4 color : COLOR;
	};
	
	uniform fixed _Outline;
	uniform float4 _OutlineColor;
	
	v2f vert(appdata v) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		fixed3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
		fixed2 offset = TransformViewToProjection(norm.xy);
		o.pos.xy += offset * _Outline;
		o.color = _OutlineColor;
		return o;
	}
	ENDCG

	SubShader {
		Tags { "RenderType" = "Opaque" }
		UsePass "Azert2k/Vertex/ToonCubeMap/OptimizedClassic/BASE"
		Pass {
			Name "OUTLINE"
			Cull Front
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			fixed4 frag(v2f i) :COLOR { return i.color; }
			ENDCG
		}
	}
}
