Shader "Unlit/HighlightShader_v1"
{
	Properties
	{
		_Color ("Highlight Color", Color) = (0,0,0, 1)
		_Line ("Highlight Thickness", Float) = 0.15
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CULL FRONT

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};
						
			float _Line;

			v2f vert (appdata v)
			{
				v2f o;
				float4 vert = v.vertex + 0.00001f * _Line *float4(normalize(v.normal), 0);
				o.vertex = UnityObjectToClipPos(vert);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			float4 _Color;
			
			fixed4 frag (v2f i) : SV_Target
			{
				// apply color
				fixed4 col = _Color;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
