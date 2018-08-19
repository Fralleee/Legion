// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:45,x:33998,y:32409,varname:node_45,prsc:2|emission-7469-OUT;n:type:ShaderForge.SFN_Tex2d,id:8369,x:32145,y:32547,varname:node_8369,prsc:2,tex:0db395877754f42408e59030899b556d,ntxv:0,isnm:False|TEX-6285-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6285,x:31910,y:32573,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6285,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0db395877754f42408e59030899b556d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:6410,x:31910,y:32764,varname:node_6410,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5614,x:32856,y:32681,varname:node_5614,prsc:2|A-8369-RGB,B-4776-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4776,x:32587,y:32784,ptovrint:False,ptlb:GlowExternal,ptin:_GlowExternal,varname:node_4776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Add,id:152,x:33271,y:32351,varname:node_152,prsc:2|A-5146-OUT,B-5614-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3093,x:31300,y:32136,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_3093,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:9397,x:31300,y:32225,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_9397,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Append,id:202,x:31517,y:32136,varname:node_202,prsc:2|A-3093-OUT,B-9397-OUT;n:type:ShaderForge.SFN_Multiply,id:9371,x:31739,y:32136,varname:node_9371,prsc:2|A-202-OUT,B-6994-T;n:type:ShaderForge.SFN_Time,id:6994,x:31517,y:32312,varname:node_6994,prsc:2;n:type:ShaderForge.SFN_Add,id:8110,x:31958,y:32191,varname:node_8110,prsc:2|A-9371-OUT,B-5924-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5924,x:31739,y:32282,varname:node_5924,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:6293,x:32662,y:32275,varname:node_6293,prsc:2|A-2425-RGB,B-8369-A;n:type:ShaderForge.SFN_Tex2d,id:2425,x:32155,y:32013,varname:node_2425,prsc:2,tex:31bc95004f0f0134591237a2fc2ee539,ntxv:0,isnm:False|UVIN-8110-OUT,TEX-5839-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5839,x:31958,y:32013,ptovrint:False,ptlb:ColorTexture,ptin:_ColorTexture,varname:node_5839,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:31bc95004f0f0134591237a2fc2ee539,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7469,x:33539,y:32528,varname:node_7469,prsc:2|A-152-OUT,B-6410-RGB,C-6410-A;n:type:ShaderForge.SFN_Multiply,id:5146,x:32904,y:32123,varname:node_5146,prsc:2|A-9167-OUT,B-6293-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9167,x:32610,y:32043,ptovrint:False,ptlb:GlowColors,ptin:_GlowColors,varname:node_9167,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;proporder:6285-4776-3093-9397-5839-9167;pass:END;sub:END;*/

Shader "Unlit/ArcadeArrowsAdd" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _GlowExternal ("GlowExternal", Float ) = 2
        _U_Speed ("U_Speed", Float ) = 1
        _V_Speed ("V_Speed", Float ) = 0.1
        _ColorTexture ("ColorTexture", 2D) = "white" {}
        _GlowColors ("GlowColors", Float ) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _GlowExternal;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform sampler2D _ColorTexture; uniform float4 _ColorTexture_ST;
            uniform float _GlowColors;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_6994 = _Time + _TimeEditor;
                float2 node_8110 = ((float2(_U_Speed,_V_Speed)*node_6994.g)+i.uv0);
                float4 node_2425 = tex2D(_ColorTexture,TRANSFORM_TEX(node_8110, _ColorTexture));
                float4 node_8369 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 emissive = (((_GlowColors*(node_2425.rgb*node_8369.a))+(node_8369.rgb*_GlowExternal))*i.vertexColor.rgb*i.vertexColor.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
