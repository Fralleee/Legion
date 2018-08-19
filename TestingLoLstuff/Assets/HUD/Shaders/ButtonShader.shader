// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "PW_GUI/ButtonShader" {
    Properties {
        _MainTex ("MainTexture", 2D) = "white" {}
        _GlowValue ("GlowValue", Float ) = 2
        [HDR]_Color ("Color", Color) = (0.7612573,0.2132353,1,1)
        _Mask ("Mask", 2D) = "white" {}
        _GradientAdd ("GradientAdd", Float ) = 0.8
        _FinalExponent ("FinalExponent", Float ) = 1.5
        _ColorImpact ("ColorImpact", Float ) = 0.2
        _SwirlsImpact ("SwirlsImpact", Float ) = 3
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            Cull Off
            Lighting Off
            Fog { Mode Off }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            //#pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma multi_compile DUMMY PIXELSNAP_ON
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _GlowValue;
            uniform float4 _Color;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _GradientAdd;
            uniform float _FinalExponent;
            uniform float _ColorImpact;
            uniform float _SwirlsImpact;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_587 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_8600 = (((node_587.rgb*_GlowValue)*node_587.a)*(_Color.rgb*_ColorImpact));
                float4 node_3258 = _Time + _TimeEditor;
                float2 node_1561 = (i.uv0+node_3258.g*float2(-0.231,-0.05));
                float4 node_9735 = tex2D(_Mask,TRANSFORM_TEX(node_1561, _Mask));
                float2 node_1354 = (i.uv0+node_3258.g*float2(-0.121,0.09));
                float4 node_1448 = tex2D(_Mask,TRANSFORM_TEX(node_1354, _Mask));
                float3 emissive = pow((_GradientAdd*(node_8600+(node_8600*((node_9735.r*node_1448.r)*_SwirlsImpact)))),_FinalExponent);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
