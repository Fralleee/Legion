// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Particles/Additive,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:5303,x:34881,y:32681,varname:node_5303,prsc:2|emission-4895-OUT,alpha-102-OUT;n:type:ShaderForge.SFN_Tex2d,id:6403,x:32244,y:32687,varname:node_6403,prsc:2,ntxv:0,isnm:False|UVIN-4628-OUT,TEX-778-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:778,x:32077,y:32687,ptovrint:False,ptlb:ParallaxTexture,ptin:_ParallaxTexture,varname:node_778,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:9894,x:32069,y:33017,ptovrint:False,ptlb:MaskTexture,ptin:_MaskTexture,varname:node_9894,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:143,x:32244,y:32919,varname:node_143,prsc:2,ntxv:0,isnm:False|UVIN-114-UVOUT,TEX-9894-TEX;n:type:ShaderForge.SFN_Multiply,id:9675,x:32493,y:32751,varname:node_9675,prsc:2|A-6403-RGB,B-143-RGB;n:type:ShaderForge.SFN_Parallax,id:302,x:32077,y:32532,varname:node_302,prsc:2|UVIN-4628-OUT,HEI-2604-OUT;n:type:ShaderForge.SFN_TexCoord,id:114,x:31497,y:32765,varname:node_114,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:2604,x:31834,y:32624,ptovrint:False,ptlb:MainHeight,ptin:_MainHeight,varname:node_2604,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:8820,x:31380,y:32126,ptovrint:False,ptlb:U_Speed,ptin:_U_Speed,varname:node_8820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:3475,x:31380,y:32221,ptovrint:False,ptlb:V_Speed,ptin:_V_Speed,varname:node_3475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Append,id:3063,x:31590,y:32162,varname:node_3063,prsc:2|A-8820-OUT,B-3475-OUT;n:type:ShaderForge.SFN_Multiply,id:4860,x:31761,y:32162,varname:node_4860,prsc:2|A-3063-OUT,B-5214-T;n:type:ShaderForge.SFN_Time,id:5214,x:31590,y:32316,varname:node_5214,prsc:2;n:type:ShaderForge.SFN_Add,id:4628,x:31821,y:32316,varname:node_4628,prsc:2|A-4860-OUT,B-114-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4953,x:32832,y:33105,varname:node_4953,prsc:2|A-143-R,B-7243-OUT,C-707-A;n:type:ShaderForge.SFN_Tex2d,id:5523,x:32736,y:32302,varname:node_5523,prsc:2,ntxv:0,isnm:False|UVIN-850-OUT,TEX-5358-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5358,x:32519,y:32367,ptovrint:False,ptlb:SecondaryParallaxTexture,ptin:_SecondaryParallaxTexture,varname:node_5358,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6273,x:32997,y:32637,varname:node_6273,prsc:2|A-8139-OUT,B-9675-OUT;n:type:ShaderForge.SFN_ValueProperty,id:362,x:31852,y:31903,ptovrint:False,ptlb:U_Speed_2,ptin:_U_Speed_2,varname:_U_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:1023,x:31852,y:31998,ptovrint:False,ptlb:V_Speed_2,ptin:_V_Speed_2,varname:_V_Speed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Append,id:9610,x:32062,y:31939,varname:node_9610,prsc:2|A-362-OUT,B-1023-OUT;n:type:ShaderForge.SFN_Multiply,id:2312,x:32233,y:31939,varname:node_2312,prsc:2|A-9610-OUT,B-3039-T;n:type:ShaderForge.SFN_Time,id:3039,x:32038,y:32093,varname:node_3039,prsc:2;n:type:ShaderForge.SFN_Add,id:850,x:32233,y:32093,varname:node_850,prsc:2|A-2312-OUT,B-114-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8139,x:32812,y:32500,varname:node_8139,prsc:2|A-5523-RGB,B-6533-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6533,x:32519,y:32593,ptovrint:False,ptlb:SecondaryTextureIntensity,ptin:_SecondaryTextureIntensity,varname:node_6533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.7;n:type:ShaderForge.SFN_Multiply,id:4412,x:33242,y:32768,varname:node_4412,prsc:2|A-6273-OUT,B-7292-OUT,C-707-RGB,D-707-A;n:type:ShaderForge.SFN_ValueProperty,id:7243,x:32433,y:33302,ptovrint:False,ptlb:OpacityValue,ptin:_OpacityValue,varname:node_7243,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:7292,x:32842,y:32778,ptovrint:False,ptlb:EmissiveValue,ptin:_EmissiveValue,varname:node_7292,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_VertexColor,id:707,x:31345,y:33036,varname:node_707,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4895,x:33735,y:32902,varname:node_4895,prsc:2|A-4412-OUT,B-8781-OUT;n:type:ShaderForge.SFN_Tex2d,id:1246,x:33425,y:33117,varname:node_1246,prsc:2,ntxv:0,isnm:False|UVIN-114-UVOUT,TEX-883-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:883,x:33128,y:33225,ptovrint:False,ptlb:GradientColor,ptin:_GradientColor,varname:node_883,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8781,x:33682,y:33063,varname:node_8781,prsc:2|A-1246-RGB,B-7539-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7539,x:33620,y:33294,ptovrint:False,ptlb:GradientMap_Value,ptin:_GradientMap_Value,varname:node_7539,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:9898,x:33995,y:32784,varname:node_9898,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-4895-OUT;n:type:ShaderForge.SFN_Add,id:1269,x:34263,y:32775,varname:node_1269,prsc:2|A-9898-R,B-9898-G,C-9898-B;n:type:ShaderForge.SFN_Divide,id:5521,x:34182,y:33094,varname:node_5521,prsc:2|A-1269-OUT,B-7947-OUT;n:type:ShaderForge.SFN_Vector1,id:7947,x:33898,y:33132,varname:node_7947,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:8900,x:34417,y:33025,varname:node_8900,prsc:2|A-5521-OUT,B-7243-OUT,C-143-R;n:type:ShaderForge.SFN_Add,id:102,x:34616,y:33025,varname:node_102,prsc:2|A-8900-OUT,B-2322-OUT;n:type:ShaderForge.SFN_Multiply,id:2322,x:34280,y:33371,varname:node_2322,prsc:2|A-143-R,B-623-OUT,C-707-A;n:type:ShaderForge.SFN_ValueProperty,id:623,x:33962,y:33442,ptovrint:False,ptlb:MaskOpacityValue,ptin:_MaskOpacityValue,varname:node_623,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;proporder:778-9894-2604-8820-3475-5358-362-1023-6533-7243-7292-883-7539-623;pass:END;sub:END;*/

