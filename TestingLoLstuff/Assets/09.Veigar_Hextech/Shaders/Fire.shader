// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5955882,fgcg:0.5955882,fgcb:0.5955882,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:479,x:33761,y:32619,varname:node_479,prsc:2|emission-6149-OUT,alpha-4799-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:841,x:31786,y:32758,ptovrint:False,ptlb:Texture_1,ptin:_Texture_1,varname:node_841,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cd2d245a0aaa0b940827df9ad44b6297,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5617,x:31986,y:32758,varname:node_5617,prsc:2,tex:cd2d245a0aaa0b940827df9ad44b6297,ntxv:0,isnm:False|UVIN-7303-UVOUT,TEX-841-TEX;n:type:ShaderForge.SFN_Panner,id:7303,x:31786,y:32931,varname:node_7303,prsc:2,spu:-0.1,spv:-1|UVIN-9658-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9658,x:31376,y:32829,varname:node_9658,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:7054,x:31986,y:32954,varname:node_7054,prsc:2,tex:cd2d245a0aaa0b940827df9ad44b6297,ntxv:0,isnm:False|UVIN-1783-UVOUT,TEX-841-TEX;n:type:ShaderForge.SFN_Panner,id:1783,x:31786,y:33105,varname:node_1783,prsc:2,spu:0.5,spv:0.5|UVIN-4690-OUT;n:type:ShaderForge.SFN_Multiply,id:4690,x:31603,y:32975,varname:node_4690,prsc:2|A-9658-UVOUT,B-7669-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7669,x:31421,y:33178,ptovrint:False,ptlb:UV_Stretch_2,ptin:_UV_Stretch_2,varname:node_7669,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.7;n:type:ShaderForge.SFN_Multiply,id:9804,x:32276,y:32810,varname:node_9804,prsc:2|A-5617-RGB,B-7054-RGB,C-1940-RGB;n:type:ShaderForge.SFN_Tex2d,id:1940,x:31986,y:33153,varname:node_1940,prsc:2,tex:cd2d245a0aaa0b940827df9ad44b6297,ntxv:0,isnm:False|UVIN-5751-UVOUT,TEX-841-TEX;n:type:ShaderForge.SFN_Panner,id:5751,x:31786,y:33275,varname:node_5751,prsc:2,spu:-0.5,spv:0.5|UVIN-6355-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5036,x:31421,y:33307,ptovrint:False,ptlb:UV_Stretch_3,ptin:_UV_Stretch_3,varname:_UV_Stretch_3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:6355,x:31632,y:33341,varname:node_6355,prsc:2|A-9658-UVOUT,B-5036-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:8925,x:31998,y:33411,ptovrint:False,ptlb:FireShape,ptin:_FireShape,varname:node_8925,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2870f10b267a4c34eb6bd6208a93eaef,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5878,x:32166,y:33411,varname:node_5878,prsc:2,tex:2870f10b267a4c34eb6bd6208a93eaef,ntxv:0,isnm:False|TEX-8925-TEX;n:type:ShaderForge.SFN_Multiply,id:2677,x:32448,y:32963,varname:node_2677,prsc:2|A-6182-OUT,B-5878-RGB;n:type:ShaderForge.SFN_Multiply,id:6182,x:32448,y:32810,varname:node_6182,prsc:2|A-9804-OUT,B-3157-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3157,x:32184,y:33027,ptovrint:False,ptlb:MultiplyCorrection,ptin:_MultiplyCorrection,varname:node_3157,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:1045,x:32824,y:32978,varname:node_1045,prsc:2|A-2677-OUT,B-5671-RGB;n:type:ShaderForge.SFN_Color,id:5671,x:32576,y:33158,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5671,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6415823,c2:0.1617647,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6523,x:33070,y:32954,varname:node_6523,prsc:2|A-1045-OUT,B-8457-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8457,x:32859,y:33220,ptovrint:False,ptlb:GlowValue,ptin:_GlowValue,varname:node_8457,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_ComponentMask,id:689,x:32838,y:32748,varname:node_689,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2677-OUT;n:type:ShaderForge.SFN_Multiply,id:6149,x:33471,y:32626,varname:node_6149,prsc:2|A-1744-RGB,B-6523-OUT,C-1744-A;n:type:ShaderForge.SFN_VertexColor,id:1744,x:33100,y:32566,varname:node_1744,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4799,x:33482,y:32813,varname:node_4799,prsc:2|A-1744-A,B-689-OUT;proporder:841-7669-5036-8925-3157-5671-8457;pass:END;sub:END;*/

Shader "Custom/Fire" {
    Properties {
        _Texture_1 ("Texture_1", 2D) = "white" {}
        _UV_Stretch_2 ("UV_Stretch_2", Float ) = 0.7
        _UV_Stretch_3 ("UV_Stretch_3", Float ) = 0.3
        _FireShape ("FireShape", 2D) = "white" {}
        _MultiplyCorrection ("MultiplyCorrection", Float ) = 4
        _Color ("Color", Color) = (0.6415823,0.1617647,1,1)
        _GlowValue ("GlowValue", Float ) = 3
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
            uniform sampler2D _Texture_1; uniform float4 _Texture_1_ST;
            uniform float _UV_Stretch_2;
            uniform float _UV_Stretch_3;
            uniform sampler2D _FireShape; uniform float4 _FireShape_ST;
            uniform float _MultiplyCorrection;
            uniform float4 _Color;
            uniform float _GlowValue;
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
                float4 node_526 = _Time + _TimeEditor;
                float2 node_7303 = (i.uv0+node_526.g*float2(-0.1,-1));
                float4 node_5617 = tex2D(_Texture_1,TRANSFORM_TEX(node_7303, _Texture_1));
                float2 node_1783 = ((i.uv0*_UV_Stretch_2)+node_526.g*float2(0.5,0.5));
                float4 node_7054 = tex2D(_Texture_1,TRANSFORM_TEX(node_1783, _Texture_1));
                float2 node_5751 = ((i.uv0*_UV_Stretch_3)+node_526.g*float2(-0.5,0.5));
                float4 node_1940 = tex2D(_Texture_1,TRANSFORM_TEX(node_5751, _Texture_1));
                float4 node_5878 = tex2D(_FireShape,TRANSFORM_TEX(i.uv0, _FireShape));
                float3 node_2677 = (((node_5617.rgb*node_7054.rgb*node_1940.rgb)*_MultiplyCorrection)*node_5878.rgb);
                float3 emissive = (i.vertexColor.rgb*((node_2677*_Color.rgb)*_GlowValue)*i.vertexColor.a);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(i.vertexColor.a*node_2677.r));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
