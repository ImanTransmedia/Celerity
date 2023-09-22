Shader "Custom/DeformationShader_URP"
{
    SubShader
    {
        Pass
        {
            Tags { "RenderType" = "Opaque" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // Sample the Render Texture
                half4 texColor = tex2D(_MainTex, i.uv);

                // If the pixel is white, keep it white; otherwise, set it to black
                return (texColor == 1) ? half4(1, 1, 1, 1) : half4(0, 0, 0, 1);
            }
            ENDCG
        }
    }
}
