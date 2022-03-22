#include "CPolygon.h"

void CPolygon::Draw(ICanvas& cnavas) const
{
    cnavas.FillPolygon(m_points, m_fillColor);
}

std::uint32_t CPolygon::GetOutlineColor() const
{
    return m_outlineColor;
}

std::uint32_t CPolygon::GetFillColor() const
{
    return m_fillColor;
}

bool CPolygon::SetOutlineColor(const std::uint32_t color)
{
    m_outlineColor = color;
    return true;
}

bool CPolygon::SetFillColor(const std::uint32_t color)
{
    m_fillColor = color;
    return true;
}

CPolygon::CPolygon()
    : m_fillColor(0)
    , m_outlineColor(0)
{
}

CPolygon::CPolygon(
    std::vector<Point> data,
    std::uint32_t outlineColor,
    std::uint32_t fillColor)
{
    m_points = data;
    m_outlineColor = outlineColor;
    m_fillColor = fillColor;
}

bool CPolygon::AddPoint(Point point)
{
    m_points.push_back(point);
    return true;
}

bool CPolygon::ErasePoint(size_t index)
{
    if (index <= 0 && index >= m_points.size())
        return false;
    m_points.erase(m_points.begin() + index);
    return true;
}
