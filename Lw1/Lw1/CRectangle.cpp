#include "CRectangle.h"

Point CRectangle::GetLeftTop() const { return m_leftTop; }

Point CRectangle::GetRightBottom() const { return m_rightBottom; }

std::uint32_t CRectangle::GetOutlineColor() const { return m_outlineColor; }

std::uint32_t CRectangle::GetFillColor() const { return m_fillColor; }

double CRectangle::GetHeight() const
{
	return abs(m_leftTop.y - m_rightBottom.y);
}

double CRectangle::GetWidth() const
{
	return abs(m_rightBottom.x - m_leftTop.x);
}

bool CRectangle::SetFillColor(const std::uint32_t color)
{
	m_fillColor = color;
	return true;
}

bool CRectangle::SetOutlineColor(const std::uint32_t color)
{
	m_outlineColor = color;
	return true;
}

bool CRectangle::SetLeftTop(Point const& point)
{
	m_leftTop = point;
	return true;
}

bool CRectangle::SetRightBottom(Point const& point)
{
	m_rightBottom = point;
	return true;
}

CRectangle::CRectangle(Point leftTop, Point rightBottom, std::uint32_t outlineColor, std::uint32_t fillColor)
	: m_leftTop(leftTop)
	, m_rightBottom(rightBottom)
	, m_outlineColor(outlineColor)
	, m_fillColor(fillColor)

{
}

CRectangle::CRectangle() {}

void CRectangle::Draw(ICanvas& canvas) const
{
	std::vector<Point> points;
	points.push_back({ m_leftTop.x, m_leftTop.y });
	points.push_back({ m_rightBottom.x, m_leftTop.y });
	points.push_back({ m_rightBottom.x, m_rightBottom.y });
	points.push_back({ m_leftTop.x, m_rightBottom.y });
	canvas.FillPolygon(points, m_fillColor);
}