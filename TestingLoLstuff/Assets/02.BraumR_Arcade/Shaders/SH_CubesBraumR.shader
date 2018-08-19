// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:6387,x:35250,y:32553,varname:node_6387,prsc:2|emission-3961-OUT;n:type:ShaderForge.SFN_Color,id:2285,x:33018,y:32807,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2285,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3161765,c2:0.6321502,c3:1,c4:0.553;n:type:ShaderForge.SFN_Tex2d,id:5399,x:33277,y:32593,varname:node_5399,prsc:2,tex:91457b9ebc5225746ae1535bd7e15465,ntxv:0,isnm:False|TEX-8097-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8097,x:33046,y:32629,ptovrint:False,ptlb:CubeTexture,ptin:_CubeTexture,varname:node_8097,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:91457b9ebc5225746ae1535bd7e15465,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9214,x:33660,y:32624,varname:node_9214,prsc:2|A-1315-OUT,B-2285-RGB;n:type:ShaderForge.SFN_Add,id:5791,x:33921,y:32669,varname:node_5791,prsc:2|A-9214-OUT,B-2285-RGB;n:type:ShaderForge.SFN_Multiply,id:1315,x:33636,y:32473,varname:node_1315,prsc:2|A-8203-OUT,B-5399-RGB;n:type:ShaderForge.SFN_ValueProperty,id:8203,x:33329,y:32438,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_8203,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_ComponentMask,id:3137,x:33965,y:32350,varname:node_3137,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-9214-OUT;n:type:ShaderForge.SFN_Add,id:6175,x:34178,y:32461,varname:node_6175,prsc:2|A-3137-OUT,B-2285-A;n:type:ShaderForge.SFN_Multiply,id:276,x:34562,y:32446,varname:node_276,prsc:2|A-6175-OUT,B-3712-OUT;n:type:ShaderForge.SFN_DepthBlend,id:3712,x:34375,y:32597,varname:node_3712,prsc:2|DIST-4045-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4045,x:34136,y:32767,ptovrint:False,ptlb:DepthDistance,ptin:_DepthDistance,varname:node_4045,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_ValueProperty,id:2395,x:34454,y:32817,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_2395,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9820,x:34749,y:32573,varname:node_9820,prsc:2|A-5791-OUT,B-2395-OUT;n:type:ShaderForge.SFN_Multiply,id:5032,x:33414,y:32842,varname:node_5032,prsc:2|A-2285-RGB,B-6624-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6624,x:33183,y:32955,ptovrint:False,ptlb:ColorIntensity,ptin:_ColorIntensity,varname:node_6624,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:3961,x:34998,y:32531,varname:node_3961,prsc:2|A-276-OUT,B-9820-OUT;proporder:2285-8097-8203-4045-2395-6624;pass:END;sub:END;*/

Shader "Custom/SH_CubesBraumR" {
    Properties {
        [HDR]_Color ("Color", Color) = (0.3161765,0.6321502,1,0.553)
        _CubeTexture ("CubeTexture", 2D) = "white" {}
        _Intensity ("Intensity", Float ) = 2
        _DepthDistance ("DepthDistance", Float ) = 1.5
        _Glow ("Glow", Float ) = 1
        _ColorIntensity ("ColorIntensity", Float ) = 2
    }
    SubShader {
        Tags {
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _Color;
            uniform sampler2D _CubeTexture; uniform float4 _CubeTexture_ST;
            uniform float _Intensity;
            uniform float _DepthDistance;
            uniform float _Glow;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 projPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float4 node_5399 = tex2D(_CubeTexture,TRANSFORM_TEX(i.uv0, _CubeTexture));
                float3 node_9214 = ((_Intensity*node_5399.rgb)*_Color.rgb);
                float3 emissive = (((node_9214.b+_Color.a)*saturate((sceneZ-partZ)/_DepthDistance))*((node_9214+_Color.rgb)*_Glow));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
