// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:45,x:33863,y:32963,varname:node_45,prsc:2|emission-6410-RGB,alpha-8330-OUT;n:type:ShaderForge.SFN_Tex2d,id:8369,x:31980,y:32493,varname:node_8369,prsc:2,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False|TEX-6285-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6285,x:31764,y:32567,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6285,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3ef1fbbc90b062c41bca10ede1df9e5e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:6410,x:31513,y:32852,varname:node_6410,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8084,x:32874,y:32524,varname:node_8084,prsc:2|A-8369-R,B-1906-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1906,x:32553,y:32680,ptovrint:False,ptlb:Strength,ptin:_Strength,varname:node_1906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Tex2d,id:8959,x:32223,y:33681,varname:node_8959,prsc:2,tex:45ecdd6d6c88d8642938462c3a008265,ntxv:0,isnm:False|TEX-3375-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:3375,x:32023,y:33681,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_3375,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:45ecdd6d6c88d8642938462c3a008265,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:9896,x:32546,y:33576,varname:node_9896,prsc:2|A-4803-OUT,B-8959-R;n:type:ShaderForge.SFN_RemapRange,id:4803,x:32223,y:33458,varname:node_4803,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-6410-A;n:type:ShaderForge.SFN_Multiply,id:8330,x:33505,y:33078,varname:node_8330,prsc:2|A-8084-OUT,B-5009-OUT;n:type:ShaderForge.SFN_Power,id:5009,x:33276,y:33181,varname:node_5009,prsc:2|VAL-9896-OUT,EXP-6426-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6426,x:33094,y:33504,ptovrint:False,ptlb:DissolvePower,ptin:_DissolvePower,varname:node_6426,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;proporder:6285-1906-3375-6426;pass:END;sub:END;*/

Shader "Unlit/SubDissolve_NoAlpha" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Strength ("Strength", Float ) = 2
        _Noise ("Noise", 2D) = "white" {}
        _DissolvePower ("DissolvePower", Float ) = 2
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
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _Strength;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _DissolvePower;
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
                float3 emissive = i.vertexColor.rgb;
                float3 finalColor = emissive;
                float4 node_8369 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float4 node_8959 = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                return fixed4(finalColor,((node_8369.r*_Strength)*pow(((i.vertexColor.a*2.0+-1.0)+node_8959.r),_DissolvePower)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
