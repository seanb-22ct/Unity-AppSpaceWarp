Shader "Unlit/MyTestShader2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        // Note: Settting ZWrite to On will "fix" the GPU hang
        ZWrite Off

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
