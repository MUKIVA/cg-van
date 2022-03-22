#include <iostream>
#include "../Lw1/CSurface.h"
#include <locale>
#include <ctime>
//#include <Windows.h>
#include <unordered_map>
#include "../Lw1/CPolygon.h"
#include "../Lw1/CLineSegment.h"
#include "../Lw1/CRectangle.h"
#include "../Lw1/CTriangle.h"
#include "../Lw1/CPolygon.h"
#include "../Lw1/CCircle.h"

const int DEFAULT_WIDTH = 800;
const int DEFAULT_HEIGHT = 600;
const char* APP_TITLE = "MyApp";


CRectangle RocketFrame()
{
	CRectangle frame({ 100, 400 }, {-100, -400}, 0x000000, 0x909090);
	return frame;
}

CTriangle RocketNose()
{
	CTriangle nose({ -150, 350 }, { 150, 350 }, {0, 500}, 0x000000, 0xAA2222);
	return nose;
}


CPolygon RocketLeftFing()
{
	CPolygon fing;
	fing.SetFillColor(0x22AA22);
	fing.AddPoint({ -75, -250 });
	fing.AddPoint({ -150, -375 });
	fing.AddPoint({ -175, -500 });
	fing.AddPoint({ -75, -400 });
	return fing;
}

CPolygon RocketRightFing()
{
	CPolygon fing;
	fing.SetFillColor(0x22AA22);
	fing.AddPoint({ 75, -250 });
	fing.AddPoint({ 150, -375 });
	fing.AddPoint({ 175, -500 });
	fing.AddPoint({ 75, -400 });
	return fing;
}


std::vector<CCircle> RocketPorthole()
{
	std::vector<CCircle> portholes;
	portholes.push_back(CCircle({ 0, 200 }, 50, 0x000000, 0x2222AA));
	portholes.push_back(CCircle({ 0, 0 }, 50, 0x000000, 0x2222AA));
	portholes.push_back(CCircle({ 0, -200 }, 50, 0x000000, 0x2222AA));
	return portholes;
}


std::vector<CTriangle> RocketFire()
{
	std::vector<CTriangle> fires;
	fires.push_back(CTriangle({ -100, -400 }, { -50, -500 }, {0, -400}, 0, 0xFFA500));
	fires.push_back(CTriangle({ 100, -400 }, { 50, -500 }, { 0, -400 }, 0, 0xFFA500));
	fires.push_back(CTriangle({ -50, -400 }, { 0, -550 }, { 50, -400 }, 0, 0xFFA500));
	return fires;
}

int main(int argc, char* argv)
{
	setlocale(LC_ALL, "");

	std::unordered_map<int, int> hints = std::unordered_map<int, int>();
	hints.insert({ GLFW_RESIZABLE, GLFW_FALSE });
	hints.insert({ GLFW_SCALE_TO_MONITOR, GLFW_TRUE });
	hints.insert({ GLFW_DOUBLEBUFFER, GLFW_TRUE });
	hints.insert({ GL_LINE_SMOOTH_HINT, GL_NICEST});
	hints.insert({ GL_POLYGON_SMOOTH_HINT, GL_NICEST });

	CSurface surface(DEFAULT_WIDTH, DEFAULT_HEIGHT, APP_TITLE, nullptr);

	auto frame = RocketFrame();
	auto nose = RocketNose();
	auto rightFing = RocketRightFing();
	auto leftFing = RocketLeftFing();
	auto portholes = RocketPorthole();
	auto fires = RocketFire();

	// global cycle
	while (!surface.WindowShouldClose())
	{
		clock_t startTime = clock();

		// user input
		surface.ProcessInput();

		// Render command
		frame.Draw(surface);
		nose.Draw(surface);

		for (auto const& porthole : portholes)
			porthole.Draw(surface);

		for (auto const& fire : fires)
			fire.Draw(surface);

		rightFing.Draw(surface);
		leftFing.Draw(surface);


		surface.DisplayData();

		clock_t deltaTime = clock() - startTime;

	}
}