// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:45,x:34332,y:32545,varname:node_45,prsc:2|emission-8084-OUT,alpha-3254-OUT;n:type:ShaderForge.SFN_Tex2d,id:8369,x:31975,y:32543,varname:node_8369,prsc:2,ntxv:0,isnm:False|TEX-6285-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6285,x:31764,y:32567,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6285,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:6410,x:31975,y:32732,varname:node_6410,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7379,x:32369,y:32478,varname:node_7379,prsc:2|A-8369-R,B-6410-A;n:type:ShaderForge.SFN_Multiply,id:8084,x:32874,y:32524,varname:node_8084,prsc:2|A-7379-OUT,B-1906-OUT,C-6410-RGB;n:type:ShaderForge.SFN_ValueProperty,id:1906,x:32553,y:32680,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_1906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ComponentMask,id:8471,x:33272,y:32628,varname:node_8471,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-8369-RGB;n:type:ShaderForge.SFN_Add,id:2905,x:33525,y:32710,varname:node_2905,prsc:2|A-8471-R,B-8471-G,C-8471-B;n:type:ShaderForge.SFN_Divide,id:8981,x:33696,y:32710,varname:node_8981,prsc:2|A-2905-OUT,B-4207-OUT;n:type:ShaderForge.SFN_Vector1,id:4207,x:33525,y:32838,varname:node_4207,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:3254,x:33881,y:32710,varname:node_3254,prsc:2|A-8981-OUT,B-6410-A,C-555-OUT;n:type:ShaderForge.SFN_ValueProperty,id:555,x:33741,y:32946,ptovrint:False,ptlb:OpacityValue,ptin:_OpacityValue,varname:node_555,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:6285-1906-555;pass:END;sub:END;*/

Shader "Unlit/Alpha" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Intensity ("Intensity", Float ) = 2
        _OpacityValue ("OpacityValue", Float ) = 1
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
            uniform float _Intensity;
            uniform float _OpacityValue;
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
                float4 node_8369 = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float3 emissive = ((node_8369.r*i.vertexColor.a)*_Intensity*i.vertexColor.rgb);
                float3 finalColor = emissive;
                float3 node_8471 = node_8369.rgb.rgb;
                return fixed4(finalColor,(((node_8471.r+node_8471.g+node_8471.b)/3.0)*i.vertexColor.a*_OpacityValue));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
