#include <iostream>
#include "CSurface.h"
#include <locale>
#include <ctime>
//#include <Windows.h>
#include <unordered_map>
#include "CPolygon.h"
#include "CLineSegment.h"

const int DEFAULT_WIDTH = 640;
const int DEFAULT_HEIGHT = 480;
const char* APP_TITLE = "MyApp";


std::vector<CLineSegment> GetFirstNameInitial()
{
	std::vector<CLineSegment> lines;
	auto color = 0x8066dd;

	//lines.push_back(CLineSegment({ -310, -100 }, { -310, 100 }, color, 20));
	lines.push_back(CLineSegment({ -310, 100 }, { -250, 0 }, color, 150));
	//lines.push_back(CLineSegment({ -250, 0 }, { -190, 100 }, color, 150));
	//lines.push_back(CLineSegment({ -190, 100 }, { -190, -100 }, color, 150));

	return lines;
}

std::vector<CLineSegment> GetLastNameInitial()
{
	std::vector<CLineSegment> lines;
	auto color = 0x000000;

	lines.push_back(CLineSegment({ -50, -100 }, { -50, 100 }, color, 20));
	lines.push_back(CLineSegment({ -50, -100 }, { 50, 100 }, color, 20));
	lines.push_back(CLineSegment({ 50, -100 }, { 50, 100 }, color, 20));

	return lines;
}


std::vector<CLineSegment> GetSurnameInitial()
{
	std::vector<CLineSegment> lines;
	auto color = 0xFFFF00;

	lines.push_back(CLineSegment({ 250, 90 }, { 310, 90 }, color, 20));
	lines.push_back(CLineSegment({ 250, 100 }, { 210, -70 }, color, 20));
	lines.push_back(CLineSegment({ 310, 100 }, { 350, -70 }, color, 20));
	lines.push_back(CLineSegment({ 184, -70 }, { 377, -70 }, color, 20));
	lines.push_back(CLineSegment({ 190, -70 }, { 210, -100 }, color, 20));
	lines.push_back(CLineSegment({ 370, -70 }, { 350, -100 }, color, 20));

	return lines;
}

int main(int argc, char* argv)
{
	setlocale(LC_ALL, "");

	std::unordered_map<int, int> hints = std::unordered_map<int, int>();
	hints.insert({ GLFW_RESIZABLE, GLFW_FALSE });
	hints.insert({ GLFW_SCALE_TO_MONITOR, GLFW_TRUE });
	hints.insert({ GLFW_DOUBLEBUFFER, GLFW_TRUE });
	hints.insert({ GL_LINE_SMOOTH_HINT, GL_NICEST });

	CSurface surface(DEFAULT_WIDTH, DEFAULT_HEIGHT, APP_TITLE, nullptr);

	auto first = GetFirstNameInitial();
	auto last = GetLastNameInitial();
	auto surname = GetSurnameInitial();

	// global cycle
	while (!surface.WindowShouldClose())
	{
		clock_t startTime = clock();

		// user input
		surface.ProcessInput();

		// Render command
		for (auto const& line : first)
			line.Draw(surface);

		for (auto const& line : last)
			line.Draw(surface);

		for (auto const& line : surname)
			line.Draw(surface);

		surface.DisplayData();

		clock_t deltaTime = clock() - startTime;

	} 
}