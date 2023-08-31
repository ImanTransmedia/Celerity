Shader "Custom/ParticleColorByDistance" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _PositionsArray("Positions Array", Vector) = (0, 0, 0, 0)
        _RadiiArray("Radii Array", Float) = 0
        _ObjectsCount("Objects Count", Range(0, 10)) = 1
    }

        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
            LOD 100

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            float4 _PositionsArray[10];
            float _RadiiArray[10];
            int _ObjectsCount;

            struct Input {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                float4 col = tex2D(_MainTex, IN.uv_MainTex);
                float3 worldPos = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0);
                float minDist = 1000.0;
                for (int i = 0; i < _ObjectsCount; i++) {
                    float dist = distance(worldPos, _PositionsArray[i].xyz);
                    if (dist < _RadiiArray[i] && dist < minDist) {
                        minDist = dist;
                    }
                }
                if (minDist < 1000.0) {
                    col.rgb = lerp(float3(0, 1, 0), float3(1, 0, 0), minDist);
                }
                o.Albedo = col.rgb;
                o.Alpha = col.a;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
