// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:6,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:45,x:33749,y:32555,varname:node_45,prsc:2|emission-7766-OUT,alpha-196-OUT;n:type:ShaderForge.SFN_Tex2d,id:8369,x:32174,y:32663,varname:node_8369,prsc:2,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False|TEX-6285-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6285,x:31984,y:32663,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6285,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1494,x:32403,y:32663,varname:node_1494,prsc:2|A-8369-RGB,B-6410-A,C-6410-RGB;n:type:ShaderForge.SFN_VertexColor,id:6410,x:31984,y:32835,varname:node_6410,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5614,x:32793,y:32695,varname:node_5614,prsc:2|A-1494-OUT,B-4776-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4776,x:32587,y:32784,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_4776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:2284,x:33008,y:32677,varname:node_2284,prsc:2|A-5614-OUT,B-5225-OUT;n:type:ShaderForge.SFN_DepthBlend,id:5225,x:32638,y:32882,varname:node_5225,prsc:2|DIST-3936-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3936,x:32423,y:32929,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_3936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_Tex2d,id:2922,x:31647,y:33586,varname:node_8959,prsc:2,tex:45ecdd6d6c88d8642938462c3a008265,ntxv:0,isnm:False|TEX-8746-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8746,x:31447,y:33586,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_3375,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:45ecdd6d6c88d8642938462c3a008265,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:1562,x:31970,y:33481,varname:node_1562,prsc:2|A-3841-OUT,B-2922-R;n:type:ShaderForge.SFN_RemapRange,id:3841,x:31647,y:33363,varname:node_3841,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-6410-A;n:type:ShaderForge.SFN_ValueProperty,id:6249,x:32518,y:33409,ptovrint:False,ptlb:DissolvePower,ptin:_DissolvePower,varname:node_6426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Power,id:1270,x:32700,y:33086,varname:node_1270,prsc:2|VAL-1562-OUT,EXP-6249-OUT;n:type:ShaderForge.SFN_Multiply,id:746,x:32929,y:32983,varname:node_746,prsc:2|A-2284-OUT,B-1270-OUT;n:type:ShaderForge.SFN_Multiply,id:7766,x:33513,y:32729,varname:node_7766,prsc:2|A-746-OUT,B-196-OUT;n:type:ShaderForge.SFN_ValueProperty,id:196,x:33345,y:32801,ptovrint:False,ptlb:FinalOpacity,ptin:_FinalOpacity,varname:node_196,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:6285-4776-3936-8746-6249-196;pass:END;sub:END;*/

Shader "Unlit/AddDissolve" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Glow ("Glow", Float ) = 1.5
        _Depth ("Depth", Float ) = 0.25
        _Noise ("Noise", 2D) = "white" {}
        _DissolvePower ("DissolvePower", Float ) = 2
        _FinalOpacity ("FinalOpacity", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend One OneMinusSrcColor
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
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _Glow;
            uniform float _Depth;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _DissolvePower;
            uniform float _FinalOpacity;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
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
                float4 node_8369 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float4 node_8959 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 emissive = (((((node_8369.rgb*i.vertexColor.a*i.vertexColor.rgb)*_Glow)*saturate((sceneZ-partZ)/_Depth))*pow(((i.vertexColor.a*2.0+-1.0)+node_8959.r),_DissolvePower))*_FinalOpacity);
                float3 finalColor = emissive;
                return fixed4(finalColor,_FinalOpacity);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
