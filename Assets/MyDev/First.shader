Shader "Unlit/First"
{
		Properties{
			_MainColor("MainColor",COLOR) = (1,1,1,1)
			_SecondColor("SecondColor",COLOR) = (1,1,1,1)
		}
		SubShader{
			pass{
				Tags{
					"LightMode" = "ForwardBase"
				}
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"
				#include "Lighting.cginc"

				float4 _MainColor;
				float4 _SecondColor;

				struct v2f{
				float4 pos:POSITION;
				float4 col:TEXCOORD0;
				};

				v2f vert(appdata_base v){
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				if(v.vertex.y>0)
				o.col=_MainColor;
				else
				o.col=_SecondColor;
				return o;
				}

				float4 frag(v2f IN):COLOR{
				
				return IN.col;
				}
				ENDCG
			}
		}
		FallBack "Diffuse"

}