Shader "Custom/AniviaSmoke" {
    Properties {
        _ParallaxTexture ("ParallaxTexture", 2D) = "white" {}
        _MaskTexture ("MaskTexture", 2D) = "white" {}
        _MainHeight ("MainHeight", Float ) = 0.5
        _U_Speed ("U_Speed", Float ) = 0.1
        _V_Speed ("V_Speed", Float ) = 0.15
        _SecondaryParallaxTexture ("SecondaryParallaxTexture", 2D) = "white" {}
        _U_Speed_2 ("U_Speed_2", Float ) = 0.1
        _V_Speed_2 ("V_Speed_2", Float ) = 0.15
        _SecondaryTextureIntensity ("SecondaryTextureIntensity", Float ) = 0.7
        _OpacityValue ("OpacityValue", Float ) = 1
        _EmissiveValue ("EmissiveValue", Float ) = 1
        _GradientColor ("GradientColor", 2D) = "white" {}
        _GradientMap_Value ("GradientMap_Value", Float ) = 1
        _MaskOpacityValue ("MaskOpacityValue", Float ) = 0.5
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
            uniform float4 _TimeEditor;
            uniform sampler2D _ParallaxTexture; uniform float4 _ParallaxTexture_ST;
            uniform sampler2D _MaskTexture; uniform float4 _MaskTexture_ST;
            uniform float _U_Speed;
            uniform float _V_Speed;
            uniform sampler2D _SecondaryParallaxTexture; uniform float4 _SecondaryParallaxTexture_ST;
            uniform float _U_Speed_2;
            uniform float _V_Speed_2;
            uniform float _SecondaryTextureIntensity;
            uniform float _OpacityValue;
            uniform float _EmissiveValue;
            uniform sampler2D _GradientColor; uniform float4 _GradientColor_ST;
            uniform float _GradientMap_Value;
            uniform float _MaskOpacityValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_3039 = _Time + _TimeEditor;
                float2 node_850 = ((float2(_U_Speed_2,_V_Speed_2)*node_3039.g)+i.uv0);
                float4 node_5523 = tex2D(_SecondaryParallaxTexture,TRANSFORM_TEX(node_850, _SecondaryParallaxTexture));
                float4 node_5214 = _Time + _TimeEditor;
                float2 node_4628 = ((float2(_U_Speed,_V_Speed)*node_5214.g)+i.uv0);
                float4 node_6403 = tex2D(_ParallaxTexture,TRANSFORM_TEX(node_4628, _ParallaxTexture));
                float4 node_143 = tex2D(_MaskTexture,TRANSFORM_TEX(i.uv0, _MaskTexture));
                float4 node_1246 = tex2D(_GradientColor,TRANSFORM_TEX(i.uv0, _GradientColor));
                float3 node_4895 = ((((node_5523.rgb*_SecondaryTextureIntensity)+(node_6403.rgb*node_143.rgb))*_EmissiveValue*i.vertexColor.rgb*i.vertexColor.a)*(node_1246.rgb*_GradientMap_Value));
                float3 emissive = node_4895;
                float3 finalColor = emissive;
                float3 node_9898 = node_4895.rgb;
                fixed4 finalRGBA = fixed4(finalColor,((((node_9898.r+node_9898.g+node_9898.b)/3.0)*_OpacityValue*node_143.r)+(node_143.r*_MaskOpacityValue*i.vertexColor.a)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Particles/Additive"
    CustomEditor "ShaderForgeMaterialInspector"
}
