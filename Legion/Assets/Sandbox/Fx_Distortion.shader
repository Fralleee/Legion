// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:0,qpre:4,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3235,x:33789,y:32617,varname:node_3235,prsc:2|emission-8077-RGB,alpha-1532-OUT,refract-3907-OUT;n:type:ShaderForge.SFN_Multiply,id:8459,x:32176,y:32795,varname:node_8459,prsc:2|A-8077-A,B-6499-RGB,C-8077-RGB;n:type:ShaderForge.SFN_VertexColor,id:8077,x:31632,y:32609,varname:node_8077,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6499,x:31929,y:32961,varname:node_6499,prsc:2,tex:64b78543cebb1cd44a8650ab1f211f66,ntxv:0,isnm:False|TEX-1134-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:1134,x:31767,y:32961,ptovrint:False,ptlb:DistortionTexture,ptin:_DistortionTexture,varname:node_1134,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:64b78543cebb1cd44a8650ab1f211f66,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:6553,x:32352,y:32795,varname:node_6553,prsc:2,cc1:1,cc2:2,cc3:-1,cc4:-1|IN-8459-OUT;n:type:ShaderForge.SFN_Multiply,id:4023,x:32581,y:32621,varname:node_4023,prsc:2|A-578-OUT,B-6553-OUT;n:type:ShaderForge.SFN_ValueProperty,id:578,x:31986,y:32492,ptovrint:False,ptlb:DistortionValue,ptin:_DistortionValue,varname:node_578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:8334,x:32749,y:32647,varname:node_8334,prsc:2|A-4023-OUT,B-9556-OUT;n:type:ShaderForge.SFN_Fresnel,id:5618,x:32520,y:32944,varname:node_5618,prsc:2|EXP-2407-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2407,x:32183,y:33156,ptovrint:False,ptlb:FresnelValue,ptin:_FresnelValue,varname:node_2407,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.25;n:type:ShaderForge.SFN_OneMinus,id:9556,x:32677,y:32944,varname:node_9556,prsc:2|IN-5618-OUT;n:type:ShaderForge.SFN_Multiply,id:2223,x:32937,y:32621,varname:node_2223,prsc:2|A-8334-OUT,B-6959-OUT;n:type:ShaderForge.SFN_DepthBlend,id:6959,x:32749,y:32487,varname:node_6959,prsc:2|DIST-1842-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1842,x:32581,y:32521,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_1842,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:3907,x:32937,y:32758,varname:node_3907,prsc:2|A-2223-OUT,B-8077-A;n:type:ShaderForge.SFN_Add,id:8265,x:33272,y:32783,varname:node_8265,prsc:2|A-4879-R,B-4879-G;n:type:ShaderForge.SFN_ComponentMask,id:4879,x:33105,y:32758,varname:node_4879,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3907-OUT;n:type:ShaderForge.SFN_Multiply,id:1532,x:33532,y:32758,varname:node_1532,prsc:2|A-8265-OUT,B-5678-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5678,x:33272,y:33051,ptovrint:False,ptlb:OpacityMultiplier,ptin:_OpacityMultiplier,varname:node_5678,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;proporder:1134-578-2407-1842-5678;pass:END;sub:END;*/

Shader "Custom/Distortion" {
    Properties {
        _DistortionTexture ("DistortionTexture", 2D) = "white" {}
        _DistortionValue ("DistortionValue", Float ) = 0.1
        _FresnelValue ("FresnelValue", Float ) = 1.25
        _Depth ("Depth", Float ) = 0.5
        _OpacityMultiplier ("OpacityMultiplier", Float ) = 2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay"
            "RenderType"="Transparent"
        }
        LOD 200
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _DistortionTexture; uniform float4 _DistortionTexture_ST;
            uniform float _DistortionValue;
            uniform float _FresnelValue;
            uniform float _Depth;
            uniform float _OpacityMultiplier;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 screenPos : TEXCOORD3;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_6499 = tex2D(_DistortionTexture,TRANSFORM_TEX(i.uv0, _DistortionTexture));
                float2 node_3907 = ((((_DistortionValue*(i.vertexColor.a*node_6499.rgb*i.vertexColor.rgb).gb)*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelValue)))*saturate((sceneZ-partZ)/_Depth))*i.vertexColor.a);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + node_3907;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float3 emissive = i.vertexColor.rgb;
                float3 finalColor = emissive;
                float2 node_4879 = node_3907.rg;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,((node_4879.r+node_4879.g)*_OpacityMultiplier)),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
