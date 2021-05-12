Shader "Peepo/ToonLitOutlined"
{
    Properties
    {
        _BaseMap("Main Texture", 2D) = "white" {}
        _BaseColor("Main Color", COLOR) = (1,1,1,1)

        [HDR] _OutlineColor("Outlie Color", COLOR) = (0,0,0,0)
        _OutlineThiccness("Outline Thiccness", Range(0,1)) = 0.2 //mult for 0.005

        [Toggle]_useOutline("Use Out", Float) = 1

        _testSmooth("SmoothTest", Float) = 0.5
        
        [HideInInspector]_Cutoff("CutOff", Float) = 0
    }

    HLSLINCLUDE
    //Add libraries here
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl" //utils
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl" //for unity lights

    //add non static properties in the command buffer to make the shader SRP Batchable
    CBUFFER_START(UnityPerMaterial)
        float4 _BaseMap_ST;
        half4 _BaseColor;

        half4 _OutlineColor;
        float _OutlineThiccness;
        float _useOutline;
        float _testSmooth;

        float _Cutoff;
    CBUFFER_END
    
    ENDHLSL

    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "IgnoreProjector" = "True" }

        Pass
        {
            Name "Diffuse"
            Tags { "Lightmode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x

            #pragma multi_compile_instancing

            #pragma vertex vert
            #pragma fragment frag
            // make fog work

            // Material Keywords (URP features are the ones who starts with "_")
            #pragma multi_compile_fog

            sampler2D _BaseMap;

            struct Attributes
            {
                float4 posOS : POSITION;
                float2 uv : TEXCOORD0;
                float3 normalOS : NORMAL;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float4 posCS : SV_POSITION;
                float4 posWSandFog : TEXCOORD2;
                float3 normalWS : NORMAL;
            };

            Varyings vert (Attributes input)
            {
                Varyings output;

                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.posOS);
                VertexNormalInputs vertexNormalInput = GetVertexNormalInputs(input.normalOS);
                output.posCS = vertexInput.positionCS;

                //float fogFactor = ComputeFogFactor(vertexInput.positionCS.z);
                output.posWSandFog = float4(vertexInput.positionWS, 0);

                output.normalWS = vertexNormalInput.normalWS;

                output.uv = TRANSFORM_TEX(input.uv, _BaseMap);

                return output;
            }

            half4 frag (Varyings i) : SV_Target
            {
                //get viewDir in worldSpace
                float3 positionWS = i.posWSandFog.xyz;
                float3 viewDirWS = (GetCameraPositionWS() - positionWS);

                // sample the texture
                float3 col = tex2D(_BaseMap, i.uv);
                Light light = GetMainLight();

                float3 normalWS = normalize(i.normalWS);
                float NdotL = saturate(dot(normalWS, normalize(light.direction)) + light.color);

                return half4(col * NdotL, 1);
            }
            ENDHLSL
        }

        //ShadowCastingPass
        Pass {
            Name "ShadowCaster"
            Tags { "LightMode"="ShadowCaster" }
        
            ZWrite On
            ZTest LEqual
        
            HLSLPROGRAM
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x gles
            //#pragma target 4.5
        
            // Material Keywords
            #pragma shader_feature _ALPHATEST_ON
            #pragma shader_feature _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
        
            // GPU Instancing
            #pragma multi_compile_instancing
            #pragma multi_compile _ DOTS_INSTANCING_ON
                    
            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment
            
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/CommonMaterial.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
        
            ENDHLSL
        }

        Pass
        {
            Name "Outline"
            Cull Front

            HLSLPROGRAM
            #pragma vertex OutlineVert
            #pragma fragment OutlineFrag

            struct Attributes
            {
                float4 posOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
                float2 smNormals : TEXCOORD6;
	            float2 smNormals1 : TEXCOORD7;
            };

            struct Varyings
            {
                float4 posCS : SV_POSITION;
                float3 normalWS : NORMAL;
                //float4 smNormalsTest : TEXCOORD0;
                float4 color : TEXCOORD0;
            };

            sampler2D _BaseMap;

            Varyings OutlineVert(Attributes input)
            {
                Varyings output;
                float3 normal = normalize(input.normalOS);
                
                //_OutlineThiccness *= 0.00005; //constant to make it go smooth from ---> 0 - 1
                
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.posOS);
                float cameraDistance = distance(GetCameraPositionWS(), vertexInput.positionWS) * 0.25; //0.25 magic number but maybe transform it to prop
                input.posOS += (float4(normal * _OutlineThiccness, 0) * cameraDistance) * _useOutline;
                vertexInput = GetVertexPositionInputs(input.posOS);
                VertexNormalInputs vertexNormalInput = GetVertexNormalInputs(input.normalOS);

                output.posCS = vertexInput.positionCS;
                
                output.normalWS = vertexNormalInput.normalWS;

                output.color = tex2Dlod(_BaseMap, float4(input.uv, 0, 0));

                return output;
            }

            half4 OutlineFrag(Varyings i) : SV_Target
            {
                return i.color * _OutlineColor;
            }

            ENDHLSL
        }
    }
}
