#pragma once
#include <memory>
#include <unordered_map>
#include <vector>
#include <GLFW/glfw3.h>
#include "ICanvas.h"

class CSurface : public ICanvas
{
public:
	bool WindowShouldClose() const;
	void DisplayData() const;
	void DrawLine(Point const& from, Point const& to, const std::uint32_t lineColor, int lineWidth = 4) override;
	void FillPolygon(std::vector<Point> const& points, const std::uint32_t fillColor) override;
	void DrawCircle(Point const& center, const double radius, std::uint32_t lineColor) override;
	void FillCircle(Point const& center, const double radius, std::uint32_t fillColor) override;


	GLFWwindow* GetWindow() const;
	void ProcessInput();


	CSurface(int width, int height, const char* title, std::unordered_map<int, int> const* hints);

	~CSurface();


private:
	GLFWwindow* m_window;
	int m_width;
	int m_height;	
};

