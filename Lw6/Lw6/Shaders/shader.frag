#version 460 core

struct Complex
{
	double re;
	double im;
};

out vec4 outColor;

in vec2 pos;

uniform sampler2D uColor;
uniform int uIterCount;
uniform double uXOffset;
uniform double uYOffset;
uniform double uScale;
uniform double uColorOffset;
uniform double uIterationColorOffset;

Complex Square(Complex num)
{
	double temp = (num.re * num.re) - (num.im * num.im);
	num.im = 2.0f * num.re * num.im;
	num.re = temp;
	return num;
}

double SquareMagnitude(Complex num)
{
	return (num.re * num.re) + (num.im * num.im);
}

Complex Add(Complex left, Complex right)
{
	left.re += right.re;
	left.im += right.im;
	return left;
}

void main()
{
	double mag;
	Complex c;
	Complex z;
	c.re = pos.x * uScale + uXOffset; 
	c.im = pos.y * uScale + uYOffset;
	z.re = 0;     z.im = 0;
	int it = 0;
	for (it = 0; it < uIterCount; it++)
	{
		z = Square(z);
		z = Add(z, c);

		mag = SquareMagnitude(z);
		if (mag > 4.0f) break;
	}

	vec4 color = texture(uColor, vec2(1.0 / (it + uIterationColorOffset) + uColorOffset, 0));
	if (mag <= 4.0f)
		color = color * 0.5;
	outColor = color;
}