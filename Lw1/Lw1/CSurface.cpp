#include "CSurface.h"
#include <exception>
#include <math.h>

const int STEPS = 15;
const double ANGLE = 3.1415926 * 2.f / STEPS;

void InitHints(std::unordered_map<int, int> const* hints = nullptr)
{
	for (auto const& hint : *hints)
		glfwInitHint(hint.first, hint.second);
}

bool CSurface::WindowShouldClose() const
{
	glfwPollEvents();
	return glfwWindowShouldClose(m_window);
}

void CSurface::DisplayData() const
{
	glfwSwapBuffers(m_window);
	glClear(GL_COLOR_BUFFER_BIT);
}


void CSurface::DrawLine(Point const& from, Point const& to, const std::uint32_t lineColor, int lineWidth)
{
	if (glfwWindowShouldClose(m_window))
	{
		return;
	}
	glLineWidth(lineWidth);
	glBegin(GL_LINES);

	double r = (double)((lineColor >> 16) & 0xff) / 255;
	double g = (double)((lineColor >> 8) & 0xff) / 255;
	double b = (double)((lineColor >> 0) & 0xff) / 255;
	glColor3d(r, g, b);

	glVertex2d((from.x / m_width), (from.y / m_height));
	glVertex2d((to.x / m_width), (to.y / m_height));
	glEnd();
	return;
}

void CSurface::FillPolygon(std::vector<Point> const& points, const std::uint32_t fillColor)
{
	if (glfwWindowShouldClose(m_window))
	{
		return;
	}
	glBegin(GL_POLYGON);
	double r = (double)((fillColor >> 16) & 0xff) / 255;
	double g = (double)((fillColor >> 8) & 0xff) / 255;
	double b = (double)((fillColor >> 0) & 0xff) / 255;
	glColor3d(r, g, b);

	for (Point const& point : points)
	{
		glVertex2d((point.x / m_width), (point.y / m_height));
	}
	glEnd();
	return;
}

void CSurface::DrawCircle(Point const& center, const double radius, std::uint32_t lineColor)
{
	if (glfwWindowShouldClose(m_window))
	{
		return;
	}
	glLineWidth(4);
	glBegin(GL_LINE_LOOP);

	const double CANVAS_CENTER_X = center.x / m_width;
	const double CANVAS_CENTER_Y = center.y / m_height;
	const double RADIUS_PROJECTION_ONTO_CANVAS_X = radius / m_width;
	const double RADIUS_PROJECTION_ONTO_CANVAS_Y = radius / m_height;

	double r = (double)((lineColor >> 16) & 0xff) / 255;
	double g = (double)((lineColor >> 8) & 0xff) / 255;
	double b = (double)((lineColor >> 0) & 0xff) / 255;
	glColor3d(r, g, b);

	for (int i = 0; i < STEPS; i++)
	{
		double newX = RADIUS_PROJECTION_ONTO_CANVAS_X * sin(ANGLE * i) + CANVAS_CENTER_X;
		double newY = -RADIUS_PROJECTION_ONTO_CANVAS_Y * cos(ANGLE * i) + CANVAS_CENTER_Y;
		glVertex2d(newX, newY);
	}
	glEnd();
}

void CSurface::FillCircle(Point const& center, const double radius, std::uint32_t fillColor)
{
	if (glfwWindowShouldClose(m_window))
	{
		return;
	}
	glBegin(GL_POLYGON);

	const double CANVAS_CENTER_X = center.x / m_width;
	const double CANVAS_CENTER_Y = center.y / m_height;
	const double RADIUS_PROJECTION_ONTO_CANVAS_X = radius / m_width;
	const double RADIUS_PROJECTION_ONTO_CANVAS_Y = radius / m_height;

	double r = (double)((fillColor >> 16) & 0xff) / 255;
	double g = (double)((fillColor >> 8) & 0xff) / 255;
	double b = (double)((fillColor >> 0) & 0xff) / 255;
	glColor3d(r, g, b);

	for (int i = 0; i <= STEPS; i++)
	{
		double newX = RADIUS_PROJECTION_ONTO_CANVAS_X * sin(ANGLE * i) + CANVAS_CENTER_X;
		double newY = -RADIUS_PROJECTION_ONTO_CANVAS_Y * cos(ANGLE * i) + CANVAS_CENTER_Y;
		glVertex2d(newX, newY);
	}
	glEnd();
}

GLFWwindow* CSurface::GetWindow() const
{
	return m_window;
}

void CSurface::ProcessInput()
{
	if (glfwGetKey(m_window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
		glfwSetWindowShouldClose(m_window, GLFW_TRUE);
}

CSurface::CSurface(int width, int height, const char* title, std::unordered_map<int, int> const* hints)
{
	m_height = height;
	m_width = width;

	if (glfwInit() != GLFW_TRUE) 
		throw std::exception("ERROR: Failed to allocate memory");

	m_window = glfwCreateWindow(m_width, m_height, title, NULL, NULL);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_ANY_PROFILE);
	glEnable(GL_SMOOTH);


	if (hints != nullptr)
		InitHints(hints);


	glfwMakeContextCurrent(m_window);
	glfwGetFramebufferSize(m_window, &m_width, &m_height);
	glViewport(0, 0, m_width, m_height);
	glClearColor(1, 1, 1, 1);
	glClear(GL_COLOR_BUFFER_BIT);
}

CSurface::~CSurface()
{
	glfwTerminate();
}
