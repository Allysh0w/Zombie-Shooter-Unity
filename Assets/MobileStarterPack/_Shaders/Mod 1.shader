
Shader "Unlit/Mod" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
}

SubShader {
	Tags {"IgnoreProjector"="True" }
	LOD 100
	

	Pass {
		Lighting Off
		
		SetTexture [_MainTex] { constantColor [_Color] combine texture * constant  } 
	}
}
}