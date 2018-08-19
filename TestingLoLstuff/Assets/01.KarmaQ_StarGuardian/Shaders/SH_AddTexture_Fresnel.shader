// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:45,x:34007,y:32456,varname:node_45,prsc:2|emission-6129-OUT;n:type:ShaderForge.SFN_Tex2d,id:8369,x:32174,y:32663,varname:node_8369,prsc:2,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False|TEX-6285-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6285,x:31984,y:32663,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6285,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1494,x:32403,y:32663,varname:node_1494,prsc:2|A-8369-RGB,B-6410-A,C-6410-RGB;n:type:ShaderForge.SFN_VertexColor,id:6410,x:31984,y:32835,varname:node_6410,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5614,x:32793,y:32695,varname:node_5614,prsc:2|A-1494-OUT,B-4776-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4776,x:32587,y:32784,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_4776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:2284,x:33008,y:32677,varname:node_2284,prsc:2|A-5614-OUT,B-5225-OUT;n:type:ShaderForge.SFN_DepthBlend,id:5225,x:32700,y:32888,varname:node_5225,prsc:2|DIST-3936-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3936,x:32423,y:32929,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_3936,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;n:type:ShaderForge.SFN_Multiply,id:965,x:33398,y:32557,varname:node_965,prsc:2|A-2284-OUT,B-8571-OUT;n:type:ShaderForge.SFN_Fresnel,id:5327,x:33008,y:32835,varname:node_5327,prsc:2|EXP-4484-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4484,x:32840,y:32971,ptovrint:False,ptlb:FresnelExp,ptin:_FresnelExp,varname:node_4484,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_OneMinus,id:8571,x:33363,y:32800,varname:node_8571,prsc:2|IN-1204-OUT;n:type:ShaderForge.SFN_Multiply,id:1204,x:33279,y:32925,varname:node_1204,prsc:2|A-5327-OUT,B-3185-OUT;n:type:ShaderForge.SFN_Power,id:3185,x:33118,y:33024,varname:node_3185,prsc:2|VAL-5327-OUT,EXP-3960-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3960,x:32961,y:33132,ptovrint:False,ptlb:FresnelPow,ptin:_FresnelPow,varname:node_3960,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:6129,x:33748,y:32610,varname:node_6129,prsc:2|A-965-OUT,B-3229-RGB;n:type:ShaderForge.SFN_Color,id:3229,x:33550,y:32813,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3229,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;proporder:6285-4776-3936-4484-3960-3229;pass:END;sub:END;*/

Shader "Unlit/AddFresnel" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Glow ("Glow", Float ) = 1.5
        _Depth ("Depth", Float ) = 0.25
        _FresnelExp ("FresnelExp", Float ) = 1
        _FresnelPow ("FresnelPow", Float ) = 2
        _Color ("Color", Color) = (1,1,1,1)
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
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _Glow;
            uniform float _Depth;
            uniform float _FresnelExp;
            uniform float _FresnelPow;
            uniform float4 _Color;
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
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float4 node_8369 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float node_5327 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExp);
                float3 emissive = (((((node_8369.rgb*i.vertexColor.a*i.vertexColor.rgb)*_Glow)*saturate((sceneZ-partZ)/_Depth))*(1.0 - (node_5327*pow(node_5327,_FresnelPow))))*_Color.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
