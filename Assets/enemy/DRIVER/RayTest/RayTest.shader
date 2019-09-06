
Shader "Custom/RayTest" {

	Properties{
	}
	SubShader{
	Pass{

	GLSLPROGRAM
#include "UnityCG.glslinc"
#version 450 



#ifdef VERTEX
    in vec4 in_POSITION0;
	out vec4 vPosition;
	uniform mat4 RayTestVertMat;

	void main() {
		vPosition = gl_ModelViewProjectionMatrix 
			* RayTestVertMat* in_POSITION0;

		gl_Position = gl_ModelViewProjectionMatrix 
			* RayTestVertMat* in_POSITION0;
	}
#endif


#ifdef FRAGMENT
	layout(pixel_center_integer)in vec4 gl_FragCoord;

	in vec4 vPosition;
	layout(std430, binding = 0)buffer kyoriBuf { float kBuf[]; };
	out vec4 outcolor;

	void main() {
		vec2 st = gl_FragCoord.xy;
		//float depth = (vPosition.z / vPosition.w + 1.0)*0.5;
		float depth = vPosition.z;
		//kBuf[uint(16*st.y+st.x)] = gl_FragCoord.x-15.0*0.5;
		kBuf[uint(16 * st.y + st.x)] = length(vec2(1.5,1.5));
		outcolor = vec4(0.0,1.0,0.0,1.0);
	}
#endif

	ENDGLSL
	}
	}
}
