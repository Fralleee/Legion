// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8224,x:34470,y:32503,varname:node_8224,prsc:2|emission-3667-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2711,x:31995,y:32618,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_2711,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4c6db099bf93f7f4ea3841c6e9ae8e32,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:702,x:32181,y:32618,varname:node_702,prsc:2,tex:4c6db099bf93f7f4ea3841c6e9ae8e32,ntxv:0,isnm:False|TEX-2711-TEX;n:type:ShaderForge.SFN_Sin,id:9279,x:32219,y:33069,varname:node_9279,prsc:2|IN-5743-OUT;n:type:ShaderForge.SFN_Time,id:2688,x:31855,y:33069,varname:node_2688,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5743,x:32037,y:33069,varname:node_5743,prsc:2|A-2688-T,B-3929-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3929,x:31855,y:33247,ptovrint:False,ptlb:Speed1,ptin:_Speed1,varname:node_3929,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Add,id:8263,x:32387,y:33069,varname:node_8263,prsc:2|A-9279-OUT,B-1512-OUT;n:type:ShaderForge.SFN_Vector1,id:1945,x:32219,y:33203,varname:node_1945,prsc:2,v1:1.3;n:type:ShaderForge.SFN_Multiply,id:3854,x:32640,y:32618,varname:node_3854,prsc:2|A-702-R,B-9303-OUT,C-1216-RGB,D-7736-OUT;n:type:ShaderForge.SFN_VertexColor,id:1216,x:31995,y:32792,varname:node_1216,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6480,x:32907,y:32798,varname:node_6480,prsc:2|A-702-R,B-7464-OUT,C-1216-A;n:type:ShaderForge.SFN_ValueProperty,id:506,x:31855,y:33331,ptovrint:False,ptlb:Speed2,ptin:_Speed2,varname:node_506,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:9.15;n:type:ShaderForge.SFN_Multiply,id:4623,x:32037,y:33213,varname:node_4623,prsc:2|A-2688-T,B-506-OUT;n:type:ShaderForge.SFN_Sin,id:8233,x:32219,y:33259,varname:node_8233,prsc:2|IN-4623-OUT;n:type:ShaderForge.SFN_Add,id:8332,x:32399,y:33259,varname:node_8332,prsc:2|A-1512-OUT,B-8233-OUT;n:type:ShaderForge.SFN_Multiply,id:9303,x:32567,y:33069,varname:node_9303,prsc:2|A-8263-OUT,B-8332-OUT;n:type:ShaderForge.SFN_Add,id:7464,x:32865,y:33093,varname:node_7464,prsc:2|A-9303-OUT,B-5740-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8903,x:32681,y:33379,ptovrint:False,ptlb:Add,ptin:_Add,varname:node_8903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.225;n:type:ShaderForge.SFN_Multiply,id:5740,x:32865,y:33249,varname:node_5740,prsc:2|A-7736-OUT,B-8903-OUT;n:type:ShaderForge.SFN_Multiply,id:6872,x:33173,y:32799,varname:node_6872,prsc:2|A-4164-OUT,B-6480-OUT;n:type:ShaderForge.SFN_DepthBlend,id:4164,x:32900,y:32521,varname:node_4164,prsc:2|DIST-237-OUT;n:type:ShaderForge.SFN_ValueProperty,id:237,x:32610,y:32368,ptovrint:False,ptlb:Depth,ptin:_Depth,varname:node_237,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:1754,x:33173,y:32640,varname:node_1754,prsc:2|A-3854-OUT,B-4164-OUT;n:type:ShaderForge.SFN_Add,id:7736,x:32418,y:32864,varname:node_7736,prsc:2|A-1216-A,B-8903-OUT;n:type:ShaderForge.SFN_Add,id:1512,x:32422,y:33469,varname:node_1512,prsc:2|A-1945-OUT,B-1657-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1657,x:32085,y:33539,ptovrint:False,ptlb:Minimum,ptin:_Minimum,varname:node_1657,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:8247,x:33438,y:32681,varname:node_8247,prsc:2|A-1754-OUT,B-6872-OUT;n:type:ShaderForge.SFN_Multiply,id:7465,x:33751,y:32615,varname:node_7465,prsc:2|A-8247-OUT,B-6299-RGB;n:type:ShaderForge.SFN_Color,id:6299,x:33456,y:32913,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_6299,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3667,x:34027,y:32632,varname:node_3667,prsc:2|A-7465-OUT,B-1091-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1091,x:33751,y:32782,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_1091,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:3929-2711-506-8903-237-1657-6299-1091;pass:END;sub:END;*/

Shader "Custom/SH_Add_Interferences" {
    Properties {
        _Speed1 ("Speed1", Float ) = 4
        _Texture ("Texture", 2D) = "white" {}
        _Speed2 ("Speed2", Float ) = 9.15
        _Add ("Add", Float ) = 0.225
        _Depth ("Depth", Float ) = 0.1
        _Minimum ("Minimum", Float ) = 0.4
        _Color ("Color", Color) = (1,1,1,1)
        _Intensity ("Intensity", Float ) = 1
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Speed1;
            uniform float _Speed2;
            uniform float _Add;
            uniform float _Depth;
            uniform float _Minimum;
            uniform float4 _Color;
            uniform float _Intensity;
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
                float4 node_702 = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float4 node_2688 = _Time + _TimeEditor;
                float node_1512 = (1.3+_Minimum);
                float node_9303 = ((sin((node_2688.g*_Speed1))+node_1512)*(node_1512+sin((node_2688.g*_Speed2))));
                float node_7736 = (i.vertexColor.a+_Add);
                float node_4164 = saturate((sceneZ-partZ)/_Depth);
                float3 emissive = (((((node_702.r*node_9303*i.vertexColor.rgb*node_7736)*node_4164)*(node_4164*(node_702.r*(node_9303+(node_7736*_Add))*i.vertexColor.a)))*_Color.rgb)*_Intensity);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
