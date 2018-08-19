// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:45,x:34206,y:32925,varname:node_45,prsc:2|emission-6410-RGB,alpha-967-OUT;n:type:ShaderForge.SFN_Tex2d,id:8369,x:31975,y:32543,varname:node_8369,prsc:2,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False|TEX-6285-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6285,x:31764,y:32567,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6285,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:6410,x:31513,y:32852,varname:node_6410,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7379,x:32369,y:32478,varname:node_7379,prsc:2|A-8369-R,B-6410-A;n:type:ShaderForge.SFN_Multiply,id:8084,x:32874,y:32524,varname:node_8084,prsc:2|A-7379-OUT,B-1906-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1906,x:32553,y:32680,ptovrint:False,ptlb:Strength,ptin:_Strength,varname:node_1906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_TexCoord,id:9306,x:32044,y:33112,varname:node_9306,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:1578,x:32265,y:33112,varname:node_1578,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9306-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:5852,x:32446,y:33112,varname:node_5852,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1578-OUT;n:type:ShaderForge.SFN_ArcTan2,id:2940,x:32635,y:33112,varname:node_2940,prsc:2,attp:2|A-5852-G,B-5852-R;n:type:ShaderForge.SFN_Tex2d,id:9009,x:32844,y:33371,varname:node_9009,prsc:2,tex:576d12ea4699bb64cac10a1eb05374ba,ntxv:0,isnm:False|UVIN-171-OUT,TEX-2424-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2424,x:32608,y:33371,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_2424,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:576d12ea4699bb64cac10a1eb05374ba,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:171,x:32844,y:33149,varname:node_171,prsc:2|A-2940-OUT,B-9228-OUT;n:type:ShaderForge.SFN_Vector1,id:9228,x:32635,y:33263,varname:node_9228,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:8959,x:32223,y:33681,varname:node_8959,prsc:2,tex:45ecdd6d6c88d8642938462c3a008265,ntxv:0,isnm:False|TEX-3375-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:3375,x:32023,y:33681,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_3375,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:45ecdd6d6c88d8642938462c3a008265,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:9896,x:32546,y:33576,varname:node_9896,prsc:2|A-4803-OUT,B-8959-R;n:type:ShaderForge.SFN_RemapRange,id:4803,x:32223,y:33458,varname:node_4803,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-6410-A;n:type:ShaderForge.SFN_Multiply,id:8330,x:33505,y:33078,varname:node_8330,prsc:2|A-8084-OUT,B-5009-OUT;n:type:ShaderForge.SFN_Power,id:5009,x:33276,y:33181,varname:node_5009,prsc:2|VAL-9896-OUT,EXP-6426-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6426,x:33094,y:33504,ptovrint:False,ptlb:DissolvePower,ptin:_DissolvePower,varname:node_6426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:967,x:33936,y:33176,varname:node_967,prsc:2|A-8330-OUT,B-2918-OUT;n:type:ShaderForge.SFN_DepthBlend,id:2918,x:33745,y:33447,varname:node_2918,prsc:2|DIST-7587-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7587,x:33528,y:33376,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_7587,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:6285-1906-3375-6426-7587;pass:END;sub:END;*/

Shader "Unlit/SubDissolve" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Strength ("Strength", Float ) = 2
        _Noise ("Noise", 2D) = "white" {}
        _DissolvePower ("DissolvePower", Float ) = 2
        _Depth ("Depth", Float ) = 0
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
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform float _Strength;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _DissolvePower;
            uniform float _Depth;
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
                float3 emissive = i.vertexColor.rgb;
                float3 finalColor = emissive;
                float4 node_8369 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float4 node_8959 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                return fixed4(finalColor,((((node_8369.r*i.vertexColor.a)*_Strength)*pow(((i.vertexColor.a*2.0+-1.0)+node_8959.r),_DissolvePower))*saturate((sceneZ-partZ)/_Depth)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
