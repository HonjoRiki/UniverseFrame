
Shader "Custom/ACE" {

	Properties{
	}
	SubShader{
		Pass{

		GLSLPROGRAM
#include "UnityCG.glslinc"



#ifdef VERTEX
		in vec4 in_POSITION0;
	out vec4 vPosition;

	mat4 idou = mat4(10,0,0,0,
					 0,10,0,0,
					 0,0,10,0,
					 0,0,0,1);

	void main() {
		vPosition = gl_ModelViewProjectionMatrix
			*idou*  in_POSITION0;

		gl_Position = gl_ModelViewProjectionMatrix
			*idou*  in_POSITION0;
	}
#endif


#ifdef FRAGMENT
	layout(pixel_center_integer)in vec4 gl_FragCoord;

	in vec4 vPosition;
	out vec4 outcolor;
	void main() {
		vec2 st = gl_FragCoord.xy;
		//float depth = (vPosition.z / vPosition.w + 1.0)*0.5;
		float depth = vPosition.z;
		//kBuf[uint(16*st.y+st.x)] = gl_FragCoord.x-15.0*0.5;
		//kBuf[uint(16 * st.y + st.x)] = 19.0;
		outcolor = vec4(0.0,1.0,0.0,1.0);
	}
#endif

	ENDGLSL
	}
	}
}
