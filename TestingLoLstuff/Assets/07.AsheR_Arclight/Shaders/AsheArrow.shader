// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4040,x:33133,y:32699,varname:node_4040,prsc:2|emission-4839-OUT,alpha-6623-OUT;n:type:ShaderForge.SFN_Color,id:812,x:32048,y:32973,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_812,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:0.3803922,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2,x:32173,y:32609,varname:node_2,prsc:2,tex:1d2ab7e0a41bc894c908b83d149aedd2,ntxv:0,isnm:False|TEX-6542-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6542,x:31963,y:32609,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6542,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1d2ab7e0a41bc894c908b83d149aedd2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5562,x:32350,y:32813,varname:node_5562,prsc:2|A-2-RGB,B-812-RGB;n:type:ShaderForge.SFN_Multiply,id:4839,x:32614,y:32817,varname:node_4839,prsc:2|A-5562-OUT,B-3864-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3864,x:32397,y:33104,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_3864,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:5069,x:32788,y:32924,varname:node_5069,prsc:2|A-2-R,B-812-A;n:type:ShaderForge.SFN_Multiply,id:6623,x:32948,y:32962,varname:node_6623,prsc:2|A-5069-OUT,B-3864-OUT;proporder:812-6542-3864;pass:END;sub:END;*/

Shader "Custom/AsheArrow" {
    Properties {
        _Color ("Color", Color) = (1,1,0.3803922,1)
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Intensity ("Intensity", Float ) = 2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _Intensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_2 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 emissive = ((node_2.rgb*_Color.rgb)*_Intensity);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,((node_2.r*_Color.a)*_Intensity));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
