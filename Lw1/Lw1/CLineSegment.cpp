#include "CLineSegment.h"

std::uint32_t CLineSegment::GetOutlineColor() const { return m_outlineColor; }

Point CLineSegment::GetStartPoint() const { return m_startPoint; }

Point CLineSegment::GetEndPoint() const { return m_endPoint; }

bool CLineSegment::SetStartPoint(Point const& point)
{
	m_startPoint = point;
	return true;
}

bool CLineSegment::SetEndPoint(Point const& point)
{
	m_endPoint = point;
	return true;
}

bool CLineSegment::SetOutlineColor(const std::uint32_t color)
{
	m_outlineColor = color;
	return true;
}

CLineSegment::CLineSegment()
{
}


CLineSegment::CLineSegment(Point start, Point end, std::uint32_t outlineColor, int lineWidth)
	: m_startPoint(start)
	, m_endPoint(end)
	, m_outlineColor(outlineColor)
	, m_lineWidth(lineWidth)
{
}

void CLineSegment::Draw(ICanvas& canvas) const
{
	canvas.DrawLine(m_startPoint, m_endPoint, m_outlineColor, m_lineWidth);
}
