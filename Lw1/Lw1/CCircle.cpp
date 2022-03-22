#include "CCircle.h"

const double PI = 3.14159265;

double CCircle::GetRadius() const { return m_radius; }
Point CCircle::GetCenter() const { return m_center; }
std::uint32_t CCircle::GetOutlineColor() const { return m_outlineColor; }
std::uint32_t CCircle::GetFillColor() const { return m_fillColor; }
bool CCircle::SetCenter(Point const& point)
{
	m_center = point;
	return true;
}

bool CCircle::SetRadius(const double radius)
{
	m_radius = radius;
	return true;
}

bool CCircle::SetFillColor(const std::uint32_t color)
{
	m_fillColor = color;
	return true;
}

CCircle::CCircle()
{
}

bool CCircle::SetOutlineColor(const std::uint32_t color)
{
	m_outlineColor = color;
	return true;
}

CCircle::CCircle(Point center, double radius, std::uint32_t outlineColor, std::uint32_t fillColor)
	: m_center(center)
	, m_radius(radius)
	, m_outlineColor(outlineColor)
	, m_fillColor(fillColor)
{
}

void CCircle::Draw(ICanvas& canvas) const
{
	canvas.DrawCircle(m_center, m_radius, m_outlineColor);
	canvas.FillCircle(m_center, m_radius, m_fillColor);
}