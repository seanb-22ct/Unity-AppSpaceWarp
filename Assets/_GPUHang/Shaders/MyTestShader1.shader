Shader "Unlit/MyTestShader1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        ZWrite On

        Pass
        {
            HLSLPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            #include "MyCommon.hlsl"
            #pragma vertex vert
            #pragma fragment frag

            ENDHLSL
        }
    }
}
