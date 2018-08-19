// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:Particles/Additive,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:6652,x:34977,y:32674,varname:node_6652,prsc:2|emission-1569-OUT;n:type:ShaderForge.SFN_VertexColor,id:207,x:32089,y:32851,varname:node_207,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:7393,x:32277,y:33032,varname:node_7393,prsc:2,tex:3c57a54ede1a9e545bb2f0ca97cd7cd2,ntxv:0,isnm:False|UVIN-1526-OUT,TEX-7505-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7505,x:32102,y:33032,ptovrint:False,ptlb:TrailTexture,ptin:_TrailTexture,varname:node_7505,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3c57a54ede1a9e545bb2f0ca97cd7cd2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3602,x:32701,y:32849,varname:node_3602,prsc:2|A-207-A,B-7393-RGB;n:type:ShaderForge.SFN_Multiply,id:850,x:32926,y:32770,varname:node_850,prsc:2|A-207-RGB,B-3602-OUT;n:type:ShaderForge.SFN_Multiply,id:92,x:33173,y:32841,varname:node_92,prsc:2|A-850-OUT,B-3222-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3222,x:32938,y:33008,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_3222,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_TexCoord,id:3841,x:31487,y:32989,varname:node_3841,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:7490,x:31741,y:32989,varname:node_7490,prsc:2|A-1632-OUT,B-3841-U;n:type:ShaderForge.SFN_ValueProperty,id:3129,x:31487,y:33280,ptovrint:False,ptlb:V_Offset,ptin:_V_Offset,varname:node_3129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:1632,x:31487,y:33197,ptovrint:False,ptlb:U_Offset,ptin:_U_Offset,varname:node_1632,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:1496,x:31741,y:33119,varname:node_1496,prsc:2|A-3841-V,B-3129-OUT;n:type:ShaderForge.SFN_Append,id:1526,x:31940,y:33049,varname:node_1526,prsc:2|A-7490-OUT,B-1496-OUT;n:type:ShaderForge.SFN_Multiply,id:8021,x:33482,y:32792,varname:node_8021,prsc:2|A-92-OUT,B-2400-OUT;n:type:ShaderForge.SFN_DepthBlend,id:2400,x:33267,y:33095,varname:node_2400,prsc:2|DIST-2917-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2917,x:33066,y:33142,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_2917,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:7887,x:33831,y:32759,varname:node_7887,prsc:2|A-5086-RGB,B-8021-OUT;n:type:ShaderForge.SFN_Color,id:5086,x:33585,y:32578,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5086,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4383,x:34186,y:32732,varname:node_4383,prsc:2|A-7887-OUT,B-3355-RGB;n:type:ShaderForge.SFN_Tex2d,id:3355,x:34001,y:32901,varname:node_3355,prsc:2,tex:8a3eab01d8154c74d918e3a795b573d5,ntxv:0,isnm:False|TEX-2323-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2323,x:33831,y:32925,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_2323,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8a3eab01d8154c74d918e3a795b573d5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1569,x:34605,y:32720,varname:node_1569,prsc:2|A-6354-OUT,B-4383-OUT;n:type:ShaderForge.SFN_Tex2d,id:50,x:34346,y:32539,varname:node_50,prsc:2,ntxv:0,isnm:False|TEX-1391-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1391,x:34186,y:32539,ptovrint:False,ptlb:ColorMask,ptin:_ColorMask,varname:node_1391,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6354,x:34624,y:32469,varname:node_6354,prsc:2|A-5303-OUT,B-50-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5303,x:34363,y:32459,ptovrint:False,ptlb:ColorValue,ptin:_ColorValue,varname:node_5303,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:7505-3222-3129-1632-2917-5086-2323-1391-5303;pass:END;sub:END;*/

Shader "Custom/VC_OffsetTrail_Additive_v2" {
    Properties {
        _TrailTexture ("TrailTexture", 2D) = "white" {}
        _Intensity ("Intensity", Float ) = 1.5
        _V_Offset ("V_Offset", Float ) = 0
        _U_Offset ("U_Offset", Float ) = 0
        _Depth ("Depth", Float ) = 0.5
        _Color ("Color", Color) = (1,1,1,1)
        _Mask ("Mask", 2D) = "white" {}
        _ColorMask ("ColorMask", 2D) = "white" {}
        _ColorValue ("ColorValue", Float ) = 1
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
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _TrailTexture; uniform float4 _TrailTexture_ST;
            uniform float _Intensity;
            uniform float _V_Offset;
            uniform float _U_Offset;
            uniform float _Depth;
            uniform float4 _Color;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _ColorMask; uniform float4 _ColorMask_ST;
            uniform float _ColorValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float4 node_50 = tex2D(_ColorMask,TRANSFORM_TEX(i.uv0, _ColorMask));
                float2 node_1526 = float2((_U_Offset+i.uv0.r),(i.uv0.g+_V_Offset));
                float4 node_7393 = tex2D(_TrailTexture,TRANSFORM_TEX(node_1526, _TrailTexture));
                float node_2400 = saturate((sceneZ-partZ)/_Depth);
                float4 node_3355 = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = ((_ColorValue*node_50.rgb)*((_Color.rgb*(((i.vertexColor.rgb*(i.vertexColor.a*node_7393.rgb))*_Intensity)*node_2400))*node_3355.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Particles/Additive"
    CustomEditor "ShaderForgeMaterialInspector"
}
