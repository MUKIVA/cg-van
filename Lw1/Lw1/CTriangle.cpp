#include "CTriangle.h"

std::uint32_t CTriangle::GetOutlineColor() const { return m_outlineColor; }

std::uint32_t CTriangle::GetFillColor() const { return m_fillColor; }

Point CTriangle::GetVertex1() const { return m_p1; }

Point CTriangle::GetVertex2() const { return m_p2; }

Point CTriangle::GetVertex3() const { return m_p3; }

bool CTriangle::SetFillColor(const std::uint32_t color)
{
	m_fillColor = color;
	return true;
}

bool CTriangle::SetOutlineColor(const std::uint32_t color)
{
	m_outlineColor = color;
	return true;
}

bool CTriangle::SetVertex1(Point const& point)
{
	m_p1 = point;
	return true;
}

bool CTriangle::SetVertex2(Point const& point)
{
	m_p2 = point;
	return true;
}

bool CTriangle::SetVertex3(Point const& point)
{
	m_p3 = point;
	return true;
}

CTriangle::CTriangle()
{
}

CTriangle::CTriangle(Point p1, Point p2, Point p3, std::uint32_t outlineColor, std::uint32_t fillColor)
	: m_p1(p1)
	, m_p2(p2)
	, m_p3(p3)
	, m_outlineColor(outlineColor)
	, m_fillColor(fillColor)
{
}

void CTriangle::Draw(ICanvas& canvas) const
{
	std::vector<Point> points;
	points.push_back({ m_p1.x, m_p1.y });
	points.push_back({ m_p2.x, m_p2.y });
	points.push_back({ m_p3.x, m_p3.y });
	canvas.FillPolygon(points, m_fillColor);
